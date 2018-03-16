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

        public ObservableCollection<Debtor> debtorList { get; set; } =
            new ObservableCollection<Debtor>()
            {
                new Debtor()
                {
                    Name = "Jakob",
                    Amount = 1000,
                    Note = "For bajere"

                },
                new Debtor()
                {
                    Name = "Alexander",
                    Amount = 1000,
                    Note = "Gingergebyr"
                }
            };

        private int currentIndex = -1;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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

        private Debtor currentDebtor = null;
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
        
        public ViewModel()
        {
            
        }

        public ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddDebtor)); }
        }

        private void AddDebtor()
        {
            var dlg = new AddWindow();

            Debtor debtor = new Debtor();
            dlg.DataContext = debtor;
            if (dlg.ShowDialog() == true)
            {
                debtorList.Add(debtor);
                CurrentIndex = debtorList.Count - 1;
                CurrentDebtor = debtor;
            }

        }

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

        public ICommand _editCommand;

        public ICommand EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand(EditDebtor, Can_Execute)); }
        }

        private void EditDebtor()
        {
            var dlg = new AddWindow();
            dlg.Title = "Edit debitor";
           

            Debtor temp = new Debtor();
            temp.Name = CurrentDebtor.Name;
            temp.Amount = CurrentDebtor.Amount;
            temp.Note = CurrentDebtor.Note;
            dlg.DataContext = temp;
            if (dlg.ShowDialog() == true)

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

        public ICommand _detailCommand;

        public ICommand DetailCommand
        {
            get { return _detailCommand ?? (_detailCommand = new RelayCommand(DebtorDetail)); }
        }

        private void DebtorDetail()
        {

        }
    }
}
