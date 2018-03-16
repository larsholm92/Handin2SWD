using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DeptBook.Model;
using DeptBook.ViewModel;

namespace DeptBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Debtor Jakob = new Debtor()
        {
            Name = "Jakob",
            Amount = 1000,
            Note = "Gebyr"
        };
        Debtor Alexander = new Debtor()
        {
            Name = "GuessWho",
            Amount = 10000,
            Note = "GingerGebyr"
        };


        public MainWindow()
        {
            InitializeComponent();
            ViewModel.ViewModel vm = new ViewModel.ViewModel();
     
            DataContext = vm;
        }
    }
}
