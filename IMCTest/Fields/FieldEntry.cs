using Xamarin.Forms;

namespace IMCTest.Fields
{
	public class FieldEntry : FieldBase
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Entry nativeEntry;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public FieldEntry() : base() { }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        protected override View Field => NativeEntry;

		protected Entry NativeEntry
		{
            get
			{
                if (nativeEntry != null) return nativeEntry;

				nativeEntry = new Entry
				{
					BindingContext = this,
					BackgroundColor = Color.Transparent,
					ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
				};
				nativeEntry.SetBinding(Entry.TextProperty, nameof(Text), BindingMode.TwoWay);

				return nativeEntry;
			}
		}

		public Keyboard Keyboard
		{
			get => NativeEntry.Keyboard;
			set => NativeEntry.Keyboard = value;
		}

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		public static readonly BindableProperty TextProperty = BindableProperty.Create
		(
			propertyName: nameof(Text),
			returnType: typeof(string),
			declaringType: typeof(FieldEntry),
			defaultValue: null,
			propertyChanged: OnTextPropertyChanged,
			defaultBindingMode: BindingMode.TwoWay
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var e = (FieldEntry)bindable;
			e.ValueString = e.Text;
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
