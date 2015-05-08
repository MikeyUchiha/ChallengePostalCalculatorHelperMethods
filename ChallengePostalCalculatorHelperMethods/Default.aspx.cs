using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateShipping(0.15);
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateShipping(0.25);
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateShipping(0.45);
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            checkShippingOption();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            checkShippingOption();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            checkShippingOption();
        }

        private void calculateShipping(double multiplier)
        {
            if (widthTextBox.Text.Trim().Length == 0 || heightTextBox.Text.Trim().Length == 0)
                return;

            double width = 0.0;
            double height = 0.0;
            double length = 0.0;
            if (!Double.TryParse(widthTextBox.Text, out width))
                return;
            if (!Double.TryParse(heightTextBox.Text, out height))
                return;
            if(!(lengthTextBox.Text.Trim().Length == 0))
            {
                if (!Double.TryParse(lengthTextBox.Text, out length))
                    return;
            }

            double totalShippingCost = calculateTotalShippingCost(width, height, multiplier, length);
            displayShippingCost(totalShippingCost);
        }

        private double calculateTotalShippingCost(double width, double height, double multiplier, double length = 0.0)
        {
            double result = 0.0;

            double volumeOfParcel = calculateVolumeOfParcel(width, height, length);
            double totalShippingCost = volumeOfParcel * multiplier;
            result = totalShippingCost;

            return result;
        }

        private double calculateVolumeOfParcel(double width, double height, double length = 0)
        {
            double result = 0.0;

            if (length != 0)
                result = width * height * length;
            else
                result = width * height;

            return result;
        }

        private void displayShippingCost(double totalShippingCost)
        {
            resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", totalShippingCost);
        }

        private void checkShippingOption()
        {
            if (groundRadioButton.Checked)
                calculateShipping(0.15);
            if (airRadioButton.Checked)
                calculateShipping(0.25);
            if (nextDayRadioButton.Checked)
                calculateShipping(0.45);
        }
    }
}