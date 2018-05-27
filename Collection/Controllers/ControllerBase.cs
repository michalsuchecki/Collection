using System;
using System.Linq;
using Collection.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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

        #region Cookies
        public string GetCookie(string key)  
        {  
            return Request.Cookies["Key"];  
        }  

        public void SetCookie(string key, string value, int? expireTime = null)  
        {  
            
            if (expireTime.HasValue)
            {
                CookieOptions option = new CookieOptions();  
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);  
                Response.Cookies.Append(key, value, option);  
            }
            else  
            {
                Response.Cookies.Append(key, value);    
            }
        }  

        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key); 
        }
        
        #endregion
    }
}