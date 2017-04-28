using MasterDetail.Data;
using MasterDetail.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetail.Web.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Read(int OrderID)
        {
            using (var context = new NORTHWNDEntities())
            {
                var list = context.Order_Details.Where(a => a.OrderID == OrderID).ToList();

                var result = list.Select(p => new OrderDetailViewModel
                {
                    OrderID = p.OrderID,
                    ProductID = p.ProductID,
                    Discount = p.Discount,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice
                }).ToList();

                return Json(result);

            }
        }
    }
}