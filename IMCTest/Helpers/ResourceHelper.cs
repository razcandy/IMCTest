using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IMCTest.Helpers
{
	public static class ResourceHelper
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public const int DefaultCornerRadius = 3;

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static Style ButtonDefaultStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters =
                    {
                        new Setter { Property = Button.CornerRadiusProperty, Value = DefaultCornerRadius },
                    },
                };
            }
        }

        public static Color DefaultTextColor => Color.FromHex("#EEEEEE");

        public static Style EntryDefaultStyle
        {
            get
            {
                return new Style(typeof(Entry))
                {
                    Setters =
                    {
                        new Setter { Property = Entry.TextColorProperty, Value = DefaultTextColor },
                    },
                };
            }
        }

        public static Color ErroredTextColor => Color.Red;

        public static Style FrameDefaultStyle
        {
            get
            {
                return new Style(typeof(Frame))
                {
                    Setters =
                    {
                        new Setter { Property = Frame.CornerRadiusProperty, Value = DefaultCornerRadius },
                        new Setter { Property = Frame.BackgroundColorProperty, Value = Color.Transparent },
                    },
                };
            }
        }

        public static Style LabelDefaultStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    ApplyToDerivedTypes = true,
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = DefaultTextColor },
                    },
                };
            }
        }

        public static Style LabelHeaderStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 24 },
                    },
                };
            }
        }

        public static Style PickerDefaultStyle
        {
            get
            {
                return new Style(typeof(Picker))
                {
                    Setters =
                    {
                        new Setter { Property = Picker.TextColorProperty, Value = DefaultTextColor },
                    },
                };
            }
        }

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static void Load()
		{
            var rd = new ResourceDictionary();
            rd.Add(ButtonDefaultStyle);
            rd.Add(EntryDefaultStyle);
            rd.Add(FrameDefaultStyle);
            rd.Add(LabelDefaultStyle);
            rd.Add(PickerDefaultStyle);

            rd.Add(nameof(LabelHeaderStyle), LabelHeaderStyle);

            App.Current.Resources = rd;
        }
    }
}
