﻿using System;

namespace DPINT_Wk1_Strategies.Converters
{
	public class BinaryNumberConverter : INumberConverter
	{
		public string ToLocalString(int number)
		{
			return Convert.ToString(number, 2);
		}

		public int ToNumerical(String text)
		{
			return Convert.ToInt32(text, 2);
		}
	}
}
