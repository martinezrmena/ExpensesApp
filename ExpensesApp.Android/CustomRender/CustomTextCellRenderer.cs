using System;
using Android.Content;
using Android.Views;
using ExpensesApp.Droid.CustomRender;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace ExpensesApp.Droid.CustomRender
{
    public class CustomTextCellRenderer: TextCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            switch (item.StyleId)
            {
                case "none":
                    cell.SetBackgroundColor(Android.Graphics.Color.AliceBlue);
                    break;
                case "checkmark":
                    cell.SetBackgroundColor(Android.Graphics.Color.Aqua);
                    break;
                case "detail-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Azure);
                    break;
                case "detail-disclosure-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Bisque);
                    break;
                case "disclosure":
                default:
                    cell.SetBackgroundColor(Android.Graphics.Color.BlanchedAlmond);
                    break;
            }

            return cell;
        }
    }
}
