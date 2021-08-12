using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInterview.Models;
using System.Data.SqlClient;

namespace TestInterview.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        List<CustomersClS> list;
        public ActionResult Index()
        {
            using (var bd = new CarlosMárquezEntities())
            {
                list = (from item in bd.Customers
                        join building in bd.Buildings
                        on item.FKBuildings equals building.PKBuilding
                        where item.Avaliable == true
                        select new CustomersClS
                        {
                            pkcustomers = item.PKCustomers,
                            customer = item.Customer,
                            prefix = item.Prefix,
                            building = (int)item.FKBuildings,
                            avaliable = (bool)item.Avaliable
                        }).ToList();
            }
                return View(list);
        }

        public void combobuilding()
        {
            List<SelectListItem> combobuilding;
            using (var bd = new CarlosMárquezEntities())
            {
                combobuilding = (from item in bd.Buildings
                                 where item.Avaliable == true
                                 select new SelectListItem
                                 {
                                     Text = item.Building,
                                     Value = item.PKBuilding.ToString()
                                 }).ToList();
                combobuilding.Insert(0, new SelectListItem { Text = "-Seleccione un valor-", Value = "" });
                ViewBag.combobuilding = combobuilding;
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CustomersClS oCustomersCLS)
        {
            
            try
            {
                SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-RMEO4RQ;Initial Catalog=CarlosMárquez;Integrated Security=True");
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Add_Customer", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Customer", System.Data.SqlDbType.VarChar).Value = oCustomersCLS.customer;
                cmd.Parameters.Add("@PREFIX", System.Data.SqlDbType.VarChar).Value = oCustomersCLS.prefix;
                cmd.Parameters.Add("@FKBuilding", System.Data.SqlDbType.Int).Value = oCustomersCLS.building;
                cmd.Parameters.Add("@Avaliable", System.Data.SqlDbType.Bit).Value = oCustomersCLS.avaliable;
                cmd.ExecuteNonQuery();


                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        public ActionResult Create()
        {
            combobuilding();
            return View();
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
