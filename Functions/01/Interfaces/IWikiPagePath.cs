using Functions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Interfaces
{
    public interface IWikiPagePath
    {
        WikiPagePath GetFullPath(WikiPage suiteSetup);
    }
}
