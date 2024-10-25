using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidLab_question1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string registrationDigits = "44";
            string secondLetters = "UA";
            string movieChars = "FawadSalman";
            string specialChars = "@$%&*";

            string password = GeneratePassword(registrationDigits, secondLetters, movieChars, specialChars);

            
            textBox1.Text = password;

          
            Regex passwordRegex = new Regex(@"^(?=.*[^\d\w#])(?=.{14}$)");
            if (passwordRegex.IsMatch(password))
            {
                MessageBox.Show("Password is valid!");
            }
            else
            {
                MessageBox.Show("Password does not meet the requirements.");
            }

        }
        static string GeneratePassword(string regDigits, string letters, string movieChars, string specialChars)
        {
            Random rand = new Random();

            string password = regDigits + letters + movieChars;

         
            if (password.Length > 14)
            {
                password = password.Substring(0, 14);
            }
            else
            {
                
                while (password.Length < 14)
                {
                    password += specialChars[rand.Next(specialChars.Length)];
                }
            }

            
            if (!Regex.IsMatch(password, @"[^\w\d#]"))
            {
               
                char specialChar = specialChars[rand.Next(specialChars.Length)];
                int randomIndex = rand.Next(password.Length);
                password = password.Remove(randomIndex, 1).Insert(randomIndex, specialChar.ToString());
            }

            
            char[] passwordArray = password.ToCharArray();
            Array.Sort(passwordArray, (a, b) => rand.Next(-1, 2));

            return new string(passwordArray);
        }
    }
}
