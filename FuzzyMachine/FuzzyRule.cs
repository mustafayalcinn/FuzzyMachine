using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyMachine
{
	public class FuzzyRule
	{
		public int RuleNumber { get; set; }
		public Dictionary<string, string> Antecedents { get; set; } // Variable name -> Linguistic term
		public Dictionary<string, string> Consequents { get; set; } // Variable name -> Linguistic term

		public FuzzyRule(int ruleNumber)
		{
			RuleNumber = ruleNumber;
			Antecedents = new Dictionary<string, string>();
			Consequents = new Dictionary<string, string>();
		}

		public void AddAntecedent(string variableName, string linguisticTerm)
		{
			Antecedents[variableName] = linguisticTerm;
		}

		public void AddConsequent(string variableName, string linguisticTerm)
		{
			Consequents[variableName] = linguisticTerm;
		}

		public double GetFiringStrength(Dictionary<string, Dictionary<string, double>> fuzzifiedInputs)
		{
			double minValue = double.MaxValue;

			foreach (var antecedent in Antecedents)
			{
				string variableName = antecedent.Key;
				string linguisticTerm = antecedent.Value;

				if (fuzzifiedInputs.ContainsKey(variableName) &&
					fuzzifiedInputs[variableName].ContainsKey(linguisticTerm))
				{
					double membershipDegree = fuzzifiedInputs[variableName][linguisticTerm];
					minValue = Math.Min(minValue, membershipDegree);
				}
				else
				{
					return 0; // If any antecedent is not satisfied
				}
			}

			return minValue;
		}
	}
}
