using System;
using System.Collections.Generic;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Rules;
using Microsoft.ProgramSynthesis.Specifications;

namespace ProseTutorial
{
    public class WitnessFunctions : DomainLearningLogic
    {
        public WitnessFunctions(Grammar grammar) : base(grammar)
        {
        }

        [WitnessFunction(nameof(Semantics.Range), 0)]
        public ExampleSpec WitnessLowerBound(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, object>();
            var lowerBound = (uint) UInt32.MaxValue;
            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (uint) inputState[rule.Body[0]];
                var output = (bool) example.Value;
                if (output)
                    lowerBound = Math.Min(input, lowerBound);
            }

            Console.Out.WriteLine("Witness Lower Bound: {0}", lowerBound);

            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                result[inputState] = lowerBound;
            }

            return new ExampleSpec(result);
        }

        [WitnessFunction(nameof(Semantics.Range), 1)]
        public ExampleSpec WitnessUpperBound(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, object>();
            var upperBound = (uint) UInt32.MinValue;
            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (uint) inputState[rule.Body[0]];
                var output = (bool) example.Value;
                if (output)
                    upperBound = Math.Max(input, upperBound);
            }

            Console.Out.WriteLine("Witness Upper Bound: {0}", upperBound);

            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                result[inputState] = upperBound;
            }

            return new ExampleSpec(result);
        }
    }
}