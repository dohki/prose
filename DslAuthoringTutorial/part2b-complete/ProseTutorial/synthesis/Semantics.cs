using System;
using System.Text.RegularExpressions;

namespace ProseTutorial
{
    public static class Semantics
    {
        public static bool FitInRange(uint var, Tuple<uint, uint> range)
        {
            var lowerBound = range.Item1;
            var upperBound = range.Item2;

            return lowerBound <= var && var <= upperBound;
        }

        public static Tuple<uint, uint> Range(uint lowerBound, uint upperBound)
        {
            if (lowerBound > upperBound)
                return null;

            return Tuple.Create(lowerBound, upperBound);
        }
    }
}