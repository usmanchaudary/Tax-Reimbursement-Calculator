using System.Text;

namespace TaxReimburser
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var actualSalary = Convert.ToDouble(salary.Text);
            var productPrice = Convert.ToDouble(price.Text);
            var summary = calculator(actualSalary, productPrice);
            summaryText.Text = summary;
        }
        static string calculator(double actualSalary, double productPrice)
        {
            var stringBuilder = new StringBuilder();
            var actualInhandSalary = actualSalary / 2; // 520000 / 2 = 260000
            var beforemonthlyTax = calculateTax(actualInhandSalary * 12) / 12;
            var afterTaxSalaryinOneAcc = actualInhandSalary - beforemonthlyTax; // 260000 - calculateTax = 232000

            var afterTaxSalaryinBothAcc = afterTaxSalaryinOneAcc * 2; // 232000 * 2 = 464000

            Console.WriteLine("Actual Salary: " + actualSalary);
            //use StringBuilders for better performance and to build a string
            stringBuilder.AppendLine("Actual Salary: " + actualSalary);
            var salaryAfterPurchase = actualSalary - productPrice;    // 520000 - 100000 = 420000
            var dividedSalary = salaryAfterPurchase / 2;   // 420000 / 2 = 210000
            Console.WriteLine("Salary We will get after Purchase: " + salaryAfterPurchase);
            stringBuilder.AppendLine("Salary We will get after Purchase: " + salaryAfterPurchase);
            var monthlyTax = calculateTax(dividedSalary * 12) / 12; // calculateTax = 16000
            var afterTaxSalary = dividedSalary - monthlyTax; // 210000 - 16000 = 194000
            var revertSalary = afterTaxSalary * 2; // 194000 * 2 = 388000
            Console.WriteLine("Salary We will get after Purchase + Tax: " + revertSalary);
            stringBuilder.AppendLine("Salary We will get after Purchase + Tax: " + revertSalary);
            var actualPriceOfProductWePaid = afterTaxSalaryinBothAcc - revertSalary; // 464000 - 388000 = 76000

            Console.WriteLine("Actual Price of the product: " + productPrice);
            stringBuilder.AppendLine("Actual Price of the product: " + productPrice);
            Console.WriteLine("actual Price Of Product We Paid)" + " : " + actualPriceOfProductWePaid);
            stringBuilder.AppendLine("actual Price Of Product We Paid)" + " : " + actualPriceOfProductWePaid);
            var benefit = productPrice - actualPriceOfProductWePaid; // 100000 - 76000 = 24000
            Console.WriteLine("Benefit amount we got: " + benefit);
            stringBuilder.AppendLine("Benefit amount we got: " + benefit);
            Console.WriteLine("-------------------------------------------------");
            stringBuilder.AppendLine("-------------------------------------------------");
            //salary we will get without this method
            Console.WriteLine("Salary We will get without this method: " + (afterTaxSalaryinBothAcc - productPrice));
            stringBuilder.AppendLine("Salary We will get without this method: " + (afterTaxSalaryinBothAcc - productPrice));
            return stringBuilder.ToString();
        }

        static double calculateTax(double amount)
        {

            double taxAmount = 0;
            if (amount > 600000 && amount <= 1200000)
            {
                amount -= 600000;
                taxAmount = amount * 0.025;
            }
            else if (amount > 1200000 && amount <= 2400000)
            {
                amount -= 1200000;
                taxAmount = 15000 + amount * 0.125;
            }
            else if (amount > 2400000 && amount <= 3600000)
            {
                amount -= 2400000;
                taxAmount = 165000 + amount * 0.225;
            }
            else if (amount > 3600000 && amount <= 6000000)
            {
                amount -= 3600000;
                taxAmount = 435000 + amount * 0.275;
            }
            else if (amount > 6000000)
            {
                amount -= 6000000;
                taxAmount = 1095000 + amount * 0.35;
            }
            return Math.Round(taxAmount);

        }
    }

}
