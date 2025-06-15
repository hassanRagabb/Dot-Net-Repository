using BenchmarkDotNet.Attributes;
using Microsoft.Diagnostics.Runtime.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMemory12
{
    [MemoryDiagnoser] // enables memory usage info
    public class StringConcatBenchmark
    {
        [Benchmark]
        public void UsingString()
        {
            string result = "";
            for (int i = 1; i <= 50000; i++)
            {
                result += i.ToString();
            }
            Console.WriteLine($"concatenated string length {result.Length}");
           // return result;
        }

        [Benchmark]
        public void UsingStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 50000; i++)
            {
                sb.Append(i.ToString());
            }
            Console.WriteLine($"BUILDER string length {sb.ToString().Length}");
            //return sb.ToString();
        }
    }
}
