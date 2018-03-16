using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DeptBook.Annotations;

namespace DeptBook
{
    class Transaction
    {
        private int amount;
        private string note;
        public int TAmount
        {
            get
            {
                return amount; 

            }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        public string TNote
        {
            get
            {
                return note; 

            }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
