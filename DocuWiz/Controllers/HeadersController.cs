using DocuWiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocuWiz.ViewModels;


namespace DocuWiz.Controllers
{
    public class HeadersController : Controller
    {
        private ApplicationDbContext _context;

        public HeadersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Headers
        public ViewResult Index()
        {

            var headers = _context.Headers.ToList();


            return View(headers);
        }

        public ActionResult Details(int id)
        {
            var header = _context.Headers.SingleOrDefault(h => h.Id == id);
            if (header == null)
                return HttpNotFound();

            return View(header);
        }

        public ActionResult HeaderToSectionIndex(int id)
        {
            var sections = _context.Sections.Where(s => s.HeaderId == id).ToList();

            return View(sections);
        }

        public ActionResult New()
        {

            var viewModel = new HeaderFormViewModel();

            return View("HeaderForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Header header)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new HeaderFormViewModel
                {
                    Header = header
                };
                return View("HeaderForm", viewModel);
            } ;

            if(header.Id ==0)
            {
                _context.Headers.Add(header);
            }
            else
            {
                var headerInDb = _context.Headers.Single(h => h.Id == header.Id);

                headerInDb.Name = header.Name;
                headerInDb.Description = header.Description;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Headers");
        }

        public ActionResult Edit(int id)
        {
            var header = _context.Headers.SingleOrDefault(h => h.Id == id);

            if (header == null)
                return HttpNotFound();

            var viewModel = new HeaderFormViewModel
            {
                Header = header
            };
            return View("HeaderForm",viewModel);
        }
    }
}