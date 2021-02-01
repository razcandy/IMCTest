using IMCTest.Fields;
using IMCTest.Helpers;
using IMCTest.Values;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IMCTest
{
	public partial class MainPage : ContentPage
	{
		// Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainPageVM();
			SetupBindings();
			SetupStyles();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void SetupBindings()
		{
			FromCountrySpinner.BindingContext = BindingContext;
			FromCountrySpinner.ItemSource = new List<string> { "US" };
			FromCountrySpinner.SetBinding(FieldSpinner.SelectedItemProperty, nameof(MainPageVM.FromCountry));
			FromCountrySpinner.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsFromCountryErrored));
			FromCountrySpinner.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.FromCountryHelperText));

			FromStateSpinner.BindingContext = BindingContext;
			FromStateSpinner.SetBinding(FieldSpinner.ItemSourceProperty, nameof(MainPageVM.StatesList));
			FromStateSpinner.SetBinding(FieldSpinner.SelectedItemProperty, nameof(MainPageVM.FromState));
			FromStateSpinner.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsFromStateErrored));
			FromStateSpinner.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.FromStateHelperText));

			FromZipEntry.BindingContext = BindingContext;
			FromZipEntry.SetBinding(FieldEntry.TextProperty, nameof(MainPageVM.FromZip));
			FromZipEntry.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsFromZipErrored));
			FromZipEntry.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.FromZipHelperText));

			FromCity.BindingContext = BindingContext;
			FromCity.SetBinding(FieldEntry.TextProperty, nameof(MainPageVM.FromCity));
			FromCity.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsFromCityErrored));
			FromCity.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.FromCityHelperText));

			ToCountrySpinner.BindingContext = BindingContext;
			ToCountrySpinner.ItemSource = new List<string> { "US" };
			ToCountrySpinner.SetBinding(FieldSpinner.SelectedItemProperty, nameof(MainPageVM.ToCountry));
			ToCountrySpinner.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsToCountryErrored));
			ToCountrySpinner.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.ToCountryHelperText));

			ToStateSpinner.BindingContext = BindingContext;
			ToStateSpinner.SetBinding(FieldSpinner.ItemSourceProperty, nameof(MainPageVM.StatesList));
			ToStateSpinner.SetBinding(FieldSpinner.SelectedItemProperty, nameof(MainPageVM.ToState));
			ToStateSpinner.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsToStateErrored));
			ToStateSpinner.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.ToStateHelperText));

			ToZipEntry.BindingContext = BindingContext;
			ToZipEntry.SetBinding(FieldEntry.TextProperty, nameof(MainPageVM.ToZip));
			ToZipEntry.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsToZipErrored));
			ToZipEntry.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.ToZipHelperText));

			ToCity.BindingContext = BindingContext;
			ToCity.SetBinding(FieldEntry.TextProperty, nameof(MainPageVM.ToCity));
			ToCity.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsToCityErrored));
			ToCity.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.ToCityHelperText));

			ShippingEntry.BindingContext = BindingContext;
			ShippingEntry.SetBinding(FieldEntry.TextProperty, nameof(MainPageVM.Shipping));
			ShippingEntry.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsShippingErrored));
			ShippingEntry.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.ShippingHelperText));

			AmountEntry.BindingContext = BindingContext;
			AmountEntry.SetBinding(FieldEntry.TextProperty, nameof(MainPageVM.Amount));
			AmountEntry.SetBinding(FieldBase.IsErroredProperty, nameof(MainPageVM.IsAmountErrored));
			AmountEntry.SetBinding(FieldBase.HelperTextProperty, nameof(MainPageVM.AmountHelperText));

			ResetButton.SetBinding(Button.CommandProperty, nameof(MainPageVM.ResetCommand));
			TaxButton.SetBinding(Button.CommandProperty, nameof(MainPageVM.SubmitCommand));

			MessageLabel.BindingContext = BindingContext;
			MessageLabel.SetBinding(Label.TextProperty, nameof(MainPageVM.UserMessage));
			MessageLabel.SetBinding(Label.TextColorProperty, nameof(MainPageVM.IsUserMessageErrored),
				converter: new BoolToTConverter<Color>
					(ResourceHelper.ErroredTextColor, ResourceHelper.DefaultTextColor));
		}

		private void SetupStyles()
		{
			ToLabel.Style = ResourceHelper.LabelHeaderStyle;
			FromLabel.Style = ResourceHelper.LabelHeaderStyle;
			ValuesLabel.Style = ResourceHelper.LabelHeaderStyle;
		}
	}
}
