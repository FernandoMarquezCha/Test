using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInterview.Models;

namespace TestInterview.Controllers
{
    public class ConsultaDinamicaController : Controller
    {
        // GET: ConsultaDinamica
        List<ConsultaDinamicaCLS> list;
        public ActionResult Index()
        {
            {

                using (var bd = new CarlosMárquezEntities1())
                {

                    {

                        list = (from item in bd.PartNumbers
                                join customer in bd.Customers
                                on item.FKCustomer equals customer.PKCustomers
                                join buildings in bd.Buildings
                                on customer.FKBuildings equals buildings.PKBuilding
                                where item.Avaliable == true & customer.Avaliable == true
                                

                                select new ConsultaDinamicaCLS
                                {
                                    partnumbers = item.PartNumber,
                                    customer = customer.Customer,
                                    building = buildings.Building

                                }).ToList();


                    }
                    return View(list);
                }
            }

        }
    }
}
        
     
   
    



        
        
    

