using MahApps.Metro.Controls;
using System;
using System.Windows;


namespace BMICalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        BMI calc = new BMI();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Changes height inputs and input labels
        private void toggle_IsCheckedChanged(object sender, EventArgs e)
        {
            if(toggle.IsChecked == true)
            {
                
                tb_height.Visibility = Visibility.Hidden;
                lbl_mH.Visibility = Visibility.Hidden;

                tb_ft.Visibility = Visibility.Visible;
                tb_in.Visibility = Visibility.Visible;
                lbl_ft.Visibility = Visibility.Visible;
                lbl_in.Visibility = Visibility.Visible;
                lbl_mW.Content = "lbs";
                calc.SetUnitType("imperial");
                
            }
            else
            {
                tb_ft.Visibility = Visibility.Hidden;
                tb_in.Visibility = Visibility.Hidden;
                lbl_ft.Visibility = Visibility.Hidden;
                lbl_in.Visibility = Visibility.Hidden;

                tb_height.Visibility = Visibility.Visible;
                lbl_mH.Visibility = Visibility.Visible;
                lbl_mW.Content = "kgs";
                calc.SetUnitType("metric");
            }
  
        }

        //Calculates bmi based on user input
        private void btn_calc_Click(object sender, RoutedEventArgs e)
        {
            string height = "";
            string inch = "";
            string weight = tb_weight.Text;
            int inches = 0;

            if (calc.GetUnitType() == "metric")
            {
                height = tb_height.Text;
               
            }else
            {
                height = tb_ft.Text;
                inch = tb_in.Text;
               
            }

            string result = "";
            double h = 0;

            if(double.TryParse(height, out h))
            {
                double w = 0;
                if(double.TryParse(weight, out w))
                {
                    if(calc.GetUnitType() == "imperial")
                    {

                        if (Int32.TryParse(inch, out inches))
                        {
                            string total = FeetToInches(height, inches);
                            calc.SetHeight(Convert.ToDouble(total));

                            calc.SetWeight(w);
                            calc.Calculate();
                            result = calc.Results();
                            tb_results.Text = result;
                        }
                        else
                        {
                            result = "Inches must be a number. Please try again.";
                            tb_results.Text = result;
                        }

                    }
                    else
                    {
                        calc.SetHeight(h);

                        calc.SetWeight(w);
                        calc.Calculate();
                        result = calc.Results();
                        tb_results.Text = result;
                    }
                    
                }
                else
                {
                    result = "Height and Weight must be a number. Please try again.";
                    tb_results.Text = result;
                }


            }
            else
            {
                result = "Height and Weight must be a number. Please try again.";
                tb_results.Text = result;
            }


        }


        //Converts feet to inches and totals height
        private string FeetToInches(string _ft, int _in)
        {
            int ft = Convert.ToInt32(_ft);
            int total = (ft * 12) + _in;

            return total.ToString();
        }
    }
}
