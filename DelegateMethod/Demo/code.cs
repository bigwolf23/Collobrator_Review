using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            StreamWriter writer = null;
            Stream outStream = Console.OpenStandardOutput();
            writer = new StreamWriter(outStream);

            int n = 0;
            while (n <= 100)
            {
                Thread.Sleep(30);
                writer.WriteLine(n);
                writer.Flush();
                n++;
            }
            writer.Close();
            Environment.ExitCode = 0;
        }
    }
}
