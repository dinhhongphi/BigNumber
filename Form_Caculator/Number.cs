using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_Caculator
{
    public class Number
    {
        private string stringNumber;
        private int posCurr = 0;
        public Number(string input)
        {
            stringNumber = input;
        }

        //get next string number
        public string Next()
        {
            if (posCurr >= stringNumber.Length)
                return null;
            int temp = posCurr;
            while(posCurr < stringNumber.Length)
            {
                if (stringNumber[posCurr].Equals('+'))
                    break;
                posCurr++;
            }
            //find plus sign next
            posCurr++;
            return stringNumber.Substring(temp, posCurr - temp - 1).Trim();
        }

    }
}
