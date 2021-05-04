using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class NationalityController : Controller
    {
        // GET: Nationality
        public ActionResult Index()
        {
            List<NationalityVM> nationalitiesVM = new List<NationalityVM>();

            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach(var item in service.GetNationalities())
                {
                    nationalitiesVM.Add(new NationalityVM(item));
                }
            }
            return View(nationalitiesVM);
        }

        public ActionResult Create(NationalityVM nationalityVM)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        NationalityDTO nationalityDTO = new NationalityDTO
                        {
                            Title = nationalityVM.Title
                        };
                        service.PostNationality(nationalityDTO);

                        return RedirectToAction("Index");
                    }
                    
                }
                return View();
            }
            catch
            {
                return View();
            }
            
        }

        public ActionResult Delete(int id)
        {
            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteNationality(id);
            }
            return RedirectToAction("Index");
        }
    }
}