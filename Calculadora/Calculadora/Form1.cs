using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        double valor = 0;
        string operations = "";
        string checking_equals = "NoOperations";
        bool check_operation = false;
        string type = "";
        int i = 0;
        int joperations = 0;
        string operationsbefore = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button_Click(object sender, EventArgs e)
        {
            if (Tela.Text == "0" || checking_equals == "YesOperations")
            {
                checking_equals = "NoOperations";
                Tela.Clear();
            }
            Button b = (Button)sender;
            Tela.Text = Tela.Text + b.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Tela.Text = "0";
        }
        private void operations_Click(object sender, EventArgs e)
        {
            i += 1;
            Button b = (Button)sender;
            operationsbefore = operations;
            operations = b.Text;
            type = "operation";
            if (check_operation)
            {
                if(i > 1) {
                    string op = operations;
                    if (operationsbefore != "") { op = operationsbefore;  } 
                    switch (op)
                    {
                        case "+":
                            valor = (valor + Convert.ToDouble(Tela.Text));
                            break;
                        case "-":
                            valor = (valor - Convert.ToDouble(Tela.Text));
                            break;
                        case "*":
                            valor = (valor * Convert.ToDouble(Tela.Text));
                            break;
                        case "/":
                            valor = (valor / Convert.ToDouble(Tela.Text));
                            break;
                        default:
                            break;
                    }
                }
               Calc_Equals(type);
            }
            else
            {
                valor = Convert.ToDouble(Tela.Text);
                label2.Text = valor.ToString() + "" + operations;
                Tela.Text = "0";
            }
            check_operation = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            type = "equals";
            Calc_Equals(type);
        }
        public void Calc_Equals(string type) {
            checking_equals = "YesOperations";
            if (type == "operation")
            {
                label2.Text = valor + "" + operations;
                Tela.Text = "0";

            }
            else
            {
                string FinalValue = "";
                switch (operations)
                {
                    case "+":
                        FinalValue = (valor + Convert.ToDouble(Tela.Text)).ToString();
                        break;
                    case "-":
                        FinalValue = (valor - Convert.ToDouble(Tela.Text)).ToString();
                        break;
                    case "*":
                        FinalValue = (valor * Convert.ToDouble(Tela.Text)).ToString();
                        break;
                    case "/":
                        FinalValue = (valor / Convert.ToDouble(Tela.Text)).ToString();
                        break;
                    default:
                        break;
                }
                Tela.Text = FinalValue;
                label2.Text = "";
                check_operation = false; 
                i = 0;
            }
        }
    }
}
