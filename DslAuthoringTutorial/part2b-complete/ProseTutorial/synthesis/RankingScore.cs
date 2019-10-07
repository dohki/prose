using System;
using System.Text.RegularExpressions;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Features;

namespace ProseTutorial
{
    public class RankingScore : Feature<double>
    {
        public RankingScore(Grammar grammar) : base(grammar, "Score")
        {
        }

        [FeatureCalculator(nameof(Semantics.FitInRange))]
        public static double FitInRange(double var, double lowerBound, double upperBound)
        {
            // TODO: Use var with GetFeatureValueForVariable
            return 1 / (upperBound - lowerBound);
        }

        [FeatureCalculator("bound", Method = CalculationMethod.FromLiteral)]
        public static double Bound(uint bound)
        {
            //return 1.0 / Math.Abs(bound);
            return (double) bound;
        }
    }
}