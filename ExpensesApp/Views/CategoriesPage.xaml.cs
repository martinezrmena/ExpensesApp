using System;
using System.Collections.Generic;
using ExpensesApp.ViewModels;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class CategoriesPage : ContentPage
    {
        CategoriesVM ViewModel;

        public CategoriesPage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as CategoriesVM;
            SizeChanged += CategoriesPage_SizeChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpensesPerCategory();
        }

        void CategoriesPage_SizeChanged(object sender, EventArgs e)
        {
            string visualState = Width > Height ? "Landscape" : "Portrait";

            VisualStateManager.GoToState(titleLabel, visualState);
        }

        void Handle_Pressed(object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(exampleButton, "Focused");
        }

        void Handle_Released(object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(exampleButton, "Normal");
        }
    }
}
