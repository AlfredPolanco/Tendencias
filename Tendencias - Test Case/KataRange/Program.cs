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
    /*

ContainsRange

[2,10) contains [3,5]

[3,5] contains [3,5)

endPoints
[2,6) endPoints = {2,5}

[2,6] endPoints = {2,6}

(2,6) endPoints = {3,5}

(2,6] endPoints = {3,6}

overlapsRange
[2,5) doesn’t overlap with [7,10)

[2,10) overlaps with [3,5)

[3,5) overlaps with [3,5)

[2,5) overlaps with [3,10)

[3,5) overlaps with [2,10)

Equals
[3,5) equals [3,5)

[2,10) neq [3,5)

[2,5) neq [3,10)

[3,5) neq [2,10)
*/

    class Program
    {
        static void Main(string[] args)
        {

            string[] separator = { "[", "(", ",", ")", "]", "{", "}" };
            var range = new Range();

            //[2,10) contains [3,5]
            var containerZero = range.ContainsRange("[2,10)", "[3,5]");
            Console.WriteLine(containerZero);
            //[2,6) contains {2,4}
            var containerOne = range.ContainsRange("[2,6)", "{2,4}");
            Console.WriteLine(containerOne);
            //[2,6) doesn’t contain {-1,1,6,10}
            var containerTwo = range.ContainsRange("[2,6)", "{-1,1,6,10}");
            Console.WriteLine(containerTwo);
            //[2,5) doesn’t contain [7,10)
            var containerThree = range.ContainsRange("[2,5)", "[7,10)");
            Console.WriteLine(containerThree);
            //[2,5) doesn’t contain [3,10)
            var containerFour = range.ContainsRange("[2,5)", "[3,10)");
            Console.WriteLine(containerFour);
            //[3,5) doesn’t contain [2,10)
            var containerFive = range.ContainsRange("[3,5)", "[2,10)");
            Console.WriteLine(containerFive);


            //[2,6) endPoints = {2,5}
            var endPointOne = range.endPoints("[2,6)");
            Console.WriteLine("[2,6) endPoints = {2,5}:");
            foreach (var num in endPointOne)
            {
                Console.Write(num + " ");
            }
            //[2,6] endPoints = {2,6}
            var endPointTwo = range.endPoints("[2,6]");
            Console.WriteLine("");
            Console.WriteLine("[2,6] endPoints = {2,6}:");
            foreach (var num in endPointTwo)
            {
                Console.Write(num + " ");
            }
            //(2,6) endPoints = {3,5}
            var endPointThree = range.endPoints("(2,6)");
            Console.WriteLine("");
            Console.WriteLine("(2,6) endPoints = {3,5}:");
            foreach (var num in endPointThree)
            {
                Console.Write(num + " ");
            }
            //(2,6] endPoints = {3,6}
            var endPointFour = range.endPoints("(2,6]");
            Console.WriteLine("");
            Console.WriteLine("(2,6] endPoints = {3,6}:");
            foreach (var num in endPointFour)
            {
                Console.Write(num + " ");
            }
            //[2,6) allPoints = {2,3,4,5}
            var allPoints = range.getAllPoints("[2,6)");
            Console.WriteLine("");
            Console.WriteLine("[2,6) allPoints = {2,3,4,5}:");
            foreach (var num in allPoints)
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
            var notEquals = range.notequals("[10,25]", "[10,22]");
            Console.WriteLine("");
            Console.WriteLine("[10,25] notEquals = [10,25]");
            Console.WriteLine(notEquals);

            //[10,25] notEquals [10,22]
            var notEqualsOne = range.notequals("[10,25]", "[10,25)");
            Console.WriteLine("");
            Console.WriteLine("[10,25] notEquals = [10,25)");
            Console.WriteLine(notEquals);
        }

    }
}
