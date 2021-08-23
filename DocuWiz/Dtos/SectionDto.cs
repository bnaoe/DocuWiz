using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DocuWiz.Models;

namespace DocuWiz.Dtos
{
    public class SectionDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Memo { get; set; }

        [Required]
        public int HeaderId { get; set; }

        public HeaderTypeDto Header { get; set; }
    }

}