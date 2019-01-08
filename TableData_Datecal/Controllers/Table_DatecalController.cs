using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableData_Datecal.Models;

namespace TableData_Datecal.Controllers
{
    public class Table_DatecalController : Controller
    {
        // GET: Table_Datecal
        public TableEntities db = new TableEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.TableDatas.ToList();
            ViewBag.displaydata = data;
            return View(data);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "First_Date,Second_Date,Result")] TableData datecal)
        {
            if (ModelState.IsValid)
            {

                string a = datecal.First_Date;

                int y1 = Convert.ToInt32(a.Split('-')[0]);
                int m1 = Convert.ToInt32(a.Split('-')[1]);
                int d1 = Convert.ToInt32(a.Split('-')[2]);
                string b = datecal.Second_Date;
                int y2 = Convert.ToInt32(b.Split('-')[0]);
                int m2 = Convert.ToInt32(b.Split('-')[1]);
                int d2 = Convert.ToInt32(b.Split('-')[2]);
                TableData dt1 = new TableData
                {
                    y = y1,
                    m = m1,
                    d = d1

                };
                TableData dt2 = new TableData
                {
                    y = y2,
                    m = m2,
                    d = d2

                };
                TableData dt = new TableData();

                int Result = dt.getDifference(dt1, dt2);

                dt.First_Date = a;
                dt.Second_Date = b;
                dt.Result = Result.ToString();
                ViewBag.Result = dt.Result;
                db.TableDatas.Add(dt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datecal);


        }
         

        }
       
    }
