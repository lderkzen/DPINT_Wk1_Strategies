﻿using System;
using System.Collections.Generic;

namespace DPINT_Wk1_Strategies.Converters
{
	public class RomanNumberConverter : INumberConverter
	{
		private static Dictionary<char, int> _romanMap = new Dictionary<char, int>
		{
		   {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
		};

		public string ToLocalString(int number)
		{
			if (number < 1) return string.Empty;
			if (number >= 1000) return "M" + ToLocalString(number - 1000);
			if (number >= 900) return "CM" + ToLocalString(number - 900); //EDIT: i've typed 400 instead 900
			if (number >= 500) return "D" + ToLocalString(number - 500);
			if (number >= 400) return "CD" + ToLocalString(number - 400);
			if (number >= 100) return "C" + ToLocalString(number - 100);
			if (number >= 90) return "XC" + ToLocalString(number - 90);
			if (number >= 50) return "L" + ToLocalString(number - 50);
			if (number >= 40) return "XL" + ToLocalString(number - 40);
			if (number >= 10) return "X" + ToLocalString(number - 10);
			if (number >= 9) return "IX" + ToLocalString(number - 9);
			if (number >= 5) return "V" + ToLocalString(number - 5);
			if (number >= 4) return "IV" + ToLocalString(number - 4);
			if (number >= 1) return "I" + ToLocalString(number - 1);

			throw new ArgumentOutOfRangeException("something bad happened");
		}

		public int ToNumerical(String text)
		{
			int totalValue = 0, prevValue = 0;
			foreach (var c in text)
			{
				if (!_romanMap.ContainsKey(c))
					return 0;
				var crtValue = _romanMap[c];
				totalValue += crtValue;
				if (prevValue != 0 && prevValue < crtValue)
				{
					if (prevValue == 1 && (crtValue == 5 || crtValue == 10)
						|| prevValue == 10 && (crtValue == 50 || crtValue == 100)
						|| prevValue == 100 && (crtValue == 500 || crtValue == 1000))
						totalValue -= 2 * prevValue;
					else
						return 0;
				}
				prevValue = crtValue;
			}
			return totalValue;
		}
	}
}
