using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ExpensesApp.Models;
using ExpensesApp.Resources;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpensesVM : INotifyPropertyChanged
    {
        private string expenseName;
        public string ExpenseName
        {
            get { return expenseName; }
            set
            {
                expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        private string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }

        private float expenseAmmount;
        public float ExpenseAmmount
        {
            get { return expenseAmmount; }
            set
            {
                expenseAmmount = value;
                OnPropertyChanged("ExpenseAmmount");
            }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        private string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }

        public Command SaveExpenseCommand
        {
            get;
            set;
        }

        public ObservableCollection<string> Categories
        {
            get;
            set;
        }

        public ObservableCollection<ExpensesStatus> ExpensesStatuses
        {
            get;
            set;
        }

        public NewExpensesVM()
        {
            Categories = new ObservableCollection<string>();
            ExpensesStatuses = new ObservableCollection<ExpensesStatus>();
            ExpenseDate = DateTime.Now;
            SaveExpenseCommand = new Command(InsertExpense);
            GetCategories();
            GetExpensesStatus();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense()
        {
            var vm = this;
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Ammount = ExpenseAmmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            int response = Expense.InsertExpense(expense);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "OK");
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add(AppResources.housingCategory);
            Categories.Add(AppResources.debtCategory);
            Categories.Add(AppResources.healthCategory);
            Categories.Add(AppResources.foodCategory);
            Categories.Add(AppResources.personalCategory);
            Categories.Add(AppResources.travelCategory);
            Categories.Add(AppResources.otherCategory);
        }

        public void GetExpensesStatus()
        {
            ExpensesStatuses.Clear();
            ExpensesStatuses.Add(new ExpensesStatus()
            {
                Name = "Random",
                Status = true
            });

            ExpensesStatuses.Add(new ExpensesStatus()
            {
                Name = "Random 2",
                Status = true
            });

            ExpensesStatuses.Add(new ExpensesStatus()
            {
                Name = "Random 3",
                Status = false
            });
        }

        public class ExpensesStatus
        {
            public string Name { get; set; }
            public bool Status { get; set; }
        }
    }
}