using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyMachine
{
	public class FuzzyVariable
	{
		public string Name { get; set; }
		public double MinValue { get; set; }
		public double MaxValue { get; set; }
		public List<MembershipFunction> MembershipFunctions { get; set; }

		public FuzzyVariable(string name, double minValue, double maxValue)
		{
			Name = name;
			MinValue = minValue;
			MaxValue = maxValue;
			MembershipFunctions = new List<MembershipFunction>();
		}

		public void AddMembershipFunction(MembershipFunction mf)
		{
			MembershipFunctions.Add(mf);
		}

		public Dictionary<string, double> Fuzzify(double crispValue)
		{
			Dictionary<string, double> membershipDegrees = new Dictionary<string, double>();

			foreach (var mf in MembershipFunctions)
			{
				double degree = mf.GetMembershipDegree(crispValue);
				membershipDegrees[mf.Name] = degree;
			}

			return membershipDegrees;
		}
	}
}
