using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyMachine
{
	public class TrapezoidMF : MembershipFunction
	{
		public double Left { get; set; }
		public double LeftCenter { get; set; }
		public double RightCenter { get; set; }
		public double Right { get; set; }

		public TrapezoidMF(string name, double left, double leftCenter, double rightCenter, double right)
		{
			Name = name;
			Left = left;
			LeftCenter = leftCenter;
			RightCenter = rightCenter;
			Right = right;
		}

		public override double GetMembershipDegree(double value)
		{
			if (value <= Left || value >= Right)
				return 0;
			else if (value >= LeftCenter && value <= RightCenter)
				return 1;
			else if (value < LeftCenter)
				return (value - Left) / (LeftCenter - Left);
			else
				return (Right - value) / (Right - RightCenter);
		}
	}
}
