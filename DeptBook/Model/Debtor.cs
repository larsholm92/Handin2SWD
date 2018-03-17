using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DeptBook.Annotations;

namespace DeptBook.Model
{
    public class Debtor:INotifyPropertyChanged
    {
        private string name;
        private int amount;
        private string note;
        private ObservableCollection<Transaction> transactionList = new ObservableCollection<Transaction>();
        public string Name {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
            
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }

        public string Note {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }

        internal ObservableCollection<Transaction> TransactionList { get => transactionList; set => transactionList = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Function to add a transaction
        public void AddTransaction(int amount, string note)
        {
            Transaction t = new Transaction
            {
                TAmount = amount,
                TNote = note
            };
            TransactionList.Add(t);

        }

        //Function to calculate the total amount the debtor owes
        public void CalcAmount()
        {
            int sum = 0;
            foreach (var x in TransactionList)
            {
                sum += x.TAmount;
            }
            Amount=sum;
        }
    }
}
