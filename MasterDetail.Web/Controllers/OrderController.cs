using MasterDetail.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetail.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order model)
        {
            if (!ModelState.IsValid)
                return View();

            using (var context = new NORTHWNDEntities())
            {
                context.Orders.Add(model);
                context.SaveChanges();
                return RedirectToAction("Edit", new { id = ListOrders().Select(a => a.OrderID).Max() });
            }
            
        }


       
        public ActionResult Edit(int OrderID)
        {
            using (var context = new NORTHWNDEntities())
            {
                var order = context.Orders.Where(a => a.OrderID == OrderID).FirstOrDefault();
                return View(order);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order model)
        {
            if (!ModelState.IsValid)
                return View();

            using (var context = new NORTHWNDEntities())
            {
                context.Orders.Attach(model);
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Edit", new { id = model.OrderID });
        }

        public IList<Order> ListOrders()
        {
            using (var context = new NORTHWNDEntities())
            {
                var list = context.Orders.ToList();
                return list;
            }
        }
    }
}