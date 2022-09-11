using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoiceSageAssessment.Interface;
using VoiceSageAssessment.Models;
using VoiceSageAssessment.Repository;

namespace VoiceSageAssessment.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository repository;

        public ContactController()
        {
            repository = new ContactRepository();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(repository.GetAllContactDetails());
        }


        public ActionResult AddOrEdit(int contactId = 0)
        {
            ContactDetail contact = new ContactDetail();

            if (contactId != 0)
            {
                contact = repository.GetContact(contactId);
            }


            return View(contact);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ContactDetail contact)
        {
            try
            {

                //if (!ModelState.IsValid) return View(contact);
                if (contact.columnId == 0)
                {
                    repository.InsertContactDetails(contact);
                }
                else
                {
                    repository.UpdateContactDetails(contact);
                    return RedirectToAction("Index"); ;
                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", repository.GetAllContactDetails()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
                // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult GetGroupName()
        {
            return Json(repository.GetAllGroupName(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int contactID)
        {
            if (contactID != 0)
            {
                repository.DeleteContact(contactID);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", repository.GetAllContactDetails()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
                // return RedirectToAction("Index");
            }
            return Json(new { success = false, message = "error message" }, JsonRequestBehavior.AllowGet);
        }
    }
       
}