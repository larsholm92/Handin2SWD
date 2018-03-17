using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DeptBook.Annotations;
using DeptBook.Model;
using DeptBook.ViewModel;
using MvvmFoundation.Wpf;

namespace DeptBook.ViewModel
{
    class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Creating a collection to store model-elements
        public ObservableCollection<Debtor> debtorList { get; set; } =
            new ObservableCollection<Debtor>();

        private int currentIndex = -1;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Property to bind selectedIndex to
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //Instanses of the models to be used for dataContexts for new windows
        private Debtor currentDebtor = null;
        Transaction t = null;
        private Debtor debtor = null;
        
        //Property to controls which Debtor is changed
        public Debtor CurrentDebtor
        {
            get { return currentDebtor; }
            set
            {
                if (currentDebtor != value)
                {
                    currentDebtor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //Command to add new debtor
        public ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddDebtor)); }
        }
        private void AddDebtor()
        {
            var dlg = new AddWindow();  //Creating a new window. This windows is getting a debtor as DataContext
            debtor = new Debtor();
            dlg.DataContext = debtor;
            if (dlg.ShowDialog() == true)
            {
                debtorList.Add(debtor);
                CurrentIndex = debtorList.Count - 1;
                CurrentDebtor = debtor;
            }

        }

        //Command to delete a debtor
        public ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteDebtor)); }
        }
        private void DeleteDebtor()
        {
            MessageBoxResult res = MessageBox.Show("You are about to delete a debtor - Continue?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                if (debtorList.Count > 0 && CurrentIndex >= 0)
                {
                    debtorList.Remove(CurrentDebtor);       
                }
            }


        }

        //Command to edit a debtor
        public ICommand _editCommand;
        public ICommand EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand(EditDebtor, Can_Execute)); }
        }
        private void EditDebtor()
        {
            var dlg = new AddWindow();
            dlg.Title = "Edit debitor";
           

            Debtor temp = new Debtor(); //Creating a temporary debtor to edit
            temp.Name = CurrentDebtor.Name;
            temp.Amount = CurrentDebtor.Amount;
            temp.Note = CurrentDebtor.Note;
            dlg.DataContext = temp;
            if (dlg.ShowDialog() == true) //If confirm is pressed, the temporary debtor is copied to the current debtor

            {
                currentDebtor.Name = temp.Name;
                currentDebtor.Amount = temp.Amount;
                currentDebtor.Note = temp.Note;
            }
            
        }

        private bool Can_Execute()
        {
            if (CurrentIndex >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Command to open a new details-window
        public ICommand _detailCommand;

        public ICommand DetailCommand
        {
            get { return _detailCommand ?? (_detailCommand = new RelayCommand(DebtorDetail)); }
        }

        private void DebtorDetail()
        {
            var dlg = new Detail();
            dlg.Title = "Debitor Details";
            dlg.DataContext = currentDebtor.TransactionList; //Setting the views datacontext
            dlg.Show();
        }

        //Command to add a transaction
        public ICommand _addTCommand;
        public ICommand AddTCommand
        {
            get { return _addTCommand ?? (_addTCommand = new RelayCommand(AddTransaction)); }
        }

        private void AddTransaction()
        {
            var dlg = new AddTWindow();
            t = new Transaction();
            dlg.DataContext = t; //Setting the views datacontext
            if (dlg.ShowDialog() == true)
            {
                currentDebtor.AddTransaction(t.TAmount,t.TNote);
                currentDebtor.CalcAmount(); //Calculates the total amount the debtor owes
                NotifyPropertyChanged();
            }
            
        }
        
        
    }
}
