using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("...");
            foreach (var item in findSchedules2(24, 4, "08??840"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("...");
            Console.ReadKey();
        }

        public static List<string> findSchedules(int workHours, int dayHours, string pattern)
        {

            var results = new List<string>();

            var arr = pattern.ToArray();
            //var arr = pattern.Select(x => x == '?' ? -1 : char.GetNumericValue(x)).ToArray();
            var sum = pattern.Sum(x => x == '?' ? 0 : char.GetNumericValue(x));
            var questionMarksCount = pattern.Count(x => x == '?');

            var diff = workHours - sum;
            //if (diff % questionMarksCount == 0)
            //{
            //    pattern.Replace('?', (char)(diff / workHours));
            //}

            var temp = pattern;

            int[] indexesOfQuestionMark = pattern.Select((b, i) => b == '?' ? i : -1).Where(i => i != -1).ToArray();
            int iCount = 0;
            while (iCount <= dayHours)
            {
                //sum = arr.Sum(x => x != '?' ? char.GetNumericValue(x) : 0);
                //diff = workHours - sum;
                //foreach (var item in arr.Reverse().Where(x => x == '?'))
                foreach (var item in indexesOfQuestionMark)
                {
                    var dayDiff = diff > dayHours ? dayHours : diff;
                    dayDiff = dayDiff - iCount < 0 ? 0 : dayDiff - iCount;

                    arr[item] = char.Parse((dayDiff).ToString());

                    sum = arr.Sum(x => x != '?' ? char.GetNumericValue(x) : 0);

                    diff = workHours - sum;

                    temp = String.Join("", arr);

                    if (sum == workHours && arr.Count(x => x == '?') == 0)
                    {
                        results.Add(temp);
                    }

                    if (workHours > sum )
                    {

                    }

                }
       
                temp = pattern;
                arr = pattern.ToArray();
                iCount++;

                //    iCount--;
            }

            return results.OrderBy(x => x).ToList();
        }


        public static List<string> findSchedules2(int workHours, int dayHours, string pattern)
        {
            var possibleSchedules = new List<string>();

            if ((workHours < 1 || workHours > 56) || (dayHours < 1 || dayHours > 8) || pattern.Length != 7)
            {
                throw new Exception("Invalid constraint");
            }

            //var schedule = new int[7];

            var sum = pattern.Sum(x => x != '?' ? char.GetNumericValue(x) : 0);


            int count = 0;
            while (pattern.Sum(x => x != '?' ? char.GetNumericValue(x) : dayHours - count) <= workHours)
            {
                var li = pattern.LastIndexOf('?');
                var arrPattern = pattern.ToCharArray();

                for (int i = dayHours; i <= 0; i++)
                {
                    arrPattern[li] = (char)(dayHours - count);
                }

                count++;
            }

            var sum2 = pattern.Sum(x => x != '?' ? char.GetNumericValue(x) : workHours);

            var countQuestionMarks = pattern.Count(x => x == '?');


            //pattern.LastIndexOf('?')
            //int res = 0;

            //var count = pattern.Count(x => x == '?');

            //var scheduleArr = pattern.Select(x => int.TryParse(x.ToString(), out res) ? res : -1).ToArray();

            //foreach (var ch in scheduleArr)
            //{
            //    if (ch == '?')
            //    {
            //        countQuestionMarks++;
            //    }
            //}




            ////If sum of schedule is equal to workHours
            ////Add schedule
            //if (true)
            //{

            //}
            return new List<string>();
        }
    }
}
