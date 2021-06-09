using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaingfulContext
{
    public class Wrong
    {
        private void PrintGuessStatistics(char candidate, int count)
        {
            string number;
            string verb;
            string pluralModifier;
            if(count == 0)
            {
                number = "no";
                verb = "are";
                pluralModifier = "s";
            }
            else if (count == 1)
            {
                number = "1";
                verb = "is";
                pluralModifier = "";
            }
            else
            {
                number = count.ToString();
                verb = "are";
                pluralModifier = "s";
            }
            var guessMessage = $"There {verb} {number} {candidate}{pluralModifier}";
            Console.WriteLine(guessMessage);
        }
    }
}
