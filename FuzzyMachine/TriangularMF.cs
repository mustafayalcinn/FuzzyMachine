using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FuzzyMachine
{
	public class TriangularMF : MembershipFunction
	{
		public double Left { get; set; }
		public double Center { get; set; }
		public double Right { get; set; }

		public TriangularMF(string name, double left, double center, double right)
		{
			Name = name;
			Left = left;
			Center = center;
			Right = right;
		}

		public override double GetMembershipDegree(double value)
		{
			if (value <= Left || value >= Right)
				return 0;
			else if (value == Center)
				return 1;
			else if (value < Center)
				return (value - Left) / (Center - Left);
			else
				return (Right - value) / (Right - Center);
		}
	}
}
