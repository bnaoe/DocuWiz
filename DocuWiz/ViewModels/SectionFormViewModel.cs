using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocuWiz.Models;

namespace DocuWiz.ViewModels
{
    public class SectionFormViewModel
    {
        public IEnumerable<Header> Header { get; set; }
        public Section Section { get; set; }
    }
}