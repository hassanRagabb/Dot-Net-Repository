using HelperMemory12;
using System;
using System.Text;
using BenchmarkDotNet.Running;
class Program
{
    static void Main()
    {
        #region helper manuall class


        //var helper = new MemoryPerformanceHelper();

        //// ---------- String Concatenation ----------
        //helper.Start();

        //string result = "";
        //for (int i = 1; i <= 50000; i++)
        //{
        //    result += i.ToString();
        //}

        //helper.StopAndReport("String Concatenation (+=)");

        //// ---------- StringBuilder Concatenation ----------
        //helper.Start();

        //StringBuilder sb = new StringBuilder();
        //for (int i = 1; i <= 50000; i++)
        //{
        //    sb.Append(i.ToString());
        //}

        //string finalResult = sb.ToString();

        //helper.StopAndReport("StringBuilder.Append()");
        #endregion

        BenchmarkRunner.Run<StringConcatBenchmark>();
    }
}
