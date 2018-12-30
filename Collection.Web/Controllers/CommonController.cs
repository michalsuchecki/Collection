using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Collection.Web.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OpenModal(string title, string body, ModalSize size, string onClose, string onConfirm)
        {
            return PartialView("_Modal", new ModalViewModel() {
                Title = title,
                Body = body,
                Size = size,
                OnClose = onClose,
                OnConfirm = onConfirm
            });
        }
    }
}