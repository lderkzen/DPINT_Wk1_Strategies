using System;

namespace DPINT_Wk1_Strategies.Converters
{
	public class NumericalNumberConverter : INumberConverter
	{
		public string ToLocalString(int number)
		{
			return number.ToString();
		}

		public int ToNumerical(String text)
		{
			return Int32.Parse(text);
		}
	}
}
