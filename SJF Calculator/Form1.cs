using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SJF_Calculator
{
    public partial class Form1 : Form
    {
        private List<Process> processes = new List<Process>();
        private double avgTurnAroundTime = 0;
        private double avgWaitingTime = 0;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Remove border to apply custom rounded border
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen

            // Add event handler for the close button
            this.CloseBtn.Click += new EventHandler(CloseBtn_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CalculateSJF_Click(object sender, EventArgs e)
        {
            ClearForm();

            int n;
            if (!int.TryParse(NoOfProcesses.Text, out n))
            {
                MessageBox.Show("Please enter a valid number of processes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Sort processes by Arrival Time for initial scheduling
            processes = processes.OrderBy(p => p.ArrivalTime).ToList();

            int currentTime = 0;
            var scheduledProcesses = new List<Process>();
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

            // Calculate average times
            avgTurnAroundTime = scheduledProcesses.Average(p => p.TurnAroundTime);
            avgWaitingTime = scheduledProcesses.Average(p => p.WaitingTime);

            // Sort processes by Process ID to display in the correct order
            scheduledProcesses = scheduledProcesses.OrderBy(p => p.ProcessID).ToList();

            // Update DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = scheduledProcesses;

            // Update average time labels
            AvgTAT.Text = avgTurnAroundTime.ToString("F2");
            AvgWT.Text = avgWaitingTime.ToString("F2");

            // Draw the Gantt chart
            processes = scheduledProcesses; // Ensure Gantt chart uses the correct order
            DrawGanttChart();
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
            ganttChartPanel.Invalidate();
        }

        private void DrawGanttChart()
        {
            Bitmap bmp = new Bitmap(ganttChartPanel.Width, ganttChartPanel.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                int currentX = 0;
                int processHeight = ganttChartPanel.Height / 3;
                int timeHeight = ganttChartPanel.Height / 3;

                foreach (var process in processes.OrderBy(p => p.CompletionTime - p.BurstTime)) // Order by start time
                {
                    int processWidth = (process.BurstTime * ganttChartPanel.Width) / processes.Sum(p => p.BurstTime);
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
            path.AddArc(bounds.X + bounds.Width - radius, bounds
            .Height - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        // Event handler for Close button
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
