using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Factorial
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtData.Text);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            long rfact = rFactorial(n);
            lstBox.Items.Add("\nrecursive = " + rfact);

            watch.Stop();
            var elapsedTicks = watch.ElapsedTicks;

            string result = elapsedTicks + " Ticks, " + elapsedTicks / 10000.0 + " ms";
            lstBox.Items.Add(result);

            watch = System.Diagnostics.Stopwatch.StartNew();

            long fact = Factorial(n);
            lstBox.Items.Add("\nloop = " + fact);

            watch.Stop();
            elapsedTicks = watch.ElapsedTicks;
            string result = elapsedTicks + " Ticks, " + elapsedTicks / 10000.0 + " ms";
            lstBox.Items.Add(result);
        }
        private long rFactorial(long f)
        {
            if (f == 1)
                return 1;
            else
                return rFactorial(f - 1) * f;
        }

        private long Factorial(long f)
        {
            f = 1;
            for (int i = 2; i <= f; i++)
                f *= i;
            return f;
        }
    }
}
