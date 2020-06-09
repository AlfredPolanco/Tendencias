using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Xml.Linq;
using System.Xml.Schema;

namespace KataRange
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] separator = { "[", "(", ",", ")", "]", "{", "}" };
            var range = new Range();

            //[2,7) contains {3,5}
            var containerZero = range.ContainsRange("[2,7)", "[3,5]");
            Console.WriteLine(containerZero);
            //[2,6) contains {6,6}
            var containerOne = range.ContainsRange("[2,7)", "{6,6}");
            Console.WriteLine(containerOne);
            //[2,4) doesn’t contain {7, 1 ,5}
            var containerTwo = range.ContainsRange("[2,4)", "{7,1,5}");
            Console.WriteLine(containerTwo);
            //[2,4) doesn’t contain [10,-2,3)
            var containerThree = range.ContainsRange("[2,4)", "{10,-2,7}");
            Console.WriteLine(containerThree);


            //[5,11] endPoints = [5,11]
            var endPointOne = range.endPoints("[5,11]");
            Console.WriteLine("[5,11] endPoints = [5,11]:");
            foreach (var num in endPointOne)
            {
                Console.Write(num + " ");
            }
            //[5,11] endPoints = [7,10]
            var endPointTwo = range.endPoints("[5,11]");
            Console.WriteLine("");
            Console.WriteLine("[5,11] endPoints = [7,10]:");
            foreach (var num in endPointTwo)
            {
                Console.Write(num + " ");
            }

            //[2,10) allPoints = {23456789}
            var allPoints = range.getAllPoints("[2,10)");
            Console.WriteLine("");
            Console.WriteLine("[2,10) allPoints = {2,10}:");
            foreach (var num in allPoints)
            Console.Write(num + " ");

            //[2,20) allPoints = {23456789}
            var allPointsOne = range.getAllPoints("[2,20)");
            Console.WriteLine("");
            Console.WriteLine("[2,20) allPoints = {2,20}:");
            foreach (var num in allPointsOne)
                Console.Write(num + " ");

            //[2,10) overlapsRange[1,8)
            var overlapsRange = range.overlapsRange("[2,10)","[1,8)");
            Console.WriteLine("");
            Console.WriteLine("[2,10) overlasRange = [1,8)");
            Console.WriteLine(overlapsRange);

            //[2,10) overlapsRange[1,5)
            var overlapsRangeOne = range.overlapsRange("[2,10)", "[7,5)");
            Console.WriteLine("");
            Console.WriteLine("[2,10) overlasRange = [1,5)");
            Console.WriteLine(overlapsRange);

            //[5,11) Equals [5,11)
            var equalsRange = range.equals("[5,11)", "[5,11)");
            Console.WriteLine("");
            Console.WriteLine("[5,11) equals = [5,11)");
            Console.WriteLine(equalsRange);

            //[5,11) Equals [5,11)
            var equalsRangeOne = range.equals("[5,11]", "[5,11]");
            Console.WriteLine("");
            Console.WriteLine("[5,11] equals = [5,11]");
            Console.WriteLine(equalsRange);

            //[10,25] notEquals [10,22]
            var notEquals = range.notEquals("[10,25]", "[10,22]");
            Console.WriteLine("");
            Console.WriteLine("[10,25] notEquals = [10,25]");
            Console.WriteLine(notEquals);

            //[10,25] notEquals [10,22]
            var notEqualsOne = range.notEquals("[10,25]", "[10,25)");
            Console.WriteLine("");
            Console.WriteLine("[10,25] notEquals = [10,25)");
            Console.WriteLine(notEquals);

        }

    }
}
