using System;
using System.Collections.Concurrent;
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
using System.Xml.Linq;

namespace Sort
{
    public partial class MainWindow : Window
    {
        static int MAX = 1000000; // 백만
        int[] a = new int[MAX];
        int N = 0;      // 데이터 갯수
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";
            N = int.Parse(txtData.Text);
            txtBubble.Text = "버블 정렬 : ";
            txtQuick.Text = "퀵 정렬 : ";
            txtMerge.Text = "합병 정렬 : ";
            Randomize();
            PrintData("랜덤 숫자");
        }

        private void Randomize()
        {
            for (int i = 0; i < N; i++)
                a[i] = r.Next(5 * N);   
        }

        private void PrintData(string s)
        {
            txtResult.Text += "\n" + s + "\n";
            for (int i = 0; i < N; i++)
            {
                txtResult.Text += a[i] + " ";
            }
            txtResult.Text += "\n";
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BubbleSort();
            watch.Stop();
            PrintData("버블 정렬");
            long tickBubble = watch.ElapsedTicks;
            long msBubble = watch.ElapsedMilliseconds;
            txtBubble.Text = "버블 정렬 : " + tickBubble + " Ticks, "
                + msBubble + " ms";

            Randomize();
            watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(a, 0, N - 1);
            watch.Stop();
            PrintData("퀵 정렬");
            long tickQuick = watch.ElapsedTicks;
            long msQuick = watch.ElapsedMilliseconds;
            txtQuick.Text = "퀵 정렬 : " + tickQuick + " Ticks, "
                + msQuick + " ms";

            Randomize();
            watch = System.Diagnostics.Stopwatch.StartNew();
            MergeSort(a, 0, N - 1);
            watch.Stop();
            PrintData("합병 정렬");
            long tickMerge = watch.ElapsedTicks;
            long msMerge = watch.ElapsedMilliseconds;
            txtMerge.Text = "합병 정렬 : " + tickMerge + " Ticks, "
                + msMerge + " ms";
        }

        
        private void quick_sort(int list[], int left, int right)
        {
            int q;
            if (list < right)
            {
                q = partiton(list, left, right);
                quick_sort(list, left, q - 1);
                quick_sort(list, q + 1, right);
            }
        }
        private int partiton (int list[], int left, int right)
        {
            int tmp;
            int low = left + 1;
            int high = right;
            int pivot = list[left];

            while (low < higt)
            {
                for (; low <= right && list[low] < pivot; low++) ;
                for (; high >= left && list[high] > pivot; high--) ;
                if (low < high)
                    SWAP(list[low], list[high], tmp);
            }
            SWAP(list[left], list[high], tmp );
            return high;

            static void merge(int list[], int left, int mid, int right) {
                int i, j, k = left, l;
                static int sorted[MAX_SIZE];

                for (i = left, j = mid + 1; i <= mid && j <= right;)
                    sorted[k++] = (list[i] <= list[j]) ? list[i++] : list[j++];
                if (i > mid)
                    for (l = j; l <= right; l++, k++)
                        sorted[k] = list[l];
                else
                    for (l = i; l <= mid; l++, k++)
                        sorted[k] = list[l];
                for (l = left; l <= right; l++)
                        list[l] = sorted[l];
            }
            void merge_sort(int list[], int left, int right)
            {
                if (left < right)
                {
                    int mid = (left + right) / 2;
                    merge_sort(list, left, mid);
                    merge_sort(list, mid + 1, right);
                    merge(list, left, mid, right);
                }
            }