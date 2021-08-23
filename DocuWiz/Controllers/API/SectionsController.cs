using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DocuWiz.Dtos;
using DocuWiz.Models;
using System.Data.Entity;


namespace DocuWiz.Controllers.API
{
    public class SectionsController : ApiController
    {
        private ApplicationDbContext _context;

        public SectionsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetSections()
        {
            //return _context.Sections.ToList().Select(Mapper.Map<Section, SectionDto>);

            var sectionDtos = _context.Sections
                .Include(s=>s.Header)
                .ToList()
                .Select(Mapper.Map<Section, SectionDto>);

            return Ok(sectionDtos);
        }

        public IHttpActionResult GetSection(int id)
        {
            var section = _context.Sections.SingleOrDefault(s => s.Id == id);

            if (section == null)
                return NotFound();

            return Ok(Mapper.Map<Section, SectionDto>(section));
        }

        [HttpPost]
        public IHttpActionResult CreateSection(SectionDto sectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var section = Mapper.Map<SectionDto, Section>(sectionDto);
            _context.Sections.Add(section);
            _context.SaveChanges();

            sectionDto.Id = section.Id;

            return Created(new Uri(Request.RequestUri + "/" + section.Id), sectionDto);
            
        }

        [HttpPut]
        public void UpdateSection(int id, SectionDto sectionDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var sectionInDb = _context.Sections.SingleOrDefault(s => s.Id == id);

            if (sectionInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(sectionDto, sectionInDb);
            
            _context.SaveChanges();
            
        }

        public void DeleteSection(int id)
        {
            var sectionInDb = _context.Headers.SingleOrDefault(s => s.Id == id);

            if (sectionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Headers.Remove(sectionInDb);
            _context.SaveChanges();
        }


    }
}
