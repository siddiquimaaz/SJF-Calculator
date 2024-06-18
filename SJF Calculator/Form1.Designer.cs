namespace SJF_Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label9 = new Label();
            panel2 = new Panel();
            AvgWT = new Label();
            AvgTAT = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            NoOfProcesses = new TextBox();
            ProcessIDs = new TextBox();
            ArrivalTime = new TextBox();
            BurstTime = new TextBox();
            CloseBtn = new Button();
            CalculateSJF = new Button();
            ganttChartPanel = new Panel();
            TestSampleData = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 81, 181);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(0, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(1443, 57);
            panel1.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Verdana", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(497, 12);
            label9.Name = "label9";
            label9.Size = new Size(379, 45);
            label9.TabIndex = 13;
            label9.Text = "SJF CALCULATOR";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(117, 125, 232);
            panel2.Controls.Add(AvgWT);
            panel2.Controls.Add(AvgTAT);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(17, 381);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 57);
            panel2.TabIndex = 1;
            // 
            // AvgWT
            // 
            AvgWT.AutoSize = true;
            AvgWT.BackColor = Color.Transparent;
            AvgWT.ForeColor = Color.White;
            AvgWT.Location = new Point(211, 33);
            AvgWT.Name = "AvgWT";
            AvgWT.Size = new Size(51, 18);
            AvgWT.TabIndex = 3;
            AvgWT.Text = "label4";
            // 
            // AvgTAT
            // 
            AvgTAT.AutoSize = true;
            AvgTAT.BackColor = Color.Transparent;
            AvgTAT.ForeColor = Color.White;
            AvgTAT.Location = new Point(211, 11);
            AvgTAT.Name = "AvgTAT";
            AvgTAT.Size = new Size(51, 18);
            AvgTAT.TabIndex = 2;
            AvgTAT.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(17, 33);
            label2.Name = "label2";
            label2.Size = new Size(168, 18);
            label2.TabIndex = 1;
            label2.Text = "Average Waiting Time";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(17, 11);
            label1.Name = "label1";
            label1.Size = new Size(205, 18);
            label1.TabIndex = 0;
            label1.Text = "Average Turn Around Time";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.FromArgb(0, 63, 143);
            dataGridView1.Location = new Point(654, 204);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(670, 409);
            dataGridView1.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 178);
            label5.Name = "label5";
            label5.Size = new Size(213, 18);
            label5.TabIndex = 4;
            label5.Text = "Enter Number Of Processes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 204);
            label6.Name = "label6";
            label6.Size = new Size(139, 18);
            label6.TabIndex = 5;
            label6.Text = "Enter Process IDs";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 233);
            label7.Name = "label7";
            label7.Size = new Size(139, 18);
            label7.TabIndex = 6;
            label7.Text = "Enter Arrival Time";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 262);
            label8.Name = "label8";
            label8.Size = new Size(132, 18);
            label8.TabIndex = 7;
            label8.Text = "Enter Burst Time";
            // 
            // NoOfProcesses
            // 
            NoOfProcesses.BackColor = Color.White;
            NoOfProcesses.ForeColor = Color.FromArgb(0, 63, 143);
            NoOfProcesses.Location = new Point(242, 175);
            NoOfProcesses.Multiline = true;
            NoOfProcesses.Name = "NoOfProcesses";
            NoOfProcesses.PlaceholderText = "No. of Processes";
            NoOfProcesses.Size = new Size(150, 22);
            NoOfProcesses.TabIndex = 8;
            NoOfProcesses.TextAlign = HorizontalAlignment.Center;
            // 
            // ProcessIDs
            // 
            ProcessIDs.BackColor = Color.White;
            ProcessIDs.ForeColor = Color.FromArgb(0, 63, 143);
            ProcessIDs.Location = new Point(242, 201);
            ProcessIDs.Multiline = true;
            ProcessIDs.Name = "ProcessIDs";
            ProcessIDs.PlaceholderText = "Process IDs";
            ProcessIDs.Size = new Size(150, 22);
            ProcessIDs.TabIndex = 9;
            ProcessIDs.TextAlign = HorizontalAlignment.Center;
            // 
            // ArrivalTime
            // 
            ArrivalTime.BackColor = Color.White;
            ArrivalTime.ForeColor = Color.FromArgb(0, 63, 143);
            ArrivalTime.Location = new Point(242, 230);
            ArrivalTime.Multiline = true;
            ArrivalTime.Name = "ArrivalTime";
            ArrivalTime.PlaceholderText = "Arrival Time";
            ArrivalTime.Size = new Size(150, 22);
            ArrivalTime.TabIndex = 10;
            ArrivalTime.TextAlign = HorizontalAlignment.Center;
            // 
            // BurstTime
            // 
            BurstTime.BackColor = Color.White;
            BurstTime.ForeColor = Color.FromArgb(0, 63, 143);
            BurstTime.Location = new Point(242, 259);
            BurstTime.Multiline = true;
            BurstTime.Name = "BurstTime";
            BurstTime.PlaceholderText = "Burst Time";
            BurstTime.Size = new Size(150, 22);
            BurstTime.TabIndex = 11;
            BurstTime.TextAlign = HorizontalAlignment.Center;
            // 
            // CloseBtn
            // 
            CloseBtn.BackColor = Color.FromArgb(51, 51, 51);
            CloseBtn.BackgroundImage = (Image)resources.GetObject("CloseBtn.BackgroundImage");
            CloseBtn.BackgroundImageLayout = ImageLayout.Zoom;
            CloseBtn.FlatStyle = FlatStyle.Flat;
            CloseBtn.Location = new Point(12, 535);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(75, 23);
            CloseBtn.TabIndex = 12;
            CloseBtn.UseVisualStyleBackColor = false;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // CalculateSJF
            // 
            CalculateSJF.BackColor = Color.FromArgb(0, 63, 143);
            CalculateSJF.FlatStyle = FlatStyle.Flat;
            CalculateSJF.ForeColor = Color.White;
            CalculateSJF.Location = new Point(198, 311);
            CalculateSJF.Name = "CalculateSJF";
            CalculateSJF.Size = new Size(85, 29);
            CalculateSJF.TabIndex = 0;
            CalculateSJF.Text = "Calculate";
            CalculateSJF.UseVisualStyleBackColor = false;
            CalculateSJF.Click += CalculateSJF_Click;
            // 
            // ganttChartPanel
            // 
            ganttChartPanel.Location = new Point(654, 109);
            ganttChartPanel.Name = "ganttChartPanel";
            ganttChartPanel.Size = new Size(670, 61);
            ganttChartPanel.TabIndex = 13;
            // 
            // TestSampleData
            // 
            TestSampleData.BackColor = Color.FromArgb(51, 51, 51);
            TestSampleData.BackgroundImageLayout = ImageLayout.Zoom;
            TestSampleData.FlatStyle = FlatStyle.Flat;
            TestSampleData.ForeColor = SystemColors.Control;
            TestSampleData.Location = new Point(289, 311);
            TestSampleData.Name = "TestSampleData";
            TestSampleData.Size = new Size(103, 29);
            TestSampleData.TabIndex = 14;
            TestSampleData.Text = "Test";
            TestSampleData.UseVisualStyleBackColor = false;
            TestSampleData.Click += TestSampleData_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1443, 724);
            Controls.Add(TestSampleData);
            Controls.Add(ganttChartPanel);
            Controls.Add(dataGridView1);
            Controls.Add(CalculateSJF);
            Controls.Add(CloseBtn);
            Controls.Add(BurstTime);
            Controls.Add(ArrivalTime);
            Controls.Add(ProcessIDs);
            Controls.Add(NoOfProcesses);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label AvgWT;
        private Label AvgTAT;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox NoOfProcesses;
        private TextBox ProcessIDs;
        private TextBox ArrivalTime;
        private TextBox BurstTime;
        private Button CloseBtn;
        private Label label9;
        private Button CalculateSJF;
        private Panel ganttChartPanel;
        private Button TestSampleData;
    }
}
