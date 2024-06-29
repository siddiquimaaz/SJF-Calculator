using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SJF_Calculator
{
    public partial class Form1 : Form
    {
        private List<Process> processes = new List<Process>();
        private List<Process> scheduledProcesses = new List<Process>(); // Moved to class level
        private double avgTurnAroundTime = 0;
        private double avgWaitingTime = 0;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Paint += new PaintEventHandler(Form1_Paint);

        }

        private void CalculateSJF_Click(object sender, EventArgs e)
        {
            ClearForm();

            int n;
            if (!int.TryParse(NoOfProcesses.Text, out n) || n <= 0)
            {
                MessageBox.Show("Please enter a valid positive number of processes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] processIds = ProcessIDs.Text.Split(',');
            string[] arrivalTimes = ArrivalTime.Text.Split(',');
            string[] burstTimes = BurstTime.Text.Split(',');

            if (!ValidateInputs(n, processIds, arrivalTimes, burstTimes))
            {
                MessageBox.Show("The number of input values does not match the specified number of processes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            processes.Clear();

            try
            {
                for (int i = 0; i < n; i++)
                {
                    processes.Add(new Process
                    {
                        ProcessID = int.Parse(processIds[i]),
                        ArrivalTime = int.Parse(arrivalTimes[i]),
                        BurstTime = int.Parse(burstTimes[i])
                    });
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure all input values are integers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            processes = processes.OrderBy(p => p.ArrivalTime).ToList();

            int currentTime = 0;
            scheduledProcesses.Clear(); // Clear the scheduled processes list

            while (processes.Any())
            {
                var availableProcesses = processes.Where(p => p.ArrivalTime <= currentTime).ToList();
                if (!availableProcesses.Any())
                {
                    currentTime = processes.Min(p => p.ArrivalTime);
                    availableProcesses = processes.Where(p => p.ArrivalTime <= currentTime).ToList();
                }

                var nextProcess = availableProcesses.OrderBy(p => p.BurstTime).First();
                processes.Remove(nextProcess);

                if (currentTime < nextProcess.ArrivalTime)
                {
                    currentTime = nextProcess.ArrivalTime;
                }
                nextProcess.CompletionTime = currentTime + nextProcess.BurstTime;
                nextProcess.TurnAroundTime = nextProcess.CompletionTime - nextProcess.ArrivalTime;
                nextProcess.WaitingTime = nextProcess.TurnAroundTime - nextProcess.BurstTime;
                currentTime = nextProcess.CompletionTime;

                scheduledProcesses.Add(nextProcess);
            }

            avgTurnAroundTime = scheduledProcesses.Average(p => p.TurnAroundTime);
            avgWaitingTime = scheduledProcesses.Average(p => p.WaitingTime);

            scheduledProcesses = scheduledProcesses.OrderBy(p => p.ProcessID).ToList();

            // Update DataGridView
            dataGridView1.DataSource = scheduledProcesses;
            AvgTAT.Text = avgTurnAroundTime.ToString("F2");
            AvgWT.Text = avgWaitingTime.ToString("F2");

            // Debug messages
            if (scheduledProcesses.Count > 0)
            {
                MessageBox.Show($"Processes scheduled: {scheduledProcesses.Count}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DrawGanttChart();
            }
            else
            {
                MessageBox.Show("No processes to display in Gantt chart.", "No Processes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateInputs(int n, string[] processIds, string[] arrivalTimes, string[] burstTimes)
        {
            return processIds.Length == n && arrivalTimes.Length == n && burstTimes.Length == n;
        }

        private void ClearForm()
        {
            dataGridView1.DataSource = null;
            AvgTAT.Text = "0";
            AvgWT.Text = "0";
            ganttChartPanel.BackgroundImage = null; // Clear gantt chart panel background
        }

        private void DrawGanttChart()
        {
            if (scheduledProcesses.Count == 0)
            {
                MessageBox.Show("No processes to display in Gantt chart.", "No Processes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int totalBurstTime = scheduledProcesses.Sum(p => p.BurstTime);
            Bitmap bmp = new Bitmap(ganttChartPanel.Width, ganttChartPanel.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int currentX = 0;
                int processHeight = ganttChartPanel.Height / 2;

                foreach (var process in scheduledProcesses.OrderBy(p => p.CompletionTime - p.BurstTime))
                {
                    int processWidth = (int)Math.Round((double)process.BurstTime / totalBurstTime * ganttChartPanel.Width);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(63, 81, 181)), currentX, 0, processWidth, processHeight);
                    g.DrawRectangle(Pens.Black, currentX, 0, processWidth, processHeight);
                    g.DrawString("P" + process.ProcessID, this.Font, Brushes.White, currentX + (processWidth / 2) - 10, 10);
                    g.DrawString(process.CompletionTime.ToString(), this.Font, Brushes.Black, currentX + processWidth - 10, processHeight + 10);

                    currentX += processWidth;
                }
            }

            ganttChartPanel.BackgroundImage = bmp;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Height - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GenerateSampleData()
        {
            Random random = new Random();
            int numProcesses = random.Next(3, 6); // Generate between 3 to 5 processes

            StringBuilder processIds = new StringBuilder();
            StringBuilder arrivalTimes = new StringBuilder();
            StringBuilder burstTimes = new StringBuilder();

            for (int i = 0; i < numProcesses; i++)
            {
                int processId = i + 1;
                int arrivalTime = random.Next(0, 10); // Arrival time between 0 to 9
                int burstTime = random.Next(1, 10);   // Burst time between 1 to 9

                processIds.Append(processId);
                arrivalTimes.Append(arrivalTime);
                burstTimes.Append(burstTime);

                if (i < numProcesses - 1)
                {
                    processIds.Append(",");
                    arrivalTimes.Append(",");
                    burstTimes.Append(",");
                }
            }

            // Assign generated data to respective text boxes
            NoOfProcesses.Text = numProcesses.ToString();
            ProcessIDs.Text = processIds.ToString();
            ArrivalTime.Text = arrivalTimes.ToString();
            BurstTime.Text = burstTimes.ToString();

            MessageBox.Show("Sample data generated successfully.");
        }

        private void TestSampleData_Click(object sender, EventArgs e)
        {
            GenerateSampleData();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public class Process
    {
        public int ProcessID { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int CompletionTime { get; set; }
        public int TurnAroundTime { get; set; }
        public int WaitingTime { get; set; }
    }
}
