using DPINT_Wk1_Strategies.Factory;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DPINT_Wk1_Strategies
{
	public class ValueConverterViewModel : ViewModelBase
	{
		private NumberConverterFactory _converterFactory;
		public NumberConverterFactory ConverterFactory {
			get { return _converterFactory; }
			set { _converterFactory = value; }
		}

		private string _fromText;
		public string FromText {
			get { return _fromText; }
			set {
				_fromText = value;
				RaisePropertyChanged("FromText");
			}
		}

		private string _toText;
		public string ToText {
			get { return _toText; }
			set {
				_toText = value;
				RaisePropertyChanged("ToText");
			}
		}

		private INumberConverter _fromConverter;
		public INumberConverter FromConverter {
			get { return _fromConverter; }
			set { _fromConverter = value; }
		}

		private INumberConverter _toConverter;
		public INumberConverter ToConverter {
			get { return _toConverter; }
			set { _toConverter = value; }
		}

		private string _fromConverterName;
		public string FromConverterName {
			get { return _fromConverterName; }
			set {
				_fromConverterName = value;
				_fromConverter = _converterFactory.GetConverter(value);
				RaisePropertyChanged("FromConverterName");
				this.ConvertNumbers();
			}
		}

		private string _toConverterName;
		public string ToConverterName {
			get { return _toConverterName; }
			set {
				_toConverterName = value;
				_toConverter = _converterFactory.GetConverter(value);
				RaisePropertyChanged("ToConverterName");
				this.ConvertNumbers();
			}
		}

		public ObservableCollection<string> ConverterNames { get; set; }
		public ICommand ConvertCommand { get; set; }

		public ValueConverterViewModel()
		{
			_converterFactory = new NumberConverterFactory();
			ConverterNames = new ObservableCollection<string>(_converterFactory.ConverterNames);

			FromText = "0";
			ToText = "0";
			_fromConverterName = "Numerical";
			_toConverterName = "Numerical";
			FromConverter = _converterFactory.GetConverter(_fromConverterName);
			ToConverter = _converterFactory.GetConverter(_toConverterName);


			ConvertCommand = new RelayCommand(ConvertNumbers);
		}

		private void ConvertNumbers()
		{
			int nr = _fromConverter.ToNumerical(FromText);
			ToText = _toConverter.ToLocalString(nr);
		}
	}
}
