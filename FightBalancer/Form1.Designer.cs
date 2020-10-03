namespace FightBalancer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AttackersList = new System.Windows.Forms.ListBox();
            this.DefendersList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SpeedInput = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ArmorInput = new System.Windows.Forms.NumericUpDown();
            this.DamageInput = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AgilityInput = new System.Windows.Forms.NumericUpDown();
            this.EnduranceInput = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SwitchLabel = new System.Windows.Forms.Label();
            this.TeamSwitch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ClearDefenders = new System.Windows.Forms.Button();
            this.ClearAttackers = new System.Windows.Forms.Button();
            this.FightBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArmorInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnduranceInput)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Атакующие";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(614, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Защищающиеся";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AttackersList
            // 
            this.AttackersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AttackersList.FormattingEnabled = true;
            this.AttackersList.Location = new System.Drawing.Point(12, 54);
            this.AttackersList.Name = "AttackersList";
            this.AttackersList.Size = new System.Drawing.Size(265, 145);
            this.AttackersList.TabIndex = 2;
            // 
            // DefendersList
            // 
            this.DefendersList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefendersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefendersList.FormattingEnabled = true;
            this.DefendersList.Location = new System.Drawing.Point(619, 54);
            this.DefendersList.Name = "DefendersList";
            this.DefendersList.Size = new System.Drawing.Size(260, 145);
            this.DefendersList.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(100, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 41);
            this.label4.TabIndex = 0;
            this.label4.Text = "Защита";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 41);
            this.label3.TabIndex = 0;
            this.label3.Text = "Урон";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.NameInput, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.SpeedInput, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddBtn, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.ArmorInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DamageInput, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AgilityInput, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.EnduranceInput, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 294);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(891, 96);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // NameInput
            // 
            this.NameInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.NameInput.Location = new System.Drawing.Point(448, 54);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(211, 29);
            this.NameInput.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(448, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 41);
            this.label8.TabIndex = 10;
            this.label8.Text = "Имя";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpeedInput
            // 
            this.SpeedInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeedInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedInput.Location = new System.Drawing.Point(361, 54);
            this.SpeedInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.SpeedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpeedInput.Name = "SpeedInput";
            this.SpeedInput.Size = new System.Drawing.Size(81, 29);
            this.SpeedInput.TabIndex = 9;
            this.SpeedInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(361, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 41);
            this.label7.TabIndex = 8;
            this.label7.Text = "Атаки";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(665, 54);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(213, 29);
            this.AddBtn.TabIndex = 5;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ArmorInput
            // 
            this.ArmorInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmorInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArmorInput.Location = new System.Drawing.Point(100, 54);
            this.ArmorInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ArmorInput.Name = "ArmorInput";
            this.ArmorInput.Size = new System.Drawing.Size(81, 29);
            this.ArmorInput.TabIndex = 6;
            // 
            // DamageInput
            // 
            this.DamageInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DamageInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DamageInput.Location = new System.Drawing.Point(13, 54);
            this.DamageInput.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DamageInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DamageInput.Name = "DamageInput";
            this.DamageInput.Size = new System.Drawing.Size(81, 29);
            this.DamageInput.TabIndex = 5;
            this.DamageInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(274, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 41);
            this.label6.TabIndex = 2;
            this.label6.Text = "Здоровье";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(187, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 41);
            this.label5.TabIndex = 1;
            this.label5.Text = "Меткость";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AgilityInput
            // 
            this.AgilityInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AgilityInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgilityInput.Location = new System.Drawing.Point(187, 54);
            this.AgilityInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.AgilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AgilityInput.Name = "AgilityInput";
            this.AgilityInput.Size = new System.Drawing.Size(81, 29);
            this.AgilityInput.TabIndex = 6;
            this.AgilityInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // EnduranceInput
            // 
            this.EnduranceInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnduranceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnduranceInput.Location = new System.Drawing.Point(274, 54);
            this.EnduranceInput.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.EnduranceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EnduranceInput.Name = "EnduranceInput";
            this.EnduranceInput.Size = new System.Drawing.Size(81, 29);
            this.EnduranceInput.TabIndex = 6;
            this.EnduranceInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SwitchLabel);
            this.panel1.Controls.Add(this.TeamSwitch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(665, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 35);
            this.panel1.TabIndex = 7;
            // 
            // SwitchLabel
            // 
            this.SwitchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SwitchLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwitchLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SwitchLabel.Location = new System.Drawing.Point(3, 0);
            this.SwitchLabel.Name = "SwitchLabel";
            this.SwitchLabel.Size = new System.Drawing.Size(72, 35);
            this.SwitchLabel.TabIndex = 5;
            this.SwitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TeamSwitch
            // 
            this.TeamSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeamSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TeamSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeamSwitch.ForeColor = System.Drawing.Color.Black;
            this.TeamSwitch.Location = new System.Drawing.Point(86, 3);
            this.TeamSwitch.Name = "TeamSwitch";
            this.TeamSwitch.Size = new System.Drawing.Size(124, 29);
            this.TeamSwitch.TabIndex = 7;
            this.TeamSwitch.Text = "Сменить команду";
            this.TeamSwitch.UseVisualStyleBackColor = false;
            this.TeamSwitch.Click += new System.EventHandler(this.TeamSwitch_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(382, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Поменять местами";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Swap);
            // 
            // ClearDefenders
            // 
            this.ClearDefenders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearDefenders.Location = new System.Drawing.Point(619, 205);
            this.ClearDefenders.Name = "ClearDefenders";
            this.ClearDefenders.Size = new System.Drawing.Size(75, 23);
            this.ClearDefenders.TabIndex = 5;
            this.ClearDefenders.Text = "Очистить";
            this.ClearDefenders.UseVisualStyleBackColor = true;
            this.ClearDefenders.Click += new System.EventHandler(this.ClearDefenders_Click);
            // 
            // ClearAttackers
            // 
            this.ClearAttackers.Location = new System.Drawing.Point(202, 205);
            this.ClearAttackers.Name = "ClearAttackers";
            this.ClearAttackers.Size = new System.Drawing.Size(75, 23);
            this.ClearAttackers.TabIndex = 5;
            this.ClearAttackers.Text = "Очистить";
            this.ClearAttackers.UseVisualStyleBackColor = true;
            this.ClearAttackers.Click += new System.EventHandler(this.ClearAttackers_Click);
            // 
            // FightBtn
            // 
            this.FightBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FightBtn.BackColor = System.Drawing.Color.Red;
            this.FightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FightBtn.Location = new System.Drawing.Point(382, 121);
            this.FightBtn.Name = "FightBtn";
            this.FightBtn.Size = new System.Drawing.Size(132, 47);
            this.FightBtn.TabIndex = 5;
            this.FightBtn.Text = "Тест";
            this.FightBtn.UseVisualStyleBackColor = false;
            this.FightBtn.Click += new System.EventHandler(this.FightBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 390);
            this.Controls.Add(this.ClearAttackers);
            this.Controls.Add(this.FightBtn);
            this.Controls.Add(this.ClearDefenders);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DefendersList);
            this.Controls.Add(this.AttackersList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "X";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArmorInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgilityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnduranceInput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox AttackersList;
        private System.Windows.Forms.ListBox DefendersList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown ArmorInput;
        private System.Windows.Forms.NumericUpDown DamageInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown AgilityInput;
        private System.Windows.Forms.NumericUpDown EnduranceInput;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button TeamSwitch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SwitchLabel;
        private System.Windows.Forms.NumericUpDown SpeedInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ClearDefenders;
        private System.Windows.Forms.Button ClearAttackers;
        private System.Windows.Forms.Button FightBtn;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.Label label8;
    }
}

