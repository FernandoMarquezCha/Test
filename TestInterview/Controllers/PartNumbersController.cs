using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInterview.Models;
using System.Data.SqlClient;

namespace TestInterview.Controllers
{
    public class PartNumbersController : Controller
    {
        // GET: PartNumbers
        List<PartNumbersCLS> list;
        public ActionResult Index()
        {

            using (var bd = new CarlosMárquezEntities())
            {
                list = (from item in bd.PartNumbers
                        join customers in bd.Customers
                        on item.FKCustomer equals customers.PKCustomers
                        where item.Avaliable == true
                        select new PartNumbersCLS
                        {
                            pkpartnumber = item.PKPartNumber,
                            partnumber = item.PartNumber,
                            customer = (int)item.FKCustomer,
                            avaliable = (bool)item.Avaliable,
                            customername = customers.Customer
                        }).ToList();

            }
            return View(list);
        }

        public void combocustomers()
        {
            List<SelectListItem> combocustomers;
            using (var bd = new CarlosMárquezEntities())
            {
                combocustomers = (from item in bd.Customers
                                  where item.Avaliable == true
                                  select new SelectListItem
                                  {
                                      Text = item.Customer,
                                      Value = item.PKCustomers.ToString()

                                  }
                                  ).ToList();
                combocustomers.Insert(0, new SelectListItem { Text = "-Seleccione un valor-", Value = "" });
                ViewBag.combocustomers = combocustomers;
            }
        }

       
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: PartNumbers/Create
        public ActionResult Create()
        {
            combocustomers();
            return View();
        }

        // POST: PartNumbers/Create
        [HttpPost]
        public ActionResult Create(PartNumbersCLS oPartNumberCLS)
        {
            try
            {
                SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-RMEO4RQ;Initial Catalog=CarlosMárquez;Integrated Security=True");
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Add_PartNumbers", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNumber", System.Data.SqlDbType.VarChar).Value = oPartNumberCLS.partnumber;
                cmd.Parameters.Add("@FKCustomer", System.Data.SqlDbType.VarChar).Value = oPartNumberCLS.customer;
                cmd.Parameters.Add("@Avaliable", System.Data.SqlDbType.Int).Value = oPartNumberCLS.avaliable;
                cmd.ExecuteNonQuery();



                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: PartNumbers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PartNumbers/Edit/5
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

        // GET: PartNumbers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PartNumbers/Delete/5
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
