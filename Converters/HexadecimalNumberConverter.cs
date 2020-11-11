using System;

namespace DPINT_Wk1_Strategies.Converters
{
	public class HexadecimalNumberConverter : INumberConverter
	{
		public string ToLocalString(int number)
		{
			return Convert.ToString(number, 16);
		}

		public int ToNumerical(String text)
		{
			return Convert.ToInt32(text, 16);
		}
	}
}
