using Functions.Listing3._7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Listing3._7.Entities
{
    public class WikiPage : IWikiPage
    {
        public PageData GetData()
        {
            throw new NotImplementedException();
        }

        public PageCrawler GetPageCrawler()
        {
            throw new NotImplementedException();
        }
    }
}
