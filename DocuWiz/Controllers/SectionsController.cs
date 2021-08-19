using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocuWiz.Models;

namespace DocuWiz.Controllers
{
    public class SectionsController : Controller
    {

        private ApplicationDbContext _context;

        public SectionsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Sections
        public ViewResult Index()
        {

            var sections = _context.Sections.ToList(); 

            return View(sections);
        }

        public ActionResult Details(int id)
        {
            var section = _context.Sections.SingleOrDefault(s => s.Id == id);
            if (section == null)
                return HttpNotFound();

            return View(section);
        }


    }
}