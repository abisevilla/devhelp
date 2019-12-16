using DevHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevHelp.Repository;
namespace DevHelp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}

        IChat IChat;

        public LoginController()
        {
            this.IChat = new ChatRepository(new ChatEntities());

        }

        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {

                ChatEntities db = new ChatEntities();
                var user = (from userlist in db.Users
                            where userlist.NickName == login.UserName && userlist.Password == login.Password
                            select new
                            {
                                userlist.Id,
                                userlist.NickName,
                                userlist.Role
                            }).ToList();
                var result = IChat.GetRooms();


                if (user.FirstOrDefault() != null && user.FirstOrDefault().Role!="Admin")
                {
                    Session["UserName"] = user.FirstOrDefault().NickName;
                    Session["UserID"] = user.FirstOrDefault().Id;
                    return Redirect("/Home/Rooms");
                }
                else if(user.FirstOrDefault() != null && user.FirstOrDefault().Role == "Admin")
                {
                    Session["UserName"] = user.FirstOrDefault().NickName;
                    Session["UserID"] = user.FirstOrDefault().Id;
                    return Redirect("/Home/Admin");
                   
                }
                else
                {
                    ModelState.AddModelError("", "login credenciales Invalidas.");
                }
            }
            return View(login);
        }


    }
}