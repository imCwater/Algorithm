using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hanoi(4, 'A', 'B', 'C');
        }

        private static void Hanoi(int n, char from, char by, char to)
        {
            if (n == 1)
                Console.WriteLine("Move : {0} -> {1}", from, to);
            else
            {
                Hanoi(n - 1, from, to, by);
                Console.WriteLine("Move : {0} -> {1}", from, to);
                Hanoi(n - 1, by, from, to);
            }
        }
    }
}
