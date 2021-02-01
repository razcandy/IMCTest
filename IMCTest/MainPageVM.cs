using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IMCTest.Data;
using IMCTest.Services;
using IMCTest.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMCTest
{
	public class MainPageVM : ViewModelBase
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private string amount;
        private string amountHelperText;
        private string fromCityHelperText;
        private string fromCountryHelperText;
        private string fromStateHelperText;
        private string fromZipHelperText = Translations.ZipCodeHelperText;
        private bool isAmountErrored;
        private bool isFromCityErrored;
        private bool isFromCountryErrored;
        private bool isFromStateErrored;
        private bool isFromZipErrored;
        private bool isShippingErrored;
        private bool isToCityErrored;
        private bool isToCountryErrored;
        private bool isToStateErrored;
        private bool isToZipErrored;
        private bool isUserMessageErrored;
        private string shipping;
        private string shippingHelperText;
        private TaxRequestModel taxRequest;
        private TaxService taxService;
        private string toCityHelperText;
        private string toCountryHelperText;
        private string toStateHelperText;
        private string toZipHelperText = Translations.ZipCodeHelperText;
        private string userMessage;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public MainPageVM() : base()
		{
            taxRequest = new TaxRequestModel();
            taxService = new TaxService();
            ResetCommand = new RelayCommand(Reset);
            SubmitCommand = new RelayCommand(Submit);

            Test();
        }

        private void Test()
		{
            taxRequest.FromCountry = "US";
            taxRequest.ToCountry = "US";
            //Shipping = "5.99";
            ToZip = "27609";
            ToState = "NC";
            //Amount = 3.14;

            //taxRequest.FromCity = "Asheville";
            taxRequest.FromState = "NC";
            //taxRequest.FromZip = "28804";
        }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public string Amount
        {
            get => amount;
            set
            {
                if (Amount != value)
                {
                    Set(ref amount, value);
                    ValidateAmount();
                }
            }
        }

        public string AmountHelperText
        {
            get => amountHelperText;
            set
            {
                if (amountHelperText != value)
                {
                    Set(ref amountHelperText, value);
                }
            }
        }

        public string FromCity
        {
            get => taxRequest.FromCity;
            set
            {
                if (FromCity != value)
                {
                    taxRequest.FromCity = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string FromCityHelperText
        {
            get => fromCityHelperText;
            set
            {
                if (fromCityHelperText != value)
                {
                    Set(ref fromCityHelperText, value);
                }
            }
        }

        public string FromCountry
        {
            get => taxRequest.FromCountry;
            set
            {
                if (FromCountry != value)
                {
                    taxRequest.FromCountry = value;
                    RaisePropertyChanged();
                    ValidateFromCountry();
                }
            }
        }

        public string FromCountryHelperText
        {
            get => fromCountryHelperText;
            set
            {
                if (fromCountryHelperText != value)
                {
                    Set(ref fromCountryHelperText, value);
                }
            }
        }

        public string FromState
        {
            get => taxRequest.FromState;
            set
            {
                if (FromState != value)
                {
                    taxRequest.FromState = value;
                    RaisePropertyChanged();
                    ValidateFromState();
                }
            }
        }

        public string FromStateHelperText
        {
            get => fromStateHelperText;
            set
            {
                if (fromStateHelperText != value)
                {
                    Set(ref fromStateHelperText, value);
                }
            }
        }

        public string FromZip
        {
            get => taxRequest.FromZip;
            set
            {
                if (FromZip != value)
                {
                    taxRequest.FromZip = value;
                    RaisePropertyChanged();
                    ValidateFromZip();
                }
            }
        }

        public string FromZipHelperText
		{
            get => fromZipHelperText;
            set
            {
                if (fromZipHelperText != value)
                {
                    Set(ref fromZipHelperText, value);
                }
            }
        }

        public bool IsAmountErrored
        {
            get => isAmountErrored;
            set
            {
                if (isAmountErrored != value)
                {
                    Set(ref isAmountErrored, value);
                }
            }
        }

        public bool IsFromCityErrored
		{
            get => isFromCityErrored;
            set
			{
                if (isFromCityErrored != value)
				{
                    Set(ref isFromCityErrored, value);
				}
			}
        }

        public bool IsFromCountryErrored
        {
            get => isFromCountryErrored;
            set
            {
                if (isFromCountryErrored != value)
                {
                    Set(ref isFromCountryErrored, value);
                }
            }
        }

        public bool IsFromStateErrored
        {
            get => isFromStateErrored;
            set
            {
                if (isFromStateErrored != value)
                {
                    Set(ref isFromStateErrored, value);
                }
            }
        }

        public bool IsFromZipErrored
        {
            get => isFromZipErrored;
            set
            {
                if (isFromZipErrored != value)
                {
                    Set(ref isFromZipErrored, value);
                }
            }
        }
        
        public bool IsShippingErrored
        {
            get => isShippingErrored;
            set
            {
                if (isShippingErrored != value)
                {
                    Set(ref isShippingErrored, value);
                }
            }
        }

        public bool IsToCityErrored
        {
            get => isToCityErrored;
            set
            {
                if (isToCityErrored != value)
                {
                    Set(ref isToCityErrored, value);
                }
            }
        }

        public bool IsToCountryErrored
        {
            get => isToCountryErrored;
            set
            {
                if (isToCountryErrored != value)
                {
                    Set(ref isToCountryErrored, value);
                }
            }
        }

        
        public bool IsToStateErrored
        {
            get => isToStateErrored;
            set
            {
                if (isToStateErrored != value)
                {
                    Set(ref isToStateErrored, value);
                }
            }
        }

        public bool IsToZipErrored
        {
            get => isToZipErrored;
            set
            {
                if (isToZipErrored != value)
                {
                    Set(ref isToZipErrored, value);
                }
            }
        }

        public bool IsUserMessageErrored
		{
            get => isUserMessageErrored;
            set
			{
                if (isUserMessageErrored != value)
				{
                    Set(ref isUserMessageErrored, value);
				}
			}

        }

        public RelayCommand ResetCommand { get; private set; }

        public string Shipping
        {
            get => shipping;
            set
            {
                if (shipping != value)
                {
                    Set(ref shipping, value);
                    ValidateShipping();
                }
            }
        }

        public string ShippingHelperText
        {
            get => shippingHelperText;
            set
            {
                if (shippingHelperText != value)
                {
                    Set(ref shippingHelperText, value);
                }
            }
        }

        public List<string> StatesList { get; private set; } = EnumHelper.GetState2LetterList();

        public RelayCommand SubmitCommand { get; private set; }

        public string ToCity
		{
            get => taxRequest.ToCity;
            set
			{
                if (ToCity != value)
				{
                    taxRequest.ToCity = value;
                    RaisePropertyChanged();
				}
			}
		}

        public string ToCityHelperText
        {
            get => toCityHelperText;
            set
            {
                if (toCityHelperText != value)
                {
                    Set(ref toCityHelperText, value);
                }
            }
        }

        public string ToCountry
		{
            get => taxRequest.ToCountry;
            set
			{
                if (ToCountry != value)
				{
                    taxRequest.ToCountry = value;
                    RaisePropertyChanged();
                    ValidateToCountry();
                }
            }
		}

        public string ToCountryHelperText
        {
            get => toCountryHelperText;
            set
            {
                if (toCountryHelperText != value)
                {
                    toCountryHelperText = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToState
        {
            get => taxRequest.ToState;
            set
            {
                if (ToState != value)
                {
                    taxRequest.ToState = value;
                    RaisePropertyChanged();
                    ValidateToState();
                }
            }
        }

        public string ToStateHelperText
        {
            get => toStateHelperText;
            set
            {
                if (toStateHelperText != value)
                {
                    toStateHelperText = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToZip
        {
            get => taxRequest.ToZip;
            set
            {
                if (ToZip != value)
                {
                    taxRequest.ToZip = value;
                    RaisePropertyChanged();
                    ValidateToZip();
                }
            }
        }

        public string ToZipHelperText
        {
            get => toZipHelperText;
            set
            {
                if (toZipHelperText != value)
                {
                    Set(ref toZipHelperText, value);
                }
            }
        }

        public string UserMessage
		{
            get => userMessage;
            set
			{
                if (userMessage != value)
				{
                    Set(ref userMessage, value);
				}
			}
		}

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private (bool isValid, double value) EvaluateAsMonetary(string _value)
        {
            if (string.IsNullOrWhiteSpace(_value)) return (true, 0);

            if (!double.TryParse(_value, out double valueDouble)) return (false, 0);

            return (true, valueDouble);
        }

        private bool IsCountryValid(string _country)
		{
            if (string.IsNullOrWhiteSpace(_country)) return false;

            return true;
		}

        private bool IsStateValid(string _state)
		    => !string.IsNullOrWhiteSpace(_state) && StatesList.Contains(_state);

        private bool IsZipCodeValid(string _zip)
        {
            if (string.IsNullOrWhiteSpace(_zip)) return false;

            if (_zip.Length != 5) return false;

            if (!int.TryParse(_zip, out int zipInt)) return false;

            return true;
        }

        private void Reset()
		{
            taxRequest = new TaxRequestModel();
            Amount = null;
            Shipping = null;

            RaisePropertyChanged(nameof(FromCountry));
            RaisePropertyChanged(nameof(FromState));
            RaisePropertyChanged(nameof(FromZip));
            RaisePropertyChanged(nameof(ToCountry));
            RaisePropertyChanged(nameof(ToState));
            RaisePropertyChanged(nameof(ToZip));

            AmountHelperText = null;
            FromCountryHelperText = null;
            FromStateHelperText = null;
            FromZipHelperText = null;
            ShippingHelperText = null;
            ToCountryHelperText = null;
            ToStateHelperText = null;
            ToZipHelperText = null;
            UserMessage = null;

            IsAmountErrored = false;
            IsFromCountryErrored = false;
            IsFromStateErrored = false;
            IsFromZipErrored = false;
            IsShippingErrored = false;
            IsToCountryErrored = false;
            IsToStateErrored = false;
            IsToZipErrored = false;
            IsUserMessageErrored = false;
        }

        private async void Submit()
		{
			ValidateAmount();
			ValidateFromCountry();
			ValidateFromState();
			ValidateFromZip();
			ValidateShipping();
			ValidateToCountry();
			ValidateToState();
			ValidateToZip();

			if (IsAmountErrored || IsFromCountryErrored || IsFromStateErrored || IsFromZipErrored ||
				IsShippingErrored || IsToCountryErrored || IsToStateErrored || IsToZipErrored)
			{
				UserMessage = Translations.FixErrors;
				IsUserMessageErrored = true;
				return;
			}
			else
			{
				UserMessage = null;
			}

			var res = await taxService.CalculateTax(taxRequest);

            if (res.success)
			{
                IsUserMessageErrored = false;
                UserMessage = string.Format(Translations.YourTaxAndTotalAre,
                    res.tax.AmountToCollect, res.tax.OrderTotalAmount);
			}
            else
			{
                IsUserMessageErrored = true;
                UserMessage = res.message;
			}
        }

        private void ValidateAmount()
        {
            var res = EvaluateAsMonetary(Amount);

            if (!res.isValid)
            {
                IsAmountErrored = true;
                AmountHelperText = Translations.EnterMonetaryValue;
                taxRequest.Amount = 0;
                return;
            }

            if (res.value > 0)
            {
                IsAmountErrored = false;
                AmountHelperText = null;
            }
            else
            {
                IsAmountErrored = true;
                AmountHelperText = Translations.ValueRequired;
            }

            taxRequest.Amount = res.value;
        }

        private void ValidateFromCountry()
        {
            if (IsCountryValid(FromCountry))
            {
                IsFromCountryErrored = false;
                FromCountryHelperText = null;
            }
            else
            {
                IsFromCountryErrored = true;
                FromCountryHelperText = Translations.ValueRequired;
            }
        }

        private void ValidateFromState()
        {
            if (IsStateValid(FromState))
			{
                IsFromStateErrored = false;
                FromStateHelperText = null;
			}
            else
			{
                IsFromStateErrored = true;
                FromStateHelperText = Translations.ValueRequired;
            }
        }

        private void ValidateFromZip()
        {
            if (IsZipCodeValid(FromZip))
            {
                IsFromZipErrored = false;
                FromZipHelperText = Translations.ZipCodeHelperText;
            }
            else
            {
                IsFromZipErrored = true;
                FromZipHelperText = Translations.InvalidZipcode;
            }
        }

        private void ValidateShipping()
        {
            var res = EvaluateAsMonetary(Shipping);

            if (!res.isValid)
            {
                IsShippingErrored = true;
                ShippingHelperText = Translations.EnterMonetaryValue;
                taxRequest.Shipping = 0;
                return;
            }

            if (res.value > 0)
            {
                IsShippingErrored = false;
                ShippingHelperText = null;
            }
            else
            {
                IsShippingErrored = true;
                ShippingHelperText = Translations.ValueRequired;
            }

            taxRequest.Shipping = res.value;
        }

        private void ValidateToCountry()
        {
            if (IsCountryValid(ToCountry))
            {
                IsToCountryErrored = false;
                ToCountryHelperText = null;
            }
            else
            {
                IsToCountryErrored = true;
                ToCountryHelperText = Translations.ValueRequired;
            }
        }

        private void ValidateToState()
        {
            if (IsStateValid(ToState))
            {
                IsToStateErrored = false;
                ToStateHelperText = null;
            }
            else
            {
                IsToStateErrored = true;
                ToStateHelperText = Translations.ValueRequired;
            }
        }

        private void ValidateToZip()
        {
            if (IsZipCodeValid(ToZip))
            {
                IsToZipErrored = false;
                ToZipHelperText = Translations.ZipCodeHelperText;
            }
            else
            {
                IsToZipErrored = true;
                ToZipHelperText = Translations.InvalidZipcode;
            }
        }
    }
}
