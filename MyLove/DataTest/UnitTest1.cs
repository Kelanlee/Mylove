using System;
using System.Linq;
using System.Security.Policy;
using Data.Models;
using Data.Repository;
using Data.Repository.Implement;
using Data.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DataTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var db= new MyLoveContext();
            var user = db.Users.Where(m => m.Username == "kelanlee");
            Assert.True(user.Any(),user.Count().ToString());
        }

        [Test]
        public void TestMethod2()
        {
            IUserRepository iur=new UserRepository();

            var u = iur.getUserByUsername("zhu");

            Assert.True(u.Username=="zhu");
        }

        [Test]
        public void TestMethod3()
        {
            IMembershipRepository imr = new MembershipRepository();

            var u = imr.ValidatePassword(1,"111111");

            Assert.True(u);
        }

        [Test]
        public void TestMethod4()
        {
            IUserRepository iur = new UserRepository();

            var u = iur.getUserByUsername("zhu");
            IWishRepository imr = new WishRepository();

            Wish wish=new Wish(){UserId = 1,Wishcontent = "没啥",WishStateId = 1};
            var w = imr.AddOrUpdateAWish(wish);
            Assert.True(w);
        }

        [Test]
        public void TestMethod5()
        {
            ILocationRepository ilr = new LocationRepository();

            var u = ilr.GetLocations(1);

            
            
            Assert.True(u.Count>0);
        }
    }
}
