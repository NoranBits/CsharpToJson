using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAnalyzer.Models
{
    public class AnalysisResult
    {
        public List<FileData> Files { get; set; } = new List<FileData>();
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}