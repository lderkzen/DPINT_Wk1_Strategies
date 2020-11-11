using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies.Converters
{
	public class OctalNumberConverter : INumberConverter
	{
		public string ToLocalString(int number)
		{
			return Convert.ToString(number, 8);
		}

		public int ToNumerical(string text)
		{
			return Convert.ToInt32(text, 8);
		}
	}
}
