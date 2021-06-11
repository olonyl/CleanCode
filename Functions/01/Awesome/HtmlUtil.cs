using Functions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Awesome
{
    public class HtmlUtil: HtmlUtilBase
    {
        public  string RenderPageWithSetupsAndTeardowns(PageData pageData, bool isSuite)
        {
            if (pageData.IsTestPage())
                IncludeSetupAndTeardownPages(pageData, isSuite);
            return pageData.Html;
        }
    }
}
