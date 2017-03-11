using System;


namespace BMICalculator
{
    /// <summary>
    /// Class used to calculate BMI for both metric and imperial
    /// </summary>
    class BMI
    {
        //formula for meters: weight / (height * height)  ****height in meters; weight in kilograms
        //formula in imperial: (weight / (height * height)) * 703     *****height in inches; weight in pounds

        private double weight;
        private double height;
        private double result;
        private string unit_type;

        public BMI()
        {
            unit_type = "metric";
        }

        public void SetHeight(double _height)
        {
            height = _height;
        }

        public void SetWeight(double _weight)
        {
            weight = _weight;
        }

        public void SetUnitType(string unit)
        {
            unit_type = unit;
        }
        public string GetUnitType()
        {
            return unit_type;
        }
       

        public void Calculate()
        {
            result = 0;
            if(unit_type == "metric")
            {
                
                result = weight / (Math.Pow(height, 2));
            }
            else
            {
                result = (weight / (Math.Pow(height, 2)));
                result = result * 703;
            }
        }

        public string Results()
        {
            if(result >= 18.5 && result <= 25)
            {
                return "Your BMI is " + Math.Round(result, 1) + "\nYou are within the ideal weight range.";
            }
            else
            {
                if(result < 18.5)
                {
                    return "Your BMI is " + Math.Round(result, 1) + "\nYou are underweight. You should see your doctor.";
                }
                else
                {
                    return "Your BMI is " + Math.Round(result, 1) + "\nYou are overweight. You should see your doctor.";
                }
            }
        }
    }
}
