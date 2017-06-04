using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalc
{
    public partial class Form1 : Form
    {
        // Здесь будут глобальные переменные
        string sign_operation = "";
        double number_1 = 0;
        double number_2 = 0;
        double rezultat = 0;
        bool zamena = false;


        public Form1()
        {
            InitializeComponent();
        }
        
        // происходит действие по нажатию на равно
        private void btn_rovno_Click(object sender, EventArgs e)                 // = 
        {
            number_2 = Convert.ToDouble(textBox.Text);
            if (number_2 == 0 && sign_operation == "/")
            {
                textBox.Text = "Ошибка /0";
            }
            else
            {
                //здесь будет выполняться если не равно 0
                switch (sign_operation)
                {
                    case "+":
                        rezultat = number_1 + number_2;
                        break;
                    case "-":
                        rezultat = number_1 - number_2;
                        break;
                    case "*":
                        rezultat = number_1 * number_2;
                        break;
                    case "/":
                        rezultat = number_1 / number_2;
                        break;
                }
                textBox.Text = Convert.ToString(rezultat);
                textBox_history.Text = textBox_history.Text + number_2.ToString();

                number_1 = rezultat;
                number_2 = 0;
            }
           
        }

        // кнопка "С" стерает все числа                                             
        private void btn_clear_Click(object sender, EventArgs e)                      // C
        {
            number_1 = 0;
            number_2 = 0;
            sign_operation = "";
            textBox.Text = "0";
            textBox_history.Text = "";
            zamena = false;
        }
  
        private void btn_zapita_Click(object sender, EventArgs e)                     // ,
        {
            if (!textBox.Text.Contains(","))
            {
                textBox.Text = textBox.Text + ",";
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        // крутой метод для нажатия любой цифры
        private void button_cifra_Click(object sender, EventArgs e)
        {
            string cifra = (sender as Button).Text;
            if (textBox.Text == "0")
                textBox.Text = cifra;
            else if (zamena == true)
            {
                zamena = false;
                textBox.Text = cifra;
            }
            else
                textBox.Text = textBox.Text + cifra;
        }

        // крутой метод для нажатия знака операции
        private void btn_sign_operations_Click(object sender, EventArgs e)
        {
            sign_operation = (sender as Button).Text;
            number_1 = Convert.ToDouble(textBox.Text);
            textBox_history.Text = number_1 + sign_operation;
            zamena = true;
        }
    }
}
        
