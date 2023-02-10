/**
 * @file MainWindow.xaml.cs
 * @author Connor Walsh
 * @date 2023-2-10
 * @brief MainWindow code for the database practice assignment
 * 
 * This file contians the implementation for the buttons and textbox for the MainWindow along with its constructor
 */

using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
//using System.Data.OleDb;

namespace DatabasePractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\SampleDatabase1.accdb");
        }
        private void Asset_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                //data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + " " + read[3].ToString() + "\n";
                data += "Employee ID: " + read[0].ToString() + "\n";
                data += "Asset ID: " + read[1].ToString() + "\n";
                data += "Asset Description: " + read[2].ToString() + "\n";
                data += "Asset Name: " + read[3].ToString() + "\n" + "\n"; 
                MyTextBox.Text = data;
            }
            //Modify your code so you can display all fields of the Assets table
            //Modify your program so you have a similar button that will display contents of Employees table
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "Employee ID: " + read[0].ToString() + "\n";
                data += "Employee Firstname: " + read[1].ToString() + "\n";
                data += "Employee Lastname: " + read[2].ToString() + "\n" + "\n";
                MyTextBox.Text = data;
            }

        }
    }
}
