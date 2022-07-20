using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public void OnException(ExceptionContext context)
        {

        }
    }
}
