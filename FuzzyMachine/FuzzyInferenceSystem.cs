using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyMachine
{
	public class FuzzyInferenceSystem
	{
		public List<FuzzyVariable> InputVariables { get; set; }
		public List<FuzzyVariable> OutputVariables { get; set; }
		public List<FuzzyRule> Rules { get; set; }

		public FuzzyInferenceSystem()
		{
			InputVariables = new List<FuzzyVariable>();
			OutputVariables = new List<FuzzyVariable>();
			Rules = new List<FuzzyRule>();
		}

		public void AddInputVariable(FuzzyVariable variable)
		{
			InputVariables.Add(variable);
		}

		public void AddOutputVariable(FuzzyVariable variable)
		{
			OutputVariables.Add(variable);
		}

		public void AddRule(FuzzyRule rule)
		{
			Rules.Add(rule);
		}

		public Dictionary<string, double> Evaluate(Dictionary<string, double> inputValues)
		{
			// Fuzzify inputs
			Dictionary<string, Dictionary<string, double>> fuzzifiedInputs = new Dictionary<string, Dictionary<string, double>>();

			foreach (var inputVariable in InputVariables)
			{
				if (inputValues.ContainsKey(inputVariable.Name))
				{
					double crispValue = inputValues[inputVariable.Name];
					fuzzifiedInputs[inputVariable.Name] = inputVariable.Fuzzify(crispValue);
				}
			}

			// Evaluate rules
			Dictionary<string, Dictionary<string, double>> ruleConsequents = new Dictionary<string, Dictionary<string, double>>();
			List<FuzzyRule> activatedRules = new List<FuzzyRule>();

			foreach (var rule in Rules)
			{
				double firingStrength = rule.GetFiringStrength(fuzzifiedInputs);

				if (firingStrength > 0)
				{
					activatedRules.Add(rule);

					foreach (var consequent in rule.Consequents)
					{
						string outputVariableName = consequent.Key;
						string linguisticTerm = consequent.Value;

						if (!ruleConsequents.ContainsKey(outputVariableName))
						{
							ruleConsequents[outputVariableName] = new Dictionary<string, double>();
						}

						if (!ruleConsequents[outputVariableName].ContainsKey(linguisticTerm))
						{
							ruleConsequents[outputVariableName][linguisticTerm] = firingStrength;
						}
						else
						{
							// Apply max operator for Mamdani
							ruleConsequents[outputVariableName][linguisticTerm] =
								Math.Max(ruleConsequents[outputVariableName][linguisticTerm], firingStrength);
						}
					}
				}
			}

			// Defuzzify using weighted average method
			Dictionary<string, double> crispOutputs = new Dictionary<string, double>();

			foreach (var outputVariable in OutputVariables)
			{
				string outputName = outputVariable.Name;

				if (ruleConsequents.ContainsKey(outputName))
				{
					crispOutputs[outputName] = DefuzzifyWeightedAverage(outputVariable, ruleConsequents[outputName]);
				}
			}

			

			return crispOutputs;
		}

		private double DefuzzifyWeightedAverage(FuzzyVariable outputVariable, Dictionary<string, double> activatedConsequents)
		{
			double weightedSum = 0;
			double weightSum = 0;

			foreach (var mf in outputVariable.MembershipFunctions)
			{
				if (activatedConsequents.ContainsKey(mf.Name))
				{
					double weight = activatedConsequents[mf.Name];

					if (mf is TriangularMF triangular)
					{
						double center = triangular.Center;
						weightedSum += center * weight;
						weightSum += weight;
					}
					else if (mf is TrapezoidMF trapezoid)
					{
						double center = (trapezoid.LeftCenter + trapezoid.RightCenter) / 2;
						weightedSum += center * weight;
						weightSum += weight;
					}
				}
			}

			if (weightSum > 0)
				return weightedSum / weightSum;
			else
				return (outputVariable.MinValue + outputVariable.MaxValue) / 2; // Default center
		}

		public double DefuzzifyCentroid(FuzzyVariable outputVariable, Dictionary<string, double> activatedConsequents, int samples = 100)
		{
			double min = outputVariable.MinValue;
			double max = outputVariable.MaxValue;
			double step = (max - min) / samples;

			double numeratorSum = 0;
			double denominatorSum = 0;

			for (double x = min; x <= max; x += step)
			{
				double membershipDegree = 0;

				foreach (var mf in outputVariable.MembershipFunctions)
				{
					if (activatedConsequents.ContainsKey(mf.Name))
					{
						double weight = activatedConsequents[mf.Name];
						double degree = mf.GetMembershipDegree(x);
						membershipDegree = Math.Max(membershipDegree, Math.Min(weight, degree));
					}
				}

				numeratorSum += x * membershipDegree;
				denominatorSum += membershipDegree;
			}

			if (denominatorSum > 0)
				return numeratorSum / denominatorSum;
			else
				return (min + max) / 2; // Default center
		}
	}
}
