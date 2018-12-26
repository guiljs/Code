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

            var possibleSchedules = new List<string>();

            if ((workHours < 1 || workHours > 56) || (dayHours < 1 || dayHours > 8) || pattern.Length != 7)
            {
                throw new Exception("Invalid constraint");
            }

            //var schedule = new int[7];

            var patternSum = 0;

            var countQuestionMark = 0;

            var scheduleArr = pattern.ToCharArray();

            foreach (var ch in scheduleArr)
            {
                if (ch != '?')
                {
                    patternSum += int.Parse(ch.ToString());
                }
                else
                {
                    countQuestionMark++;
                }
            }

            //Got the difference
            var difference = workHours - patternSum;

            if (difference <= dayHours)
            {

            }


            //Reverse
            Array.Reverse(scheduleArr);

            foreach (var item in scheduleArr)
            {
                if (item == '?')
                {
                    scheduleArr[Array.IndexOf(scheduleArr, item)] = (dayHours - (difference % dayHours)).ToString().ToCharArray()[0];
                    difference -= dayHours;
                }
            }

            Array.Reverse(scheduleArr);


            possibleSchedules.Add(string.Join("", scheduleArr));


            return possibleSchedules;
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
