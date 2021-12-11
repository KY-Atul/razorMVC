using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using razorMVC.Models;
using System.Data.Entity;
                                                                

namespace razorMVC.Controllers
{
    public class stuController : Controller
    {
        razorEntities obj = new razorEntities();
        //DbContext obj = new DbContext();
        [HttpGet]
        public ActionResult Ins(int id = 0) 
        {
            student c = new student();
            ViewBag.btn_name = "Submit";
            ViewBag.ctr = obj.countries.ToList();
            if (id > 0)
            {
                var data = (from a in obj.students where a.sid == id select a).ToList();

                c.sid = data[0].sid;
                c.name = data[0].name;
                c.age = data[0].age;
                c.country = data[0].country;
                c.state = data[0].state;
                ViewBag.btn_name = "Update";
            }
            ViewBag.sta = (from a in obj.states where a.cntry_id == c.country select a);
                return View(c);
            
        }


        [HttpPost]
        public ActionResult Ins(student c)
        {
            if (c.sid > 0)
            {
                obj.Entry(c).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                obj.students.Add(c);
            }

                obj.SaveChanges();
                return RedirectToAction("Dis"); 
        }


        public ActionResult Dis()
        {
            var data = (from a in obj.students join
                        b in obj.countries on a.country equals b.cid join
                        c in obj.states on a.state equals c.stid
                        select new StudentJoin
                        {
                            sid= a.sid,
                            name = a.name,
                            age = a.age,
                            country = a.country,
                            ctr_name = b.cname,
                            state_name = c.sname
                        }).ToList();
            return View(data);
        }

        public ActionResult Del(int id)
        {
            var data = obj.students.Find(id);
            obj.students.Remove(data);
            obj.SaveChanges();
            return RedirectToAction("Dis");
        }


        public JsonResult getState(int A)
        {
            var data = (from a in obj.states where a.cntry_id == A select a).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

    }
}