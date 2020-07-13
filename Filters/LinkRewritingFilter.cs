using AutoMapper.Internal;
using CuddlyWombatAPI.Infrastructure;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Filters
{
    public class LinkRewritingFilter : IAsyncResultFilter
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public LinkRewritingFilter(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        /*public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var asObjectResult = context.Result as ObjectResult;
            bool shouldSkip = asObjectResult?.StatusCode >= 400
                || asObjectResult?.Value == null
                || asObjectResult?.Value as Resource == null;
            if (shouldSkip)
            {
                return next();
            }

            var rewriter = new LinkRewriter(_urlHelperFactory.GetUrlHelper(context));
            RewriteAllLinks(asObjectResult.Value, rewriter);
            return next();
        }*/

        private static void RewriteAllLinks(object model, LinkRewriter rewriter)
        {
            if (model == null)
            {
                return;
            }
            var allProperties = model
                .GetType().GetTypeInfo()
                .GetProperties()
                .Where(p => p.CanRead)
                .ToList();
            var linkProperties = allProperties
                .Where(p => p.CanWrite && p.PropertyType == typeof(Link));
            foreach (var linkProperty in linkProperties)
            {
                var rewritten = rewriter.Rewrite(linkProperty.GetValue(model) as Link);
                if (rewritten == null)
                {
                    continue;
                }
                linkProperty.SetValue(model, rewritten);
                //Speciall handling for the hidden Self property
                if (linkProperty.Name == nameof(Resource.Self))
                {
                    allProperties.SingleOrDefault(p => p.Name == nameof(Resource.Href))
                        ?.SetValue(model, rewritten.Href);
                    allProperties.SingleOrDefault(p => p.Name == nameof(Resource.Method))
                        ?.SetValue(model, rewritten.Method);
                    allProperties.SingleOrDefault(p => p.Name == nameof(Resource.Relations))
                        ?.SetValue(model, rewritten.Relations);
                }

            }

            var listProperties = allProperties.Where(p => p.PropertyType.IsListType());
            RewriteLinksInLists(listProperties, model, rewriter);

            var objectProperties = allProperties
                .Except(linkProperties)
                .Except(listProperties);
            RewriteLinksInNestedObjects(objectProperties, model, rewriter);
        }

        private static void RewriteLinksInNestedObjects(
            IEnumerable<PropertyInfo> objectProperties,
            object model,
            LinkRewriter rewriter)
        {
            foreach (var objectProperty in objectProperties)
            {
                if (objectProperty.PropertyType == typeof(string))
                {
                    continue;
                }

                var typeInfo = objectProperty.PropertyType.GetTypeInfo();
                if (typeInfo.IsClass)
                {
                    RewriteAllLinks(objectProperty.GetValue(model), rewriter);
                }
            }
        }

        private static void RewriteLinksInLists(
            IEnumerable<PropertyInfo> listProperties,
            object model,
            LinkRewriter rewriter)
        {
            foreach (var listProperty in listProperties)
            {
                var list = listProperty.GetValue(model) as IList ?? new IList[0];
                foreach (var element in list)
                {
                    RewriteAllLinks(element, rewriter);
                }
            }
        }

        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var asObjectResult = context.Result as ObjectResult;
            /*bool shouldSkip = asObjectResult?.StatusCode >= 400
                || asObjectResult?.Value == null
                || asObjectResult?.Value as Resource == null;*/
            bool shouldSkip = false;
            if (asObjectResult.StatusCode >= 400)
            {
                shouldSkip = true;
            }
            if(asObjectResult.Value == null)
            {
                shouldSkip = true;
            }
            if (asObjectResult.Value as Resource == null)
            {
                shouldSkip = true;
            }

            Resource test = asObjectResult.Value as Resource;

            if (shouldSkip)
            {
                return next();
            }

            var rewriter = new LinkRewriter(_urlHelperFactory.GetUrlHelper(context));
            RewriteAllLinks(asObjectResult.Value, rewriter);
            return next();
        }
    }
}
