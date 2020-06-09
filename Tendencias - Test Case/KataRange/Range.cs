using System;
using System.Collections.Generic;
using System.Text;

namespace KataRange
{
    class Range
    {
        public string[] separator = { "[", "(", ",", ")", "]", "{", "}" };
        public bool ContainsRange(string range, string containedRange)
        {
            string[] arrRange = range.Split(this.separator,
                                            StringSplitOptions.RemoveEmptyEntries);
            string[] arrContainedRange = containedRange.Split(this.separator,
                                                            StringSplitOptions.RemoveEmptyEntries);

            if (range.Contains(')'))
            {
                arrRange[arrRange.Length - 1] = (Convert.ToInt32(arrRange[arrRange.Length - 1]) - 1).ToString();
            }
            for (int i = 0; i < arrRange.Length; i++)
            {
                for (int j = 0; j < arrContainedRange.Length; j++)
                {
                    if (i == 0)
                    {
                        if (Convert.ToInt32(arrRange[i]) <= Convert.ToInt32(arrContainedRange[j]))
                            continue;

                    }
                    else
                    {
                        if (Convert.ToInt32(arrRange[i]) >= Convert.ToInt32(arrContainedRange[j]))
                            if (j == arrContainedRange.Length - 1 && i == arrRange.Length - 1)
                                return true;
                    }
                }
            }
            return false; // If range does not contain containedRange
        }

        public int[] getAllPoints(string range)
        {
            string[] arrRange = range.Split(this.separator,
                                                      StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[Convert.ToInt32(arrRange[arrRange.Length - 1]) - Convert.ToInt32(arrRange[0])];

            if (range.Contains("("))
                arrRange[0] = (Convert.ToInt32(arrRange[0]) + 1).ToString();
            if (range.Contains(")"))
                arrRange[arrRange.Length - 1] = (Convert.ToInt32(arrRange[arrRange.Length - 1]) - 1).ToString();


            for (int i = Convert.ToInt32(arrRange[0]), j = 0; i <= Convert.ToInt32(arrRange[arrRange.Length - 1]); i++)
            {
                arr[j] = i;
                j++;
            }

            return arr;
        }

        public string[] endPoints(string range)
        {
            string[] arrRange = range.Split(this.separator,
                                                   StringSplitOptions.RemoveEmptyEntries);

            if (range.Contains("("))
                arrRange[0] = (Convert.ToInt32(arrRange[0]) + 1).ToString();
            if (range.Contains(")"))
                arrRange[arrRange.Length - 1] = (Convert.ToInt32(arrRange[arrRange.Length - 1]) - 1).ToString();

            return arrRange;
        }

        public bool overlapsRange(string range, string comparedRange)
        {

            string[] arrRange = range.Split(this.separator,
                                                   StringSplitOptions.RemoveEmptyEntries);

            foreach (var num in comparedRange)
            {
                if (range.Contains(num))
                {
                    return true;
                }
            }
            return false;

        }

        public bool equals(string range, string compared)
        {

            string[] arrRange = range.Split(this.separator,
                                                   StringSplitOptions.RemoveEmptyEntries);
            if(range == compared)
            {
                return true;
            }
            return false;
           
        }

        public bool notequals(string range, string compared)
        {

            string[] arrRange = range.Split(this.separator,
                                                   StringSplitOptions.RemoveEmptyEntries);
            if (range != compared)
            {
                return true;
            }
            return false;

        }

    }
}
