using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prokotkin.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=169.254.131.3;Initial Catalog=Prokotkin;Persist Security Info=True;User ID=stud1;Password=Student1$$");
        string conText = "Data Source=169.254.131.3;Initial Catalog=Prokotkin;Persist Security Info=True;User ID=stud1;Password=Student1$$";
        public string capchaCode;

        public LoginPage()
        {
            InitializeComponent();
        }
        private void CapchaBtn_Click(object sender, RoutedEventArgs e)
        {
            CapchaGeneration();
        }

        private async Task LoginBtn_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (CapchaText.Text == capchaCode)
            {
                /*
                string sqlExpression = "SELECT Telephone FROM loginTable WHERE Telephone = '" + phoneNumberBox + "' AND Password = '" + PasswordBox + "'";
                using (SqlConnection connection = new SqlConnection(conText))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Такой пользователь есть ", "Выполнено",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Такого пользователя нет", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }*/


                /*
                using (SqlConnection connection = new SqlConnection(conText))
                using (SqlCommand command = new SqlCommand("SELECT Telephone FROM loginTable WHERE Telephone = '" + phoneNumberBox 
                    + "' AND Password = '" + PasswordBox + "'", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show("Такой пользователь есть " + reader["Telephone"].ToString(), "Выполнено",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }*/


            }
            else
            {
                MessageBox.Show("Try to enter the captcha again", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CapchaText.Text = "";
                CapchaGeneration();
            }
        }

        public void CapchaGeneration()
        {
            String allowchar = " ";

            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";

            allowchar += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' };

            String[] ar = allowchar.Split(a);

            string temp = " ";

            Random r = new Random();

            capchaCode = "";

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];

                capchaCode += temp;
            }
            textBox1.Text = capchaCode;
        }



        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
