using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DocuWiz.Dtos;
using DocuWiz.Models;

namespace DocuWiz.Controllers.API
{
    public class HeadersController : ApiController
    {
        private ApplicationDbContext _context;

        public HeadersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetHeaders()
        {
            //return _context.Headers.ToList().Select(Mapper.Map<Header, HeaderDto>);

            var headerDtos = _context.Headers
                .ToList()
                .Select(Mapper.Map<Header, HeaderDto>);

            return Ok(headerDtos);
        }

        public IHttpActionResult GetHeader(int id)
        {
            var header = _context.Headers.SingleOrDefault(h => h.Id == id);

            if (header == null)
                return NotFound();

            return Ok(Mapper.Map<Header, HeaderDto>(header));
        }
        [HttpPost]
        public IHttpActionResult CreateHeader(HeaderDto headerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var header = Mapper.Map<HeaderDto, Header>(headerDto);
            _context.Headers.Add(header);
            _context.SaveChanges();

            headerDto.Id = header.Id;

            return Created(new Uri(Request.RequestUri+"/"+header.Id),headerDto);

        }

        [HttpPut]
        public void UpdateHeader(int id, HeaderDto headerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var headerInDb = _context.Headers.SingleOrDefault(h => h.Id == id);

            if (headerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(headerDto, headerInDb);


            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteHeader(int id)
        {
            var headerInDb = _context.Headers.SingleOrDefault(h => h.Id == id);

            if (headerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Headers.Remove(headerInDb);
            _context.SaveChanges();
        }


    }
}
