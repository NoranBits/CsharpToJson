using GitHubAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace GitHubAnalyzer
{
    public class FileAnalyzer
    {
        public AnalysisResult AnalyzeDirectory(string directoryPath)
        {
            var result = new AnalysisResult();

            try
            {
                // Get all .cs files recursively from the directory
                var csFiles = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

                foreach (var filePath in csFiles)
                {
                    var fileData = new FileData
                    {
                        FileName = Path.GetFileName(filePath),
                        FilePath = GetRelativePath(directoryPath, filePath),
                        Content = File.ReadAllText(filePath)
                    };

                    result.Files.Add(fileData);
                }

                result.IsSuccessful = true;
                result.Message = $"Successfully analyzed {csFiles.Length} files.";
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Message = $"An error occurred during analysis: {ex.Message}";
            }

            return result;
        }

        public string ConvertToJson(AnalysisResult result)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
        }

        private string GetRelativePath(string baseDirectory, string fullPath)
        {
            // Ensure both paths are treated as directories
            if (!baseDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                baseDirectory += Path.DirectorySeparatorChar;
            }

            Uri baseUri = new Uri(baseDirectory);
            Uri fullUri = new Uri(fullPath);

            // Make relative path from base directory to the file
            Uri relativeUri = baseUri.MakeRelativeUri(fullUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            // Convert to Windows-style paths if necessary
            return relativePath.Replace('/', Path.DirectorySeparatorChar);
        }
    }
}
