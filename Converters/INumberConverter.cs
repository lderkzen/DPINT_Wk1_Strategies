using System;

namespace DPINT_Wk1_Strategies
{
	public interface INumberConverter
	{
		String ToLocalString(int number);
		int ToNumerical(String text);
	}
}
