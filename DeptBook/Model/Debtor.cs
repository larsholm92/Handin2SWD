﻿using System;
using System.Collections.Generic;
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
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
