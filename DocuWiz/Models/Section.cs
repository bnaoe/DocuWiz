﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocuWiz.Models
{
    public class Section
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        public string Memo { get; set; }

        
        public Header Header { get; set; }
        
        [Required]
        public int HeaderId { get; set; }


    }
}