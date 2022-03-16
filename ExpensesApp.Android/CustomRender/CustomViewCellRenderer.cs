using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ExpensesApp.Droid.CustomRender
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _cell;
        private bool _isSelected;
        private Drawable _defaultBackground;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;
            _defaultBackground = _cell.Background;

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                    _cell.SetBackgroundColor(Color.FromHex("#E6E6E6").ToAndroid());
                }
                else
                {
                    _cell.Background = _defaultBackground;
                }
            }
        }
    }
}
