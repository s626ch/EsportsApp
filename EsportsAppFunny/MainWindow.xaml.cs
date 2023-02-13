using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace EsportsAppFunny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void IDValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PhoneValidationTextBox(object sender, TextCompositionEventArgs j)
        {
            string rgxstr = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
            Regex pregex = new Regex(rgxstr);
            j.Handled = pregex.IsMatch(j.Text);
        }
        private void DiscordValidationTextBox(object sender, TextCompositionEventArgs d)
        {
            Regex dregex = new Regex("^.{3,32}#[0-9]{4}$");
            d.Handled = dregex.IsMatch(d.Text);
        }
    }
}
