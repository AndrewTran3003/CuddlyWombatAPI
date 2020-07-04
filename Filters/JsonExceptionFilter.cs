using CuddlyWombatAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public JsonExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();
            if (_webHostEnvironment.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "Internal Server error!";
                error.Detail = "Contact the Administrator for more detail!";
            }
            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
