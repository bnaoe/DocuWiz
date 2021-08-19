using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocuWiz.Models
{
    public class Section
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Memo { get; set; }

        public Header Header { get; set; }

        public int HeaderId { get; set; }


    }
}