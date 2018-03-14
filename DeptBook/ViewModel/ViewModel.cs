using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DeptBook.Annotations;
using DeptBook.Model;

namespace DeptBook.ViewModel
{
    class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        DeptBookModel deptModel = new DeptBookModel();

        public int Balance
        {
            get => deptModel.Balance;
            set
            {
                deptModel.Balance = deptModel.CalcBalance();
                OnPropertyChanged();
            }
        }
    }
}
