using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LookAtTheTime
{
    public static class LookAtTheTime
    {

        public static string GetDifference(string First, string Second)
        {
            string[] TempFirst = First.Split(':');
            string[] TempSecond = Second.Split(':');
            string[] TempFirstMS = TempFirst[2].Split('.');
            string[] TempSecondMS = TempSecond[2].Split('.');
            try
            {
                TimeSpan TempFirstTime = new TimeSpan(0, Int32.Parse(TempFirst[0]), Int32.Parse(TempFirst[1]), Int32.Parse(TempFirstMS[0]), GetMillisecondsFromString(TempFirstMS));
                TimeSpan TempSecondTime = new TimeSpan(0, Int32.Parse(TempSecond[0]), Int32.Parse(TempSecond[1]), Int32.Parse(TempSecondMS[0]), GetMillisecondsFromString(TempSecondMS));
                TimeSpan ReturnTime =  TimeSpan.FromMilliseconds( GetDifferenceInMS(ref TempFirstTime, ref TempSecondTime));
                if(IsDifferencePositive(ref TempFirstTime, ref TempSecondTime))
                    return ReturnTime.ToString();
                else
                    return "-"+ReturnTime.ToString();

            }
            catch (Exception e)
            {
                Console.Write("BAD PARAMS '" + First + "' and '" + Second + "'\n Exception " + e + "\n");
                return "00:00:00.00";
            }
        }
        public static bool IsDifferenceFirstAndSecondLowerEqualToThird(string First, string Second, int peak)
        {
            string[] TempFirst = First.Split(':');
            string[] TempSecond = Second.Split(':');
            string[] TempFirstMS = TempFirst[2].Split('.');
            string[] TempSecondMS = TempSecond[2].Split('.');
            try
            {
                TimeSpan TempFirstTime = new TimeSpan(0, Int32.Parse(TempFirst[0]), Int32.Parse(TempFirst[1]), Int32.Parse(TempFirstMS[0]), GetMillisecondsFromString(TempFirstMS));
                TimeSpan TempSecondTime = new TimeSpan(0, Int32.Parse(TempSecond[0]), Int32.Parse(TempSecond[1]), Int32.Parse(TempSecondMS[0]), GetMillisecondsFromString(TempSecondMS));
                if (CheckIsPeakIsOver(peak, ref TempFirstTime, ref TempSecondTime))
                    return true;

            }
            catch (Exception e)
            {
                Console.Write("BAD PARAMS '" + First + "' and '" + Second + "'\n Exception " + e + "\n");
                return false;
            }
            return false;

        }

        private static bool CheckIsPeakIsOver(int peak, ref TimeSpan TempFirstTime, ref TimeSpan TempSecondTime)
        {
            return GetDifferenceInMS(ref TempFirstTime, ref TempSecondTime) < peak;
        }

        private static double GetDifferenceInMS(ref TimeSpan TempFirstTime, ref TimeSpan TempSecondTime)
        {
            if (IsDifferencePositive(ref TempFirstTime, ref TempSecondTime))
                return TempFirstTime.TotalMilliseconds - TempSecondTime.TotalMilliseconds;
            else
                return (TempFirstTime.TotalMilliseconds - TempSecondTime.TotalMilliseconds) * (-1);

        }

        private static bool IsDifferencePositive(ref TimeSpan TempFirstTime, ref TimeSpan TempSecondTime)
        {
            return TempFirstTime.TotalMilliseconds - TempSecondTime.TotalMilliseconds > 0;
        }

        private static int GetMillisecondsFromString(string[] TempMS)
        {
            return TempMS.Length > 1 ? Int32.Parse(TempMS[1]) : 0;
        }

    }
}
