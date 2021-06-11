using Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Entities
{
    public class PageData : IPageData
    {
        public string Content { get; set; }
        public string Html { get; set; }

        public WikiPage GetWikiPage()
        {
            throw new NotImplementedException();
        }

        public bool IsTestPage()
        {
            throw new NotImplementedException();
        }
    }
}
