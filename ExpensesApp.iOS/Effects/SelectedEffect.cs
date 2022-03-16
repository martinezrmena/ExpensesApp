using System;
using System.ComponentModel;
using ExpensesApp.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("LPA")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.iOS.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        UIColor selectedColor;

        protected override void OnAttached()
        {
            selectedColor = new UIColor(176.0f / 255.0f, 152.0f / 255.0f, 164.0f / 255.0f, 255.0f / 255.0f);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsFocused")
            {
                if (Control.BackgroundColor != selectedColor)
                {
                    Control.BackgroundColor = selectedColor;
                }
                else
                {
                    Control.BackgroundColor = UIColor.White;
                }
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
