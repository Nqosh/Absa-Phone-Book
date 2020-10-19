using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Validation.Filters
{
    public class ValidateInputFilter : IActionFilter
    {

        private static readonly Dictionary<string, string> ClaimsToAdd = new Dictionary<string, string>
        {
            {"name", "Name"},
            {"role", "Role"}
        };

        private readonly ILogger _logger;

        public ValidateInputFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
