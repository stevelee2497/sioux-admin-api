﻿using System.Linq;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
	/// <summary>
	/// Filter for returning a result if the given model to a controller does not pass validation
	/// </summary>
	public class ValidatorActionFilter : IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (!filterContext.ModelState.IsValid)
			{
				throw new BadRequestException(filterContext.ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage);
			}
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
		}
	}
}