using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IMCTest.Fields
{
	public class FieldSpinner : FieldBase
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Picker nativePicker;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public FieldSpinner() : base() { }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected override View Field => NativePicker;

        protected Picker NativePicker
		{
            get
			{
                if (nativePicker != null) return nativePicker;

                nativePicker = new Picker
                {
                    BindingContext = this,
                };
                nativePicker.SetBinding(Picker.ItemsSourceProperty, nameof(ItemSource));
                nativePicker.SetBinding(Picker.SelectedItemProperty, nameof(SelectedItem));

                return nativePicker;
            }
		}

        public IList<string> ItemSource
        {
            get => (IList<string>)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }

        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create
        (
            propertyName: nameof(ItemSource),
            returnType: typeof(IList<string>),
            declaringType: typeof(FieldSpinner),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay
        );

        public string SelectedItem
		{
            get => (string)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
		}

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create
        (
            propertyName: nameof(SelectedItem),
            returnType: typeof(string),
            declaringType: typeof(FieldSpinner),
            defaultValue: null,
            propertyChanged: OnSelectedItemPropertyChanged,
            defaultBindingMode: BindingMode.TwoWay
        );

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void OnSelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var f = (FieldSpinner)bindable;
            f.ValueString = f.SelectedItem;
        }

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
