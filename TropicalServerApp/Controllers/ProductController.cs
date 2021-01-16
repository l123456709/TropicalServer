using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServerApp.Models;

namespace TropicalServerApp.Controllers
{
    public class ProductController : Controller
    {
        //public ActionResult Index() 
        //{
        //    using (TropicalServerEntitiesCustOrder db = new TropicalServerEntitiesCustOrder())
        //    {
        //        List<tblOrder> orders = db.tblOrders.ToList();
        //        List<tblCustomer> customers = db.tblCustomers.ToList();

        //        var customerorder = from o in orders
        //                            join c in customers on o.OrderCustomerNumber equals c.CustNumber into table1
        //                            from c in table1.ToList()
        //                            select new ViewModel
        //                            {
        //                                 order = o,
        //                                 customer = c
        //                            };
        //        return View(customerorder);
        //    }
        //}
        public ActionResult Orders()
        {
            TropicalServerEntitiesCustOrder db = new TropicalServerEntitiesCustOrder();
            List<tblOrder> list = db.tblOrders.AsEnumerable().Select(x => new tblOrder { OrderTrackingNumber = x.OrderTrackingNumber, OrderDate = x.OrderDate, OrderCustomerNumber = x.OrderCustomerNumber, OrderRouteNumber = x.OrderRouteNumber }).ToList();

            ViewBag.OrderList = list;
            return View();
        }

        //public ActionResult Search(string date, int id, string name, string user)
        /*[HttpPost]
        public ActionResult Search(int? datastring)
        {
            TropicalServerEntitiesCustOrder db = new TropicalServerEntitiesCustOrder();

            var query = db.tblOrders.Where(x => x.OrderCustomerNumber.ToString().Contains(datastring.ToString()));
        
            return View(query.ToList());
        }*/

        public ActionResult GetSearchingData(string SearchText)
        {
            TropicalServerEntitiesCustOrder db = new TropicalServerEntitiesCustOrder();

            List<tblOrder> OrderList = db.tblOrders.AsEnumerable().Where(x => x.OrderCustomerNumber.ToString().Contains(SearchText)).Select(x => new tblOrder { OrderCustomerNumber = x.OrderCustomerNumber}).ToList();
            return PartialView("Search", OrderList);
        }

        //hearder: Logout, click to redirect to Login page
        public ActionResult Logout()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Routes()
        {
            return View();
        }

        public ActionResult StopSEQN()
        {
            return View();
        }

        public ActionResult MessageCenter()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }
        
        public ActionResult Settings()
        {
            return View();
        }
    }
}