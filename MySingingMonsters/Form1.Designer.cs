namespace MySingingMonsters
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
            titleLabel = new Label();
            subtitleLabel = new Label();
            playerLabel = new Label();
            opponentLabel = new Label();
            monstersPanel = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            opponentPanel = new Panel();
            opponentButton3 = new Button();
            opponentButton2 = new Button();
            opponentButton1 = new Button();
            resultPanel = new Panel();
            gauntletIterationsLabel = new Label();
            gauntletIterationsInput = new NumericUpDown();
            calculateBestTeamButton = new Button();
            runGauntletButton = new Button();
            startButton = new Button();
            resultLabel = new Label();
            winBox = new TextBox();
            monstersPanel.SuspendLayout();
            opponentPanel.SuspendLayout();
            resultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gauntletIterationsInput).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(34, 34, 59);
            titleLabel.Location = new Point(34, 24);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(502, 45);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "My Singing Monsters Battle Sim";
            titleLabel.Click += titleLabel_Click;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 10.5F);
            subtitleLabel.ForeColor = Color.FromArgb(90, 90, 110);
            subtitleLabel.Location = new Point(38, 74);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(260, 19);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Build your team and simulate the winner.";
            // 
            // playerLabel
            // 
            playerLabel.AutoSize = true;
            playerLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            playerLabel.ForeColor = Color.FromArgb(34, 34, 59);
            playerLabel.Location = new Point(40, 198);
            playerLabel.Name = "playerLabel";
            playerLabel.Size = new Size(105, 25);
            playerLabel.TabIndex = 6;
            playerLabel.Text = "Your Team";
            // 
            // opponentLabel
            // 
            opponentLabel.AutoSize = true;
            opponentLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            opponentLabel.ForeColor = Color.FromArgb(34, 34, 59);
            opponentLabel.Location = new Point(40, 397);
            opponentLabel.Name = "opponentLabel";
            opponentLabel.Size = new Size(154, 25);
            opponentLabel.TabIndex = 7;
            opponentLabel.Text = "Opponent Team";
            // 
            // monstersPanel
            // 
            monstersPanel.BackColor = Color.White;
            monstersPanel.Controls.Add(button3);
            monstersPanel.Controls.Add(button2);
            monstersPanel.Controls.Add(button1);
            monstersPanel.Location = new Point(40, 230);
            monstersPanel.Name = "monstersPanel";
            monstersPanel.Size = new Size(1288, 150);
            monstersPanel.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(108, 92, 231);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(866, 20);
            button3.Name = "button3";
            button3.Size = new Size(380, 110);
            button3.TabIndex = 2;
            button3.Text = "Select Monster";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 184, 148);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(443, 20);
            button2.Name = "button2";
            button2.Size = new Size(380, 110);
            button2.TabIndex = 1;
            button2.Text = "Select Monster...";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 118, 117);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(20, 20);
            button1.Name = "button1";
            button1.Size = new Size(380, 110);
            button1.TabIndex = 0;
            button1.Text = "Select Monster...";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // opponentPanel
            // 
            opponentPanel.BackColor = Color.White;
            opponentPanel.Controls.Add(opponentButton3);
            opponentPanel.Controls.Add(opponentButton2);
            opponentPanel.Controls.Add(opponentButton1);
            opponentPanel.Location = new Point(40, 428);
            opponentPanel.Name = "opponentPanel";
            opponentPanel.Size = new Size(1288, 150);
            opponentPanel.TabIndex = 8;
            // 
            // opponentButton3
            // 
            opponentButton3.BackColor = Color.FromArgb(108, 92, 231);
            opponentButton3.FlatAppearance.BorderSize = 0;
            opponentButton3.FlatStyle = FlatStyle.Flat;
            opponentButton3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            opponentButton3.ForeColor = Color.White;
            opponentButton3.Location = new Point(866, 20);
            opponentButton3.Name = "opponentButton3";
            opponentButton3.Size = new Size(380, 110);
            opponentButton3.TabIndex = 2;
            opponentButton3.Text = "Select Monster...";
            opponentButton3.UseVisualStyleBackColor = false;
            // 
            // opponentButton2
            // 
            opponentButton2.BackColor = Color.FromArgb(0, 184, 148);
            opponentButton2.FlatAppearance.BorderSize = 0;
            opponentButton2.FlatStyle = FlatStyle.Flat;
            opponentButton2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            opponentButton2.ForeColor = Color.White;
            opponentButton2.Location = new Point(443, 20);
            opponentButton2.Name = "opponentButton2";
            opponentButton2.Size = new Size(380, 110);
            opponentButton2.TabIndex = 1;
            opponentButton2.Text = "Select Monster...";
            opponentButton2.UseVisualStyleBackColor = false;
            // 
            // opponentButton1
            // 
            opponentButton1.BackColor = Color.FromArgb(255, 118, 117);
            opponentButton1.FlatAppearance.BorderSize = 0;
            opponentButton1.FlatStyle = FlatStyle.Flat;
            opponentButton1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            opponentButton1.ForeColor = Color.White;
            opponentButton1.Location = new Point(20, 20);
            opponentButton1.Name = "opponentButton1";
            opponentButton1.Size = new Size(380, 110);
            opponentButton1.TabIndex = 0;
            opponentButton1.Text = "Select Monster...";
            opponentButton1.UseVisualStyleBackColor = false;
            // 
            // resultPanel
            // 
            resultPanel.BackColor = Color.FromArgb(245, 246, 250);
            resultPanel.Controls.Add(gauntletIterationsLabel);
            resultPanel.Controls.Add(gauntletIterationsInput);
            resultPanel.Controls.Add(calculateBestTeamButton);
            resultPanel.Controls.Add(runGauntletButton);
            resultPanel.Controls.Add(startButton);
            resultPanel.Controls.Add(resultLabel);
            resultPanel.Controls.Add(winBox);
            resultPanel.Location = new Point(40, 610);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(1288, 130);
            resultPanel.TabIndex = 5;
            // 
            // gauntletIterationsLabel
            // 
            gauntletIterationsLabel.AutoSize = true;
            gauntletIterationsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gauntletIterationsLabel.ForeColor = Color.FromArgb(34, 34, 59);
            gauntletIterationsLabel.Location = new Point(495, 22);
            gauntletIterationsLabel.Name = "gauntletIterationsLabel";
            gauntletIterationsLabel.Size = new Size(110, 19);
            gauntletIterationsLabel.TabIndex = 4;
            gauntletIterationsLabel.Text = "Gauntlet fights:";
            // 
            // gauntletIterationsInput
            // 
            gauntletIterationsInput.Font = new Font("Segoe UI", 10F);
            gauntletIterationsInput.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            gauntletIterationsInput.Location = new Point(635, 16);
            gauntletIterationsInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            gauntletIterationsInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            gauntletIterationsInput.Name = "gauntletIterationsInput";
            gauntletIterationsInput.Size = new Size(160, 25);
            gauntletIterationsInput.TabIndex = 5;
            gauntletIterationsInput.ThousandsSeparator = true;
            gauntletIterationsInput.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // calculateBestTeamButton
            // 
            calculateBestTeamButton.BackColor = Color.FromArgb(230, 126, 34);
            calculateBestTeamButton.FlatAppearance.BorderSize = 0;
            calculateBestTeamButton.FlatStyle = FlatStyle.Flat;
            calculateBestTeamButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            calculateBestTeamButton.ForeColor = Color.White;
            calculateBestTeamButton.Location = new Point(260, 14);
            calculateBestTeamButton.Name = "calculateBestTeamButton";
            calculateBestTeamButton.Size = new Size(210, 36);
            calculateBestTeamButton.TabIndex = 6;
            calculateBestTeamButton.Text = "Calculate Best Team";
            calculateBestTeamButton.UseVisualStyleBackColor = false;
            // 
            // runGauntletButton
            // 
            runGauntletButton.BackColor = Color.FromArgb(0, 130, 120);
            runGauntletButton.FlatAppearance.BorderSize = 0;
            runGauntletButton.FlatStyle = FlatStyle.Flat;
            runGauntletButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            runGauntletButton.ForeColor = Color.White;
            runGauntletButton.Location = new Point(830, 14);
            runGauntletButton.Name = "runGauntletButton";
            runGauntletButton.Size = new Size(210, 36);
            runGauntletButton.TabIndex = 3;
            runGauntletButton.Text = "Run Gauntlet";
            runGauntletButton.UseVisualStyleBackColor = false;
            // 
            // startButton
            // 
            startButton.BackColor = Color.FromArgb(34, 34, 59);
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            startButton.ForeColor = Color.White;
            startButton.Location = new Point(1060, 14);
            startButton.Name = "startButton";
            startButton.Size = new Size(200, 36);
            startButton.TabIndex = 2;
            startButton.Text = "Start Battle";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            resultLabel.ForeColor = Color.FromArgb(34, 34, 59);
            resultLabel.Location = new Point(24, 22);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(53, 20);
            resultLabel.TabIndex = 0;
            resultLabel.Text = "Result";
            // 
            // winBox
            // 
            winBox.BackColor = Color.White;
            winBox.BorderStyle = BorderStyle.None;
            winBox.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            winBox.ForeColor = Color.FromArgb(45, 52, 54);
            winBox.Location = new Point(24, 55);
            winBox.Multiline = true;
            winBox.Name = "winBox";
            winBox.ReadOnly = true;
            winBox.Size = new Size(1230, 110);
            winBox.TabIndex = 1;
            winBox.Text = "Winner is...";
            winBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1370, 780);
            Controls.Add(resultPanel);
            Controls.Add(opponentPanel);
            Controls.Add(monstersPanel);
            Controls.Add(opponentLabel);
            Controls.Add(playerLabel);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Singing Monsters";
            monstersPanel.ResumeLayout(false);
            opponentPanel.ResumeLayout(false);
            resultPanel.ResumeLayout(false);
            resultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gauntletIterationsInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox winBox;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label teamLabel;
        private Label playerLabel;
        private Label opponentLabel;
        private Panel monstersPanel;
        private Panel opponentPanel;
        private Button opponentButton1;
        private Button opponentButton2;
        private Button opponentButton3;
        private Button startButton;
        private Button runGauntletButton;
        private Button calculateBestTeamButton;
        private Label gauntletIterationsLabel;
        private NumericUpDown gauntletIterationsInput;
        private Panel resultPanel;
        private Label resultLabel;
    }
}
