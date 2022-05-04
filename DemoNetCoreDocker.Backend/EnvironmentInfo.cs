using System.Runtime.InteropServices;

namespace DemoNetCoreDocker.Backend
{
    public class EnvironmentInfo
    {
        public EnvironmentInfo()
        {
            RuntimeVersion = RuntimeInformation.FrameworkDescription;
            OSVersion = RuntimeInformation.OSDescription;
            OSArchitecture = RuntimeInformation.OSArchitecture.ToString();
            ProcessorCount = Environment.ProcessorCount;
            TotalAvailableMemoryBytes = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
            if (RuntimeInformation.OSDescription.StartsWith("Linux") && Directory.Exists("/sys/fs/cgroup/memory"))
            {
                MemoryLimit = long.Parse(File.ReadAllLines("/sys/fs/cgroup/memory/memory.limit_in_bytes").First());
                MemoryUsage = long.Parse(File.ReadAllLines("/sys/fs/cgroup/memory/memory.usage_in_bytes").First());
            }
        }
        public string RuntimeVersion { get; set; }
        public string OSVersion { get; set; }
        public string OSArchitecture { get; set; }
        public int ProcessorCount { get; set; }
        public long TotalAvailableMemoryBytes { get; set; }
        public long MemoryLimit { get; set; }
        public long MemoryUsage { get; set; }
    }
}
