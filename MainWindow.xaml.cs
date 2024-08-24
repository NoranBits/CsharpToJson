using GitHubAnalyzer.Models;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace GitHubAnalyzer
{
    public partial class MainWindow : Window
    {
        private readonly FileAnalyzer _fileAnalyzer;

        public MainWindow()
        {
            InitializeComponent();
            _fileAnalyzer = new FileAnalyzer();
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Folder Selection|*.folder", // Doesn't actually filter but allows the dialog to open
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Select Folder"
            };

            if (dialog.ShowDialog() == true)
            {
                FolderPathTextBox.Text = Path.GetDirectoryName(dialog.FileName);
            }
        }

        private void StartAnalysis_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FolderPathTextBox.Text))
            {
                MessageBox.Show("Please select a folder to analyze.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            OutputTextBox.Clear();
            OutputTextBox.AppendText("Starting analysis...\n");

            var result = _fileAnalyzer.AnalyzeDirectory(FolderPathTextBox.Text);

            if (result.IsSuccessful)
            {
                OutputTextBox.AppendText(result.Message + "\n");
                SaveAnalysisResult(result);
            }
            else
            {
                OutputTextBox.AppendText(result.Message + "\n");
            }
        }

        private void SaveAnalysisResult(AnalysisResult result)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Save Analysis Result",
                FileName = "AnalysisResult.json"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var json = _fileAnalyzer.ConvertToJson(result);
                File.WriteAllText(saveFileDialog.FileName, json);
                OutputTextBox.AppendText($"Analysis result saved to {saveFileDialog.FileName}\n");
            }
        }
    }
}