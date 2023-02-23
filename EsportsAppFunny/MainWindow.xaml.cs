using System;
using System.Collections.Generic;
using System.IO;
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
using MySql.Data.MySqlClient;

namespace EsportsAppFunny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cs = @"server=192.169.144.133;userid=mcctc2;password=mcctcrocks;database=sr_team_2";
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
        // INSERT INTO UserTable(PlayerID, FirstName, LastName, PhoneNumber, DiscordID, GameEntry) VALUES({PlayerID.Text},'{FirstName.Text}','{LastName.Text}','{PhoneNumber.Text}','{DiscordID.Text}','{EsportsGame.Text}') ON DUPLICATE KEY UPDATE FirstName='{FirstName.Text}', LastName='{LastName.Text}', PhoneNumber='{PhoneNumber.Text}', DiscordID='{DiscordID.Text}', GameEntry='{EsportsGame.Text}';
        private void SubmitStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            using var con = new MySqlConnection(cs);
            con.Open();
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $@"INSERT IGNORE INTO UserTable(PlayerID, FirstName, LastName, PhoneNumber, DiscordID, GameEntry) VALUES ({PlayerID.Text},'{FirstName.Text}','{LastName.Text}','{PhoneNumber.Text}','{DiscordID.Text}','{EsportsGame.Text}') ON DUPLICATE KEY UPDATE FirstName='{FirstName.Text}', LastName='{LastName.Text}', PhoneNumber='{PhoneNumber.Text}', DiscordID='{DiscordID.Text}', GameEntry='{EsportsGame.Text}';";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void StudentLookup_Click(object sender, RoutedEventArgs e)
        {
            using var con = new MySqlConnection(cs);
            con.Open();
            string sql = $@"SELECT * FROM UserTable WHERE PlayerID = '{LookupID.Text}';";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                FirstNameLookup.Text = rdr.GetString(1);
                LastNameLookup.Text = rdr.GetString(2);
                PhoneNumberLookup.Text = rdr.GetString(3);
                DiscordIDLookup.Text = rdr.GetString(4);
                GameLookup.Text = rdr.GetString(5);
            }
            con.Close();
        }
    }
}
