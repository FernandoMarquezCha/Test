using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInterview.Models;
using System.Data.SqlClient;

namespace TestInterview.Controllers
{
    public class BuildingsController : Controller
    {
        // GET: Buildings
        List<BuildingsCLS> list;
        public ActionResult Index()
        {

            using (var bd = new CarlosMárquezEntities())

                list = (from item in bd.Buildings
                        where item.Avaliable == true
                        select new BuildingsCLS
                        {
                            pkbuilding = item.PKBuilding,
                            building = item.Building,
                            avaliable = (bool)item.Avaliable

                        }).ToList();
            

                return View(list);
        }

        // GET: Buildings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Buildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        [HttpPost]
        public ActionResult Create(BuildingsCLS oBuildingsCLS)
        {
            try
            {
                SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-RMEO4RQ;Initial Catalog=CarlosMárquez;Integrated Security=True");
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Add_Building", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Building", System.Data.SqlDbType.VarChar).Value = oBuildingsCLS.building;
                cmd.Parameters.Add("@Avaliable", System.Data.SqlDbType.Bit).Value = oBuildingsCLS.avaliable;

                cmd.ExecuteNonQuery();

                return RedirectToAction ("Index");

            }
            catch
            {
                return View("Create");
            }

            
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Buildings/Edit/5
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

        // GET: Buildings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Buildings/Delete/5
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
