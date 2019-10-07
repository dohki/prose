using System;


namespace ProseTutorial
{
    public static class Semantics
    {
        public static bool? FitInRange(uint var, uint lowerBound, uint upperBound)
        {
            if (lowerBound > upperBound)
                return null;

            return lowerBound <= var && var <= upperBound;
        }
    }
}