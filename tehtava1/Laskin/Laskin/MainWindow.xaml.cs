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

namespace Laskin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string formula;
        private TextBox formulaField;
        private bool calculated = false;
        public MainWindow()
        {
            InitializeComponent();
            formulaField = FormulaField;
        }

        private void CalculatorInput(object sender, RoutedEventArgs e)
        {
            if (calculated)
            {
                formula = "";
                formulaField.Text = "";
                calculated = false;
            }
            string input = ((Button)sender).Tag.ToString();
            double eval;
            switch (input)
            {
                case "=":
                    try
                    {
                        eval = Evaluate(formula);
                    }
                    catch (ArgumentException r)
                    {
                        formulaField.Text = "Invalid expression";
                        return;
                    }
                    formulaField.Text = eval.ToString();
                    calculated = true;
                    return;
                case "C":
                    formula = "";
                    break;
                case "CE":
                    if (formula != null)
                    {
                        int i = formula.Length - 1;
                        while (i >= 0 && Char.IsDigit(formula[i]))
                        {
                            formula = formula.Remove(i--, 1);
                        }
                    }
                    break;
                case "DEL":
                    if (formula.Length > 0)
                    {
                        formula = formula.Remove(formula.Length - 1, 1);
                    }
                    break;
                default:
                    formula += input;
                    break;
            }
            formulaField.Text = formula;
        }
        private double Evaluate(string expression)
        {
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", string.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);
                return double.Parse((string)row["expression"]);
            }
            catch (Exception e)
            {
                throw new ArgumentException();
            }
        }

    }

}


