namespace FuzzyMachine
{
	partial class MainForm
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
			trackBarSensitivity = new TrackBar();
			trackBarDirtiness = new TrackBar();
			trackBarAmount = new TrackBar();
			labelSensivity = new Label();
			labelAmount = new Label();
			labelDirty = new Label();
			lblRotationSpeed = new Label();
			lblDuration = new Label();
			lblDetergentAmount = new Label();
			btnCalculate = new Button();
			dgvRules = new DataGridView();
			KuralNo = new DataGridViewTextBoxColumn();
			AntecedentColumn = new DataGridViewTextBoxColumn();
			ConsequentColumn = new DataGridViewTextBoxColumn();
			FiringStrength = new DataGridViewTextBoxColumn();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			tabControlOutputs = new TabControl();
			((System.ComponentModel.ISupportInitialize)trackBarSensitivity).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBarDirtiness).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBarAmount).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvRules).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// trackBarSensitivity
			// 
			trackBarSensitivity.Location = new Point(119, 47);
			trackBarSensitivity.Name = "trackBarSensitivity";
			trackBarSensitivity.Size = new Size(208, 56);
			trackBarSensitivity.TabIndex = 0;
			// 
			// trackBarDirtiness
			// 
			trackBarDirtiness.Location = new Point(119, 166);
			trackBarDirtiness.Name = "trackBarDirtiness";
			trackBarDirtiness.Size = new Size(208, 56);
			trackBarDirtiness.TabIndex = 1;
			// 
			// trackBarAmount
			// 
			trackBarAmount.Location = new Point(119, 109);
			trackBarAmount.Name = "trackBarAmount";
			trackBarAmount.Size = new Size(208, 56);
			trackBarAmount.TabIndex = 2;
			// 
			// labelSensivity
			// 
			labelSensivity.AutoSize = true;
			labelSensivity.Location = new Point(24, 60);
			labelSensivity.Name = "labelSensivity";
			labelSensivity.Size = new Size(69, 20);
			labelSensivity.TabIndex = 3;
			labelSensivity.Text = "Hassaslık";
			// 
			// labelAmount
			// 
			labelAmount.AutoSize = true;
			labelAmount.Location = new Point(24, 113);
			labelAmount.Name = "labelAmount";
			labelAmount.Size = new Size(51, 20);
			labelAmount.TabIndex = 4;
			labelAmount.Text = "Miktar";
			// 
			// labelDirty
			// 
			labelDirty.AutoSize = true;
			labelDirty.Location = new Point(24, 166);
			labelDirty.Name = "labelDirty";
			labelDirty.Size = new Size(50, 20);
			labelDirty.TabIndex = 5;
			labelDirty.Text = "Kirlilik";
			// 
			// lblRotationSpeed
			// 
			lblRotationSpeed.AutoSize = true;
			lblRotationSpeed.Location = new Point(43, 33);
			lblRotationSpeed.Name = "lblRotationSpeed";
			lblRotationSpeed.Size = new Size(0, 20);
			lblRotationSpeed.TabIndex = 6;
			// 
			// lblDuration
			// 
			lblDuration.AutoSize = true;
			lblDuration.Location = new Point(43, 80);
			lblDuration.Name = "lblDuration";
			lblDuration.Size = new Size(0, 20);
			lblDuration.TabIndex = 7;
			// 
			// lblDetergentAmount
			// 
			lblDetergentAmount.AutoSize = true;
			lblDetergentAmount.Location = new Point(43, 128);
			lblDetergentAmount.Name = "lblDetergentAmount";
			lblDetergentAmount.Size = new Size(0, 20);
			lblDetergentAmount.TabIndex = 8;
			// 
			// btnCalculate
			// 
			btnCalculate.Location = new Point(224, 228);
			btnCalculate.Name = "btnCalculate";
			btnCalculate.Size = new Size(94, 29);
			btnCalculate.TabIndex = 9;
			btnCalculate.Text = "Hesapla";
			btnCalculate.UseVisualStyleBackColor = true;
			btnCalculate.Click += btnCalculate_Click_1;
			// 
			// dgvRules
			// 
			dgvRules.AllowUserToAddRows = false;
			dgvRules.AllowUserToDeleteRows = false;
			dgvRules.AllowUserToResizeColumns = false;
			dgvRules.AllowUserToResizeRows = false;
			dgvRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvRules.BackgroundColor = SystemColors.ButtonHighlight;
			dgvRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvRules.Columns.AddRange(new DataGridViewColumn[] { KuralNo, AntecedentColumn, ConsequentColumn, FiringStrength });
			dgvRules.Location = new Point(377, 172);
			dgvRules.Name = "dgvRules";
			dgvRules.RowHeadersWidth = 51;
			dgvRules.Size = new Size(710, 124);
			dgvRules.TabIndex = 13;
			// 
			// KuralNo
			// 
			KuralNo.HeaderText = "Kural No";
			KuralNo.MinimumWidth = 6;
			KuralNo.Name = "KuralNo";
			KuralNo.ReadOnly = true;
			// 
			// AntecedentColumn
			// 
			AntecedentColumn.HeaderText = "If Koşulu";
			AntecedentColumn.MinimumWidth = 6;
			AntecedentColumn.Name = "AntecedentColumn";
			AntecedentColumn.ReadOnly = true;
			// 
			// ConsequentColumn
			// 
			ConsequentColumn.HeaderText = "Then Koşulu";
			ConsequentColumn.MinimumWidth = 6;
			ConsequentColumn.Name = "ConsequentColumn";
			ConsequentColumn.ReadOnly = true;
			// 
			// FiringStrength
			// 
			FiringStrength.HeaderText = "Ateşleme Gücü";
			FiringStrength.MinimumWidth = 6;
			FiringStrength.Name = "FiringStrength";
			FiringStrength.ReadOnly = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(trackBarSensitivity);
			groupBox1.Controls.Add(labelSensivity);
			groupBox1.Controls.Add(trackBarDirtiness);
			groupBox1.Controls.Add(labelDirty);
			groupBox1.Controls.Add(btnCalculate);
			groupBox1.Controls.Add(trackBarAmount);
			groupBox1.Controls.Add(labelAmount);
			groupBox1.Location = new Point(24, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(347, 287);
			groupBox1.TabIndex = 14;
			groupBox1.TabStop = false;
			groupBox1.Text = "Giriş Değerleri";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(lblRotationSpeed);
			groupBox2.Controls.Add(lblDuration);
			groupBox2.Controls.Add(lblDetergentAmount);
			groupBox2.Location = new Point(377, 12);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(406, 154);
			groupBox2.TabIndex = 15;
			groupBox2.TabStop = false;
			groupBox2.Text = "Sonuçlar";
			// 
			// tabControlOutputs
			// 
			tabControlOutputs.Location = new Point(24, 325);
			tabControlOutputs.Name = "tabControlOutputs";
			tabControlOutputs.SelectedIndex = 0;
			tabControlOutputs.Size = new Size(1063, 362);
			tabControlOutputs.TabIndex = 16;
			tabControlOutputs.Tag = "amount";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1110, 713);
			Controls.Add(tabControlOutputs);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(dgvRules);
			Name = "MainForm";
			Text = "MainForm";
			((System.ComponentModel.ISupportInitialize)trackBarSensitivity).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBarDirtiness).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBarAmount).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvRules).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TrackBar trackBarSensitivity;
		private TrackBar trackBarDirtiness;
		private TrackBar trackBarAmount;
		private Label labelSensivity;
		private Label labelAmount;
		private Label labelDirty;
		private Label lblRotationSpeed;
		private Label lblDuration;
		private Label lblDetergentAmount;
		private Button btnCalculate;
		private DataGridView dgvRules;
		private DataGridViewTextBoxColumn KuralNo;
		private DataGridViewTextBoxColumn AntecedentColumn;
		private DataGridViewTextBoxColumn ConsequentColumn;
		private DataGridViewTextBoxColumn FiringStrength;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private TabControl tabControlOutputs;
	}
}