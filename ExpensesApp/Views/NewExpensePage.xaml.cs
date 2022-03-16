using System;
using System.Collections.Generic;
using ExpensesApp.ViewModels;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class NewExpensePage : ContentPage
    {

        public NewExpensesVM ViewModel;
        public NewExpensePage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as NewExpensesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpensesStatus();

            int count = 0;
            foreach (var es in ViewModel.ExpensesStatuses)
            {
                //We create the cell
                var cell = new SwitchCell { Text = es.Name };

                //We set the binding for the content in the cell
                Binding binding = new Binding();
                binding.Source = ViewModel.ExpensesStatuses[count];
                binding.Path = nameof(es.Status);
                binding.Mode = BindingMode.TwoWay;
                cell.SetBinding(SwitchCell.OnProperty, binding);

                //we create the section
                var section = new TableSection("Statuses");
                section.Add(cell);

                //we set the section
                expenseTableView.Root.Add(section);

                count++;
            }
        }
    }
}
