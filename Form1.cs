/**************************                     
 * Developer : s3nat0r                       
 * Date : 2024/09/10                    
 * Version : 1.0.0.0                    
 * Description : A program to analyze and sort IP:PORT, which is saved as a list from the output of Masscan software
It also has the ability to process heavy text files                     
 **************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassSplit
{
    public partial class Form1 : Form
    {
        private string inputFilePath = "";
        private string outputFilePath = "";
        private static readonly object fileLock = new object();
        private CancellationTokenSource cancellationTokenSource;
        private System.Timers.Timer elapsedTimeTimer;
        private DateTime startTime;
        public Form1()
        {
            InitializeComponent();
            nudThread.Value = 350;
            nudThread.ValueChanged += (s, e) => lblThread.Text = nudThread.Value.ToString();
            btnBrowseInput.Click += btnBrowseInput_Click;
            btnSaveAs.Click += btnSaveAs_Click;
            btnSplit.Click += btnSplit_Click;
            btnCalculate.Click += btnCalculate_Click;
            btnReset.Click += btnReset_Click;
            lblNumbers.Text = "0";
            lblRemaining.Text = "0";
            lblElapsed.Text = "00:00:00";
            elapsedTimeTimer = new System.Timers.Timer
            {
                Interval = 1000
            };
            elapsedTimeTimer.Elapsed += (s, e) =>
            {
                if (startTime != DateTime.MinValue)
                {
                    TimeSpan elapsed = DateTime.Now - startTime;
                    if (lblElapsed.InvokeRequired)
                    {
                        lblElapsed.Invoke(new Action(() =>
                        {
                            lblElapsed.Text = elapsed.ToString(@"hh\:mm\:ss");
                        }));
                    }
                    else
                    {
                        lblElapsed.Text = elapsed.ToString(@"hh\:mm\:ss");
                    }
                }
            };

        }
        private async Task<int> CalculateTotalLinesAsync(string filePath, IProgress<int> progress, CancellationToken token)
        {
            int totalLines = 0;
            const int batchSize = 1000;
            int linesInBatch = 0;

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    token.ThrowIfCancellationRequested();
                    totalLines++;
                    linesInBatch++;
                    if (linesInBatch >= batchSize)
                    {
                        linesInBatch = 0;
                        progress?.Report(totalLines);
                    }
                }
            }
            progress?.Report(totalLines);
            return totalLines;
        }
        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputFilePath = openFileDialog.FileName;
                    txtInput.Text = inputFilePath;
                }
            }
        }
        private async void btnSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFilePath = saveFileDialog.FileName;
                    if (!outputFilePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        outputFilePath += ".txt";
                    }

                    txtOutput.Text = outputFilePath;
                }
            }
        }
        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("Please select an input file.");
                return;
            }

            lblNumbers.Text = "Calculating...";
            var progress = new Progress<int>(count =>
            {
                lblNumbers.Text = $"Total Lines: {count}";
            });

            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                int totalLines = await CalculateTotalLinesAsync(txtInput.Text, progress, cts.Token);
                lblNumbers.Text = $"Total Lines: {totalLines}";
            }
            catch (OperationCanceledException)
            {
                lblNumbers.Text = "Calculation was canceled.";
            }
        }

        private int? totalLineCount = null;

        private async void btnSplit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text) || string.IsNullOrEmpty(txtOutput.Text))
            {
                MessageBox.Show("Please select input and output files.");
                return;
            }
            startTime = DateTime.Now;
            elapsedTimeTimer.Start();
            if (totalLineCount == null)
            {
                lblRemaining.Text = "Calculating total lines...";
                var progress = new Progress<int>(count =>
                {
                    lblNumbers.Text = $"Total Lines: {count}";
                });

                CancellationTokenSource cts = new CancellationTokenSource();
                try
                {
                    totalLineCount = await CalculateTotalLinesAsync(txtInput.Text, progress, cts.Token);
                    lblNumbers.Text = $"Total Lines: {totalLineCount}";
                }
                catch (OperationCanceledException)
                {
                    lblRemaining.Text = "Operation was canceled.";
                    return;
                }
            }
            else
            {
                lblRemaining.Text = $"Total Lines (Cached): {totalLineCount}";
            }
            lblRemaining.Text = "Processing file...";
            try
            {
                await ProcessFileAsync(txtInput.Text, txtOutput.Text, (int)nudThread.Value, new Progress<(int processed, int remaining)>(update =>
                {
                    lblRemaining.Text = $"{update.processed}";
                }), CancellationToken.None);
            }
            finally
            {
                elapsedTimeTimer.Stop();
            }
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
            lblNumbers.Text = "0";
            lblThread.Text = "0";
            lblRemaining.Text = "0";
            lblElapsed.Text = "00:00:00";
            inputFilePath = "";
            outputFilePath = "";
            cancellationTokenSource?.Cancel();
        }

        private async Task ProcessFileAsync(string inputFile, string outputFile, int numThreads, IProgress<(int processed, int remaining)> progress, CancellationToken token)
        {
            const int batchSize = 1000;
            int totalLines = 0;
            int linesProcessed = 0;

            var outputLines = new List<string>();

            try
            {
                using (var reader = new StreamReader(inputFile))
                using (var writer = new StreamWriter(outputFile, append: false))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        token.ThrowIfCancellationRequested();
                        if (line.Contains("open tcp"))
                        {
                            var parts = line.Split(' ');
                            if (parts.Length >= 4)
                            {
                                string ip = parts[3];
                                string port = parts[2];
                                outputLines.Add($"{ip}:{port}");
                            }
                        }

                        linesProcessed++;
                        totalLines++;

                        if (linesProcessed >= batchSize)
                        {
                            await WriteBatchAsync(writer, outputLines);
                            outputLines.Clear();
                            progress?.Report((totalLines, totalLines - linesProcessed));
                            linesProcessed = 0;
                        }
                    }

                    if (outputLines.Count > 0)
                    {
                        await WriteBatchAsync(writer, outputLines);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error processing file: {ex.Message}");
            }

            progress?.Report((totalLines, 0));
        }

        private async Task WriteBatchAsync(StreamWriter writer, List<string> lines)
        {
            try
            {
                await writer.WriteLineAsync(string.Join(Environment.NewLine, lines));
            }
            catch (IOException ioEx)
            {
                //MessageBox.Show($"File write error: {ioEx.Message}");
            }
        }



        private void UpdateUI(int processed, int remaining)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    lblRemaining.Text = remaining.ToString();
                }));
            }
            else
            {
                lblRemaining.Text = remaining.ToString();
            }
        }

    }
}
