using DevHelp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevHelp.Models;
namespace DevHelp.Controllers
{
    public class HomeController : Controller
    {
        IChat IChat;

        public HomeController()
        {
            this.IChat = new ChatRepository(new ChatEntities());
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Rooms()
        {

            var result = IChat.GetRooms();
            return View(result);
        }

        public ActionResult Admin()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}