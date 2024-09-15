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

namespace Fibonacci
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtInput.Text);

            lst.Items.Add("Recursive Fibonacci:");
            for (int i = 1; i <= n; i++)
                lst.Items.Add(Fibo(i));

            Fibonacci(n);
        }

        private void Fibonacci(int n)
        {
            int[] a = new int[n + 1];

            lst.Items.Add("Loop Fibonacci:");

            for (int i = 1; i <= n; i++)
                if (i == 1 || i == 2)
                    a[i] = 1;
                else
                    a[i] = a[i - 2] + a[i - 1];

            for (int i = 1; i <= n; i++)
                lst.Items.Add(a[i]);
        }

        private long Fibo(int i)
        {
            if (i == 1 || i == 2)
                return 1;
            else
                return Fibo(i - 1) + Fibo(i - 2);
        }
    }
}
