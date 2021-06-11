using Functions._03.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions._03
{
    public class ErrorHandling
    {
        private readonly IRegistry _regstry;
        private readonly IConfigKey _configKey;
        public ErrorHandling(IRegistry registry
            , IConfigKey configKey)
        {
            _regstry = registry;
            _configKey = configKey;
        }
        public void Delete (Page page)
        {
            try
            {
                DeletePageAndAllReferences(page);
            }
            catch (Exception ex)
            {

                LogError(ex);
            }
        }

        public void DeletePageAndAllReferences(Page page)
        {
            DeletePage(page);
            _regstry.DeleteReference(page.Name);
            _configKey.DeleteKey(page.Name.MakeKey());
        }

        public void DeletePage(Page page)
        {

        }

        private void LogError(Exception ex)
        {
            //logger.log(e.Message);
        }
    }
}
