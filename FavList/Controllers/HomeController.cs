using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FavList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
        //this will take care of the action:
        // /Home/AddToFaveList?Name=songname
        public ActionResult AddToFavList(string Name)//should always be the same as the action name in the html file (ex: "/Home/-->>AddToFavList<-----(this part)?Name=)
        {
            //setup the seassion first
            if(Session["FavList"] == null)
            {
                Session.Add("FavList", new List<string>());

            }
            //fetch the list from the session

            List<string> FavList = (List<string>)Session["FavList"];//cast it because things are being stored as objects before being casted and that won't work


            if(!FavList.Contains(Name))
            {
                FavList.Add(Name);
            }
            //save list back in session
            Session["FavList"] = FavList;

            ViewBag.FavList = FavList;//sending the favlist to the view

            return View("About");

        }

        public ActionResult ClearFavList()
        {
            if (Session["FavList"] != null)
            {
                ((List<string>)Session["FavList"]).Clear();
            }
            return View("About");
        }
    }
}