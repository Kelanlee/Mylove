using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DataContract;
using MyLove.Models;
using Servers;
using Servers.Interface;

namespace MyLove.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult LogOut()
        {
            Session.Clear();
            return Redirect("~/Login/Index");
        }

        public ActionResult Home()
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() == "")
                return Redirect("~/Login/Index");
            IHomeServers homeServers=new HomeServers();
            var result=homeServers.GetTracking((int) user);
            return View("HomePage",GetTrackingsList(result));
        }

        public List<Tracking> GetTrackingsList(List<TrackingData> trackingDatas)
        {
            List<Tracking> result=new List<Tracking>();
            if (trackingDatas.Any())
            {
                foreach (TrackingData trackingData in trackingDatas)
                {
                    result.Add(new Tracking() { TrackingName = trackingData.TrackingName, TrackingTime = trackingData.TrackingTime });
                }
            }
            return result;
        }

        public ActionResult Choose()
        {
            var user = Session["userId"] ?? ""; 
            if (user.ToString() == "")
                return Redirect("~/Login/Index");
            IChooseServers chooseServers=new ChooseServers();
            IList<LocationData> locationList=chooseServers.GetLocations((int)user);


            return View("ChoosePage",GetLocationList(locationList));
        }

        public ActionResult DeleteLocation(int Id)
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() == "")
                return Redirect("~/Login/Index");
            IChooseServers chooseServers = new ChooseServers();
            chooseServers.DeleteLocation(Id);
            return RedirectToAction("Choose");
        }

        [HttpPost]
        public ActionResult AddALocation(string AddressName)
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() == "")
                return Redirect("~/Login/Index");
            IChooseServers chooseServers = new ChooseServers();
            chooseServers.AddALocation((int) user, AddressName);
            return RedirectToAction("Choose");
        }

        public List<Location> GetLocationList(IList<LocationData> locationList)
        {
            List<Location> locations=new List<Location>();

            foreach (var location in locationList)
            {
                locations.Add(new Location(){Id = location.Id,AddressName = location.AddressName});
            }

            return locations;
        }

        public ActionResult Wish()
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() == "")
                return Redirect("~/Login/Index");
            IWishServers wishServers = new WishServers();
            var wishlist = wishServers.GetMyWishList((int)user);
            return View("WishPage", GetWishList(wishlist));

        }
        [HttpPost]
        public ActionResult MakeAWish(string wishTitle,string wishContext)
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() == "")
                return Redirect("~/Login/Index");

            IWishServers wishServers=new WishServers();
            wishServers.MakeAWish((int) user, wishContext, wishTitle);

            return Redirect("~/Home/Wish");
        }

        public ActionResult Review()
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() == "")
                return Redirect("~/Login/Index");

            IWishServers wishServers=new WishServers();
            var wishlist=wishServers.GetLoverWishesList((int) user);
            
            return View("ReviewPage",GetWishList(wishlist));
        }

        public List<Wish> GetWishList(List<WishData> wishDatas  )
        {
            List<Wish> Wishes=new List<Wish>();

            foreach (WishData wishData in wishDatas)
            {
                Wishes.Add(new Wish(){WishId = wishData.WishId,Wishcontext = wishData.Wishcontext,WishState = wishData.WishState,WishTitle = wishData.WishTitle,ApprovalTime = wishData.ApprovalTime,WishTime = wishData.WishTime});
            }

            return Wishes;
        }
        [HttpPost]
        public ActionResult ApproveWish(int WishId)
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() == "")
                return Redirect("~/Login/Index");

            IWishServers wishServers = new WishServers();
            wishServers.ApproveAWish((int)WishId);
            var wishlist = wishServers.GetLoverWishesList((int)user);

            return View("ReviewPage", GetWishList(wishlist));
        }
    }
}
