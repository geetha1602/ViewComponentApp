using Microsoft.AspNetCore.Mvc;
using ViewComponentsWebApp.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;

namespace ViewComponentsWebApp.Controllers
{

    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        
        //public IActionResult Index(FormCollection form)
        //{
        //    string name = form["Name"];
        //    string country = form["Country"];
        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(CommentsViewModel co, IFormCollection form)
        {
            Int32 name = Convert.ToInt32(form["CommentCount"]);
            string country = form["Content"];
            @TempData["CommentCount"] = co.CommentCount;
            @TempData["Content"] = co.Content;

            return View();
        }

        
        int increment = 0;
        [HttpPost]
        public IActionResult Count(string count, CommentsViewModel co, IFormCollection form)
        {
            string country = form["Content"];
            string clickCount = form["ClicksCount"];
            if (clickCount == "")
            {
                increment = +1;
                @TempData["CommentCount"] = increment;
            }
            else
            {
                int m = Int32.Parse(clickCount);
                if (m > 0)
                {
                    m++;
                    @TempData["CommentCount"] = m;
                }
            }
            TempData.Keep();
            @TempData["Content"] = co.Content;

            //
            List<CommentsViewModel> listuser = new List<CommentsViewModel>();
            CommentsViewModel users = new CommentsViewModel();
            users.Content = country;
            listuser.Add(users);
            TempData["ContentList"] = JsonConvert.SerializeObject(listuser);
            return RedirectToAction("Index");
        }
    }
}
