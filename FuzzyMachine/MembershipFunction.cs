using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyMachine
{
	public abstract class MembershipFunction
	{
		public string Name { get; set; }
		public abstract double GetMembershipDegree(double value);
	}
}
