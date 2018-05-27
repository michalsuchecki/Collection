using System;
using Collection.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Collection.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected void UpdateRefererUrl()
        {
            if(TempData.ContainsKey("returnUrl"))
                TempData["returnUrl"] = HttpContext.UrlReferer();
            else
                TempData.Add("returnUrl", HttpContext.UrlReferer());
        }

        protected IActionResult RedirectToReferer()
        {
            if(TempData.ContainsKey("returnUrl"))
                return Redirect(TempData["returnUrl"] as String);
            else
                return RedirectToAction("Index");
        }
    }
}