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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpensesPerCategory();
        }
    }
}
