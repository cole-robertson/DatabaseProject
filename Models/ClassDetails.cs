using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Models
{
    public class ClassDetails
    {
        public string ClassName { get; set; }

        public int ClassId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TermName { get; set; }

        public string Days { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Building { get; set; }

        public int RoomNumber { get; set; }

        public static string ConvertBitsToDays(int bits)
        {
            Dictionary<int, char> bitDict = new Dictionary<int, char>
            {
                { 1, 'M' },
                { 2, 'T' },
                { 4, 'W' },
                { 8, 'U' },
                { 16, 'F' }
            };
            StringBuilder sb = new StringBuilder();
            foreach(int bitval in bitDict.Keys)
            {
                int result = bitval & bits;
                if(result != 0)
                {
                    sb.Append(bitDict[bitval]);
                }
            }
            return sb.ToString();
            

        }

        public static int ConvertDaysToBits(string days)
        {
            Dictionary<char, int> bitDict = new Dictionary<char, int>
            {
                { 'M', 1 },
                { 'T', 2 },
                { 'W', 4 },
                { 'U', 8 },
                { 'F', 16 }
            };
            StringBuilder sb = new StringBuilder();
            int dayVal = 0;
            foreach (char day in days)
            {
                if (bitDict.ContainsKey(day))
                {
                    dayVal += bitDict[day];

                }
            }
            return dayVal;
        }
    }
}