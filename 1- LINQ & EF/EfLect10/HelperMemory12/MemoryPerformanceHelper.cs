using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;


namespace HelperMemory12
{
   

    public class MemoryPerformanceHelper
    {
        private Stopwatch stopwatch;
        private long memoryBefore;
        private int gcGen0Before, gcGen1Before, gcGen2Before;

        public void Start()
        {
            GC.Collect(); // Clean start
            GC.WaitForPendingFinalizers();
            GC.Collect();

            memoryBefore = GC.GetTotalMemory(true);

            gcGen0Before = GC.CollectionCount(0);
            gcGen1Before = GC.CollectionCount(1);
            gcGen2Before = GC.CollectionCount(2);

            stopwatch = Stopwatch.StartNew();
        }

        public void StopAndReport(string label = "")
        {
            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            int gcGen0After = GC.CollectionCount(0);
            int gcGen1After = GC.CollectionCount(1);
            int gcGen2After = GC.CollectionCount(2);

            Console.WriteLine($"\n--- Performance Report {label} ---");
            Console.WriteLine($"Elapsed Time     : {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Memory Used      : {(memoryAfter - memoryBefore) / 1024.0:F2} KB");
            Console.WriteLine($"GC Gen 0         : {gcGen0After - gcGen0Before}");
            Console.WriteLine($"GC Gen 1         : {gcGen1After - gcGen1Before}");
            Console.WriteLine($"GC Gen 2         : {gcGen2After - gcGen2Before}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
