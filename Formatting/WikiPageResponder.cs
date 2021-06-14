using Formatting.Entities;
using Formatting.Handlers;
using Formatting.Interfaces;
using Functions.Listing3._7.Entities;
using Functions.Listing3._7.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting
{
    public class WikiPageResponder : ISecureResponder
    {
        protected WikiPage page;
        protected PageData pageData;
        protected string pageTitle;
        protected Request request;
        protected PageCrawler crawler;

        public Response Makeresponse(FitNesseContext context, Request request)
        {
            string pageName = GetPageNameOrDefault(request, "FrontPage");
            LoadPage(pageName, context);
            if (page == null)
                return NotFoundResponse(context, request);
            else
                return NotFoundResponse(context);
        }

        private string GetPageNameOrDefault(Request request, string defaultPageName)
        {
            string pageName = request.GetResource();
            if (String.IsNullOrEmpty(pageName))
                pageName = defaultPageName;
            return pageName;
        }

        protected void LoadPage(string resource, FitNesseContext context)
        {
            WikiPagePath path = PathParser.Parse(resource);
            crawler = context.Root.GetPageCrawler();
            crawler.SetDeadEndStrategy(new VirtualEnabledPageCrawler());
            page = crawler.GetPage(context.Root, path);
            if (page != null)
                pageData = page.GetData();
        }

        private Response NotFoundResponse(FitNesseContext context, Request request)
        {
            return new NotFoundResponder().MakeReponse(context, request);
        }
        private Response NotFoundResponse(FitNesseContext context)
        {
            return new NotFoundResponder().MakeReponse(context);
        }

        private SimpleResponse MakePageResponse(FitNesseContext context)
        {
            pageTitle = PathParser.Render(crawler.GetFullPath(page));
            string html = MakeHtml(context);
            SimpleResponse response = new SimpleResponse();
            response.MaxAge = 0;
            response.Content = html;
            return response;
        }
        private string MakeHtml(FitNesseContext context)
        {
            return String.Empty;
        }
    }
}
