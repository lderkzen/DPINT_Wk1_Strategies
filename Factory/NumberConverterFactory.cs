using DPINT_Wk1_Strategies.Converters;
using System;
using System.Collections.Generic;

namespace DPINT_Wk1_Strategies.Factory
{
	public class NumberConverterFactory
	{
		public IEnumerable<String> ConverterNames {
			get { return _converters.Keys; }
		}

		private Dictionary<string, INumberConverter> _converters;

		public NumberConverterFactory()
		{
			_converters = new Dictionary<string, INumberConverter>();
			_converters["Numerical"] = new NumericalNumberConverter();
			_converters["Binary"] = new BinaryNumberConverter();
			_converters["Hexadecimal"] = new HexadecimalNumberConverter();
			_converters["Roman"] = new RomanNumberConverter();
			_converters["Octal"] = new OctalNumberConverter();
		}

		public INumberConverter GetConverter(String name)
		{
			if (_converters.ContainsKey(name))
				return _converters[name];
			else
				throw new ArgumentOutOfRangeException("something bad happened");
		}
	}
}
