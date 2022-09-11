using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoiceSageAssessment.Interface;
using VoiceSageAssessment.Models;
using VoiceSageAssessment.Repository;

namespace VoiceSageAssessment.Controllers
{
    public class HomeController : Controller
    {
        IGroupRepository repository;

        public HomeController()
        {
            repository = new GroupRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(repository.GetAllGroupDetails());
        }

       

        public ActionResult AddOrEdit(int grupId=0)
        {
            GroupDetail grup = new GroupDetail();

            if(grupId!=0)
            {
                grup = repository.GetGroup(grupId);
            }


            return View(grup);
        }

        [HttpPost]
        public ActionResult AddOrEdit(GroupDetail grup)
        {
            try
            {

            
            //if (!ModelState.IsValid) return View(grup);
            if (grup.GroupId == 0)
            {
                repository.InsertGroupDetails(grup);
            }
            else
            {
                repository.UpdateGroupDetails(grup);
            }


            return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", repository.GetAllGroupDetails()), message = "Submitted Successfully"  }, JsonRequestBehavior.AllowGet);
                // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult Delete(int grupId)
        {
            if (grupId != 0)
            {
                repository.DeleteGroup(grupId);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", repository.GetAllGroupDetails()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
                // return RedirectToAction("Index");
            }
            return Json(new { success = false, message = "error message" }, JsonRequestBehavior.AllowGet);
        }
     }
}