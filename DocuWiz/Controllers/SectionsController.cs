using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocuWiz.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using DocuWiz.ViewModels;

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

            //var sections = _context.Sections.Include(s => s.Header).ToList();

            //return View(sections);

            return View();
        }

        public ActionResult Details(int id)
        {
            var section = _context.Sections.SingleOrDefault(s => s.Id == id);
            if (section == null)
                return HttpNotFound();

            return View(section);
        }

        public ActionResult New()
        {

            var headers = _context.Headers.ToList();
            var viewModel = new SectionFormViewModel
            {
                Header = headers,
                Section = new Section()
            };


            return View("SectionForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Section section)
        {

            if (!ModelState.IsValid)
            {
                var headers = _context.Headers.ToList();
                var viewModel = new SectionFormViewModel
                {
                    Header =headers,
                    Section = section
                };
                return View("SectionForm", viewModel);
            };

            if (section.Id == 0)
            {
                _context.Sections.Add(section);
            }
            else
            {
                var sectionInDb = _context.Sections.Single(s => s.Id == section.Id);

                sectionInDb.Name = section.Name;
                sectionInDb.Memo = section.Memo;
                sectionInDb.HeaderId = section.HeaderId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Sections");

        }
        public ActionResult Edit(int id)
        {
            var section = _context.Sections.Single(s => s.Id == id);

            if (section == null)
                return HttpNotFound();


            var viewModel = new SectionFormViewModel
            {
                Section = section,
                Header = _context.Headers.ToList()
            };

            return View("SectionForm",viewModel);
        }
    }
}