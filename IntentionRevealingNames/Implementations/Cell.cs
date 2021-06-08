using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntentionRevealingNames.Interfaces;

namespace IntentionRevealingNames.Implementations
{
    
    public class Cell:List<int>,ICell
    {
        private const int STATUS_VALUE= 0;
        private const int FLAGGED = 4;

        public bool IsFlagged()
        {
            return base[STATUS_VALUE] == FLAGGED;
        }

    }
}
