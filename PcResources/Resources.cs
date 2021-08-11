using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using PcResources.Models;

namespace PcResources
{
    public class Resources
    {
        private readonly List<double> resources;

        public Resources()
        {
            resources = new List<double>();
        }

        public List<double> GetResources()
        {

            double memoryRam = 0;
            var wmiObject = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            var memoryValues = wmiObject.Get().Cast<ManagementObject>().Select(mo => new {
                FreePhysicalMemory = Double.Parse(mo["FreePhysicalMemory"].ToString()),
                TotalVisibleMemorySize = Double.Parse(mo["TotalVisibleMemorySize"].ToString())
            }).FirstOrDefault();

            if (memoryValues != null)
            {
                memoryRam = ((memoryValues.TotalVisibleMemorySize - memoryValues.FreePhysicalMemory) / memoryValues.TotalVisibleMemorySize) * 100;
            }
            resources.Add(memoryRam);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");
            var cpuTimes = searcher.Get()
                .Cast<ManagementObject>()
                .Select(mo => new CpuUsageModel
                {
                    Name = mo["Name"].ToString(),
                    Usage = mo["PercentProcessorTime"].ToString()
                }
                )
                .ToArray();

            var cpuTotal = cpuTimes.Where(x => x.Name == "_Total").FirstOrDefault();
            double cpu = Convert.ToDouble(cpuTotal.Usage);
            resources.Add(cpu);

            PerformanceCounter physicalDisk = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            double disk = Convert.ToDouble(physicalDisk.NextValue());
            resources.Add(disk);

            return resources;

        }

    }
}
