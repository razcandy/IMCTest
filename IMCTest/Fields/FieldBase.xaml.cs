using IMCTest.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMCTest.Fields
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public abstract partial class FieldBase : Grid
	{
		// Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public const double FieldHeight = 68;

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public FieldBase()
		{
			InitializeComponent();
			SetupBindings();

			MainGrid.Children.Add(Field, 1, 1);
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected abstract View Field { get; }

		public string HelperText
		{
			get => (string)GetValue(HelperTextProperty);
			set => SetValue(HelperTextProperty, value);
		}

		public static readonly BindableProperty HelperTextProperty = BindableProperty.Create
		(
			propertyName: nameof(HelperText),
			returnType: typeof(string),
			declaringType: typeof(FieldBase),
			defaultValue: null
		);

		public bool IsErrored
		{
			get => (bool)GetValue(IsErroredProperty);
			set => SetValue(IsErroredProperty, value);
		}

		public static readonly BindableProperty IsErroredProperty = BindableProperty.Create
		(
			propertyName: nameof(IsErrored),
			returnType: typeof(bool),
			declaringType: typeof(FieldBase),
			defaultValue: false,
			propertyChanged: OnIsErroredPropertyChanged
		);

		public string Title
		{
			get => (string)GetValue(TitleProperty);
			set => SetValue(TitleProperty, value);
		}

		public static readonly BindableProperty TitleProperty = BindableProperty.Create
		(
			propertyName: nameof(Title),
			returnType: typeof(string),
			declaringType: typeof(FieldBase),
			defaultValue: null
		);

		public string ValueString
		{
			get => (string)GetValue(ValueStringProperty);
			protected set => SetValue(ValueStringProperty, value);
		}

		public static readonly BindableProperty ValueStringProperty = BindableProperty.Create
		(
			propertyName: nameof(ValueString),
			returnType: typeof(string),
			declaringType: typeof(FieldBase),
			defaultValue: null,
			defaultBindingMode: BindingMode.OneWayToSource
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static void OnIsErroredPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var fb = (FieldBase)bindable;
			var newValueBool = (bool)newValue;

			if (newValueBool)
			{
				fb.HelperTextLabel.TextColor = ResourceHelper.ErroredTextColor;
				fb.TitleLabel.TextColor = ResourceHelper.ErroredTextColor;
				fb.BackgroundFrame.BorderColor = ResourceHelper.ErroredTextColor;
			}
			else
			{
				fb.HelperTextLabel.TextColor = ResourceHelper.DefaultTextColor;
				fb.TitleLabel.TextColor = ResourceHelper.DefaultTextColor;
				fb.BackgroundFrame.BorderColor = Color.White;
			}
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void SetupBindings()
		{
			MainGrid.BindingContext = this;
			TitleLabel.BindingContext = this;
			HelperTextLabel.BindingContext = this;

			TitleLabel.SetBinding(Label.TextProperty, nameof(Title));
			HelperTextLabel.SetBinding(Label.TextProperty, nameof(HelperText));
		}
	}
}