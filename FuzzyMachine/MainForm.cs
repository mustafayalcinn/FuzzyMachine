using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyMachine
{
	public partial class MainForm : Form
	{
		private FuzzyInferenceSystem fis;

		public MainForm()
		{
			InitializeComponent();
			InitializeFuzzySystem();
		}

		private void InitializeFuzzySystem()
		{
			fis = new FuzzyInferenceSystem();

			// Input variables
			var sensitivity = new FuzzyVariable("Hassaslık", 0, 10);
			sensitivity.AddMembershipFunction(new TrapezoidMF("Sağlam", -4, -1.5, 2, 4));
			sensitivity.AddMembershipFunction(new TriangularMF("Orta", 3, 5, 7));
			sensitivity.AddMembershipFunction(new TrapezoidMF("Hassas", 5.5, 8, 12.5, 14));
			fis.AddInputVariable(sensitivity);

			var amount = new FuzzyVariable("Miktar", 0, 10);
			amount.AddMembershipFunction(new TrapezoidMF("Küçük", -4, -1.5, 2, 4));
			amount.AddMembershipFunction(new TriangularMF("Orta", 3, 5, 7));
			amount.AddMembershipFunction(new TrapezoidMF("Büyük", 5.5, 8, 12.5, 14));
			fis.AddInputVariable(amount);

			var dirtiness = new FuzzyVariable("Kirlilik", 0, 10);
			dirtiness.AddMembershipFunction(new TrapezoidMF("Küçük", -4.5, -2.5, 2, 4.5));
			dirtiness.AddMembershipFunction(new TriangularMF("Orta", 3, 5, 7));
			dirtiness.AddMembershipFunction(new TrapezoidMF("Büyük", 5.5, 8, 12.5, 15));
			fis.AddInputVariable(dirtiness);

			// Output variables
			var rotationSpeed = new FuzzyVariable("Dönüş Hızı", 0, 10);
			rotationSpeed.AddMembershipFunction(new TrapezoidMF("Hassas", -5.8, -2.8, 0.5, 1.5));
			rotationSpeed.AddMembershipFunction(new TriangularMF("Normal_Hassas", 0.5, 2.75, 5));
			rotationSpeed.AddMembershipFunction(new TriangularMF("Orta", 2.75, 5, 7.25));
			rotationSpeed.AddMembershipFunction(new TriangularMF("Normal_Güçlü", 5, 7.25, 9.5));
			rotationSpeed.AddMembershipFunction(new TrapezoidMF("Güçlü", 8.5, 9.5, 12.8, 15.2));
			fis.AddOutputVariable(rotationSpeed);

			var duration = new FuzzyVariable("Süre", 0, 100);
			duration.AddMembershipFunction(new TrapezoidMF("Kısa", -46.5, -25.28, 22.3, 39.9));
			duration.AddMembershipFunction(new TriangularMF("Normal_Kısa", 22.3, 39.9, 57.5));
			duration.AddMembershipFunction(new TriangularMF("Orta", 39.9, 57.5, 75.1));
			duration.AddMembershipFunction(new TriangularMF("Normal_Uzun", 57.5, 75.1, 92.7));
			duration.AddMembershipFunction(new TrapezoidMF("Uzun", 75, 92.7, 111.6, 130));
			fis.AddOutputVariable(duration);

			var detergentAmount = new FuzzyVariable("Deterjan Miktarı", 0, 300);
			detergentAmount.AddMembershipFunction(new TrapezoidMF("Çok_Az", 0, 0, 20, 85));
			detergentAmount.AddMembershipFunction(new TriangularMF("Az", 20, 85, 150));
			detergentAmount.AddMembershipFunction(new TriangularMF("Orta", 85, 150, 215));
			detergentAmount.AddMembershipFunction(new TriangularMF("Fazla", 150, 215, 280));
			detergentAmount.AddMembershipFunction(new TrapezoidMF("Çok_Fazla", 215, 280, 300, 300));
			fis.AddOutputVariable(detergentAmount);

			// Rules
			AddRules();
		}

		private void AddRules()
		{
			// Rule 1
			var rule1 = new FuzzyRule(1);
			rule1.AddAntecedent("Hassaslık", "Hassas");
			rule1.AddAntecedent("Miktar", "Küçük");
			rule1.AddAntecedent("Kirlilik", "Küçük");
			rule1.AddConsequent("Dönüş Hızı", "Hassas");
			rule1.AddConsequent("Süre", "Kısa");
			rule1.AddConsequent("Deterjan Miktarı", "Çok_Az");
			fis.AddRule(rule1);

			// Rule 2
			var rule2 = new FuzzyRule(2);
			rule2.AddAntecedent("Hassaslık", "Hassas");
			rule2.AddAntecedent("Miktar", "Küçük");
			rule2.AddAntecedent("Kirlilik", "Orta");
			rule2.AddConsequent("Dönüş Hızı", "Normal_Hassas");
			rule2.AddConsequent("Süre", "Kısa");
			rule2.AddConsequent("Deterjan Miktarı", "Az");
			fis.AddRule(rule2);

			// Rule 3
			var rule3 = new FuzzyRule(3);
			rule3.AddAntecedent("Hassaslık", "Hassas");
			rule3.AddAntecedent("Miktar", "Küçük");
			rule3.AddAntecedent("Kirlilik", "Büyük");
			rule3.AddConsequent("Dönüş Hızı", "Orta");
			rule3.AddConsequent("Süre", "Normal_Kısa");
			rule3.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule3);

			// Rule 4
			var rule4 = new FuzzyRule(4);
			rule4.AddAntecedent("Hassaslık", "Hassas");
			rule4.AddAntecedent("Miktar", "Orta");
			rule4.AddAntecedent("Kirlilik", "Küçük");
			rule4.AddConsequent("Dönüş Hızı", "Hassas");
			rule4.AddConsequent("Süre", "Kısa");
			rule4.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule4);


			// Rule 5
			var rule5 = new FuzzyRule(5);
			rule5.AddAntecedent("Hassaslık", "Hassas");
			rule5.AddAntecedent("Miktar", "Orta");
			rule5.AddAntecedent("Kirlilik", "Orta");
			rule5.AddConsequent("Dönüş Hızı", "Normal_Hassas");
			rule5.AddConsequent("Süre", "Normal_Kısa");
			rule5.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule5);

			// Rule 6
			var rule6 = new FuzzyRule(6);
			rule6.AddAntecedent("Hassaslık", "Hassas");
			rule6.AddAntecedent("Miktar", "Orta");
			rule6.AddAntecedent("Kirlilik", "Büyük");
			rule6.AddConsequent("Dönüş Hızı", "Orta");
			rule6.AddConsequent("Süre", "Orta");
			rule6.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule6);


			// Rule 7
			var rule7 = new FuzzyRule(7);
			rule7.AddAntecedent("Hassaslık", "Hassas");
			rule7.AddAntecedent("Miktar", "Büyük");
			rule7.AddAntecedent("Kirlilik", "Küçük");
			rule7.AddConsequent("Dönüş Hızı", "Normal_Hassas");
			rule7.AddConsequent("Süre", "Normal_Kısa");
			rule7.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule7);


			// Rule 8
			var rule8 = new FuzzyRule(8);
			rule8.AddAntecedent("Hassaslık", "Hassas");
			rule8.AddAntecedent("Miktar", "Büyük");
			rule8.AddAntecedent("Kirlilik", "Orta");
			rule8.AddConsequent("Dönüş Hızı", "Normal_Hassas");
			rule8.AddConsequent("Süre", "Orta");
			rule8.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule8);

			// Rule 9
			var rule9 = new FuzzyRule(9);
			rule9.AddAntecedent("Hassaslık", "Hassas");
			rule9.AddAntecedent("Miktar", "Büyük");
			rule9.AddAntecedent("Kirlilik", "Büyük");
			rule9.AddConsequent("Dönüş Hızı", "Orta");
			rule9.AddConsequent("Süre", "Normal_Uzun");
			rule9.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule9);

			// Rule 10
			var rule10 = new FuzzyRule(10);
			rule10.AddAntecedent("Hassaslık", "Orta");
			rule10.AddAntecedent("Miktar", "Küçük");
			rule10.AddAntecedent("Kirlilik", "Küçük");
			rule10.AddConsequent("Dönüş Hızı", "Normal_Hassas");
			rule10.AddConsequent("Süre", "Normal_Kısa");
			rule10.AddConsequent("Deterjan Miktarı", "Az");
			fis.AddRule(rule10);

			// Rule 11
			var rule11 = new FuzzyRule(11);
			rule11.AddAntecedent("Hassaslık", "Orta");
			rule11.AddAntecedent("Miktar", "Küçük");
			rule11.AddAntecedent("Kirlilik", "Orta");
			rule11.AddConsequent("Dönüş Hızı", "Orta");
			rule11.AddConsequent("Süre", "Kısa");
			rule11.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule11);

			// Rule 12
			var rule12 = new FuzzyRule(12);
			rule12.AddAntecedent("Hassaslık", "Orta");
			rule12.AddAntecedent("Miktar", "Küçük");
			rule12.AddAntecedent("Kirlilik", "Büyük");
			rule12.AddConsequent("Dönüş Hızı", "Normal_Güçlü");
			rule12.AddConsequent("Süre", "Orta");
			rule12.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule12);


			// Rule 13
			var rule13 = new FuzzyRule(13);
			rule13.AddAntecedent("Hassaslık", "Orta");
			rule13.AddAntecedent("Miktar", "Orta");
			rule13.AddAntecedent("Kirlilik", "Küçük");
			rule13.AddConsequent("Dönüş Hızı", "Normal_Hassas");
			rule13.AddConsequent("Süre", "Normal_Kısa");
			rule13.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule13);

			// Rule 14
			var rule14 = new FuzzyRule(14);
			rule14.AddAntecedent("Hassaslık", "Orta");
			rule14.AddAntecedent("Miktar", "Orta");
			rule14.AddAntecedent("Kirlilik", "Orta");
			rule14.AddConsequent("Dönüş Hızı", "Orta");
			rule14.AddConsequent("Süre", "Orta");
			rule14.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule14);

			// Rule 15
			var rule15 = new FuzzyRule(15);
			rule15.AddAntecedent("Hassaslık", "Orta");
			rule15.AddAntecedent("Miktar", "Orta");
			rule15.AddAntecedent("Kirlilik", "Büyük");
			rule15.AddConsequent("Dönüş Hızı", "Hassas");
			rule15.AddConsequent("Süre", "Uzun");
			rule15.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule15);

			// Rule 16
			var rule16 = new FuzzyRule(16);
			rule16.AddAntecedent("Hassaslık", "Orta");
			rule16.AddAntecedent("Miktar", "Büyük");
			rule16.AddAntecedent("Kirlilik", "Küçük");
			rule16.AddConsequent("Dönüş Hızı", "Hassas");
			rule16.AddConsequent("Süre", "Orta");
			rule16.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule16);


			// Rule 17
			var rule17 = new FuzzyRule(17);
			rule17.AddAntecedent("Hassaslık", "Orta");
			rule17.AddAntecedent("Miktar", "Büyük");
			rule17.AddAntecedent("Kirlilik", "Orta");
			rule17.AddConsequent("Dönüş Hızı", "Hassas");
			rule17.AddConsequent("Süre", "Normal_Uzun");
			rule17.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule17);


			// Rule 18
			var rule18 = new FuzzyRule(18);
			rule18.AddAntecedent("Hassaslık", "Orta");
			rule18.AddAntecedent("Miktar", "Büyük");
			rule18.AddAntecedent("Kirlilik", "Büyük");
			rule18.AddConsequent("Dönüş Hızı", "Hassas");
			rule18.AddConsequent("Süre", "Uzun");
			rule18.AddConsequent("Deterjan Miktarı", "Çok_Fazla");
			fis.AddRule(rule18);

			// Rule 19
			var rule19 = new FuzzyRule(19);
			rule19.AddAntecedent("Hassaslık", "Sağlam");
			rule19.AddAntecedent("Miktar", "Küçük");
			rule19.AddAntecedent("Kirlilik", "Küçük");
			rule19.AddConsequent("Dönüş Hızı", "Orta");
			rule19.AddConsequent("Süre", "Orta");
			rule19.AddConsequent("Deterjan Miktarı", "Az");
			fis.AddRule(rule19);

			// Rule 20
			var rule20 = new FuzzyRule(20);
			rule20.AddAntecedent("Hassaslık", "Sağlam");
			rule20.AddAntecedent("Miktar", "Küçük");
			rule20.AddAntecedent("Kirlilik", "Orta");
			rule20.AddConsequent("Dönüş Hızı", "Normal_Güçlü");
			rule20.AddConsequent("Süre", "Orta");
			rule20.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule20);


			// Rule 21
			var rule21 = new FuzzyRule(21);
			rule21.AddAntecedent("Hassaslık", "Sağlam");
			rule21.AddAntecedent("Miktar", "Küçük");
			rule21.AddAntecedent("Kirlilik", "Büyük");
			rule21.AddConsequent("Dönüş Hızı", "Güçlü");
			rule21.AddConsequent("Süre", "Normal_Uzun");
			rule21.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule21);

			// Rule 22
			var rule22 = new FuzzyRule(22);
			rule22.AddAntecedent("Hassaslık", "Sağlam");
			rule22.AddAntecedent("Miktar", "Orta");
			rule22.AddAntecedent("Kirlilik", "Küçük");
			rule22.AddConsequent("Dönüş Hızı", "Orta");
			rule22.AddConsequent("Süre", "Orta");
			rule22.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule22);

			// Rule 23
			var rule23 = new FuzzyRule(23);
			rule23.AddAntecedent("Hassaslık", "Sağlam");
			rule23.AddAntecedent("Miktar", "Orta");
			rule23.AddAntecedent("Kirlilik", "Orta");
			rule23.AddConsequent("Dönüş Hızı", "Normal_Güçlü");
			rule23.AddConsequent("Süre", "Normal_Uzun");
			rule23.AddConsequent("Deterjan Miktarı", "Orta");
			fis.AddRule(rule23);


			// Rule 24
			var rule24 = new FuzzyRule(24);
			rule24.AddAntecedent("Hassaslık", "Sağlam");
			rule24.AddAntecedent("Miktar", "Orta");
			rule24.AddAntecedent("Kirlilik", "Büyük");
			rule24.AddConsequent("Dönüş Hızı", "Güçlü");
			rule24.AddConsequent("Süre", "Orta");
			rule24.AddConsequent("Deterjan Miktarı", "Çok_Fazla");
			fis.AddRule(rule24);


			// Rule 25
			var rule25 = new FuzzyRule(25);
			rule25.AddAntecedent("Hassaslık", "Sağlam");
			rule25.AddAntecedent("Miktar", "Büyük");
			rule25.AddAntecedent("Kirlilik", "Küçük");
			rule25.AddConsequent("Dönüş Hızı", "Normal_Güçlü");
			rule25.AddConsequent("Süre", "Normal_Uzun");
			rule25.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule25);

			// Rule 26
			var rule26 = new FuzzyRule(26);
			rule26.AddAntecedent("Hassaslık", "Sağlam");
			rule26.AddAntecedent("Miktar", "Büyük");
			rule26.AddAntecedent("Kirlilik", "Orta");
			rule26.AddConsequent("Dönüş Hızı", "Normal_Güçlü");
			rule26.AddConsequent("Süre", "Uzun");
			rule26.AddConsequent("Deterjan Miktarı", "Fazla");
			fis.AddRule(rule26);

			// Rule 27
			var rule27 = new FuzzyRule(27);
			rule27.AddAntecedent("Hassaslık", "Sağlam");
			rule27.AddAntecedent("Miktar", "Büyük");
			rule27.AddAntecedent("Kirlilik", "Büyük");
			rule27.AddConsequent("Dönüş Hızı", "Güçlü");
			rule27.AddConsequent("Süre", "Uzun");
			rule27.AddConsequent("Deterjan Miktarı", "Çok_Fazla");
			fis.AddRule(rule27);




		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			
		}

		private void ShowActivatedRules(Dictionary<string, double> inputValues)
		{
			// Fuzzify inputs
			Dictionary<string, Dictionary<string, double>> fuzzifiedInputs = new Dictionary<string, Dictionary<string, double>>();

			foreach (var inputVariable in fis.InputVariables)
			{
				if (inputValues.ContainsKey(inputVariable.Name))
				{
					double crispValue = inputValues[inputVariable.Name];
					fuzzifiedInputs[inputVariable.Name] = inputVariable.Fuzzify(crispValue);
				}
			}

			// Clear previous rules
			dgvRules.Rows.Clear();

			// Add activated rules
			foreach (var rule in fis.Rules)
			{
				double firingStrength = rule.GetFiringStrength(fuzzifiedInputs);

				if (firingStrength > 0)
				{
					dgvRules.Rows.Add(
						rule.RuleNumber,
						string.Join(" AND ", rule.Antecedents.Select(a => $"{a.Key} = {a.Value}")),
						string.Join(" AND ", rule.Consequents.Select(c => $"{c.Key} = {c.Value}")),
						firingStrength.ToString("F2")
					);
				}
			}
		}

		private void DrawFuzzyOutputs(Dictionary<string, double> results)
		{
			// Aktif kuralların sonuç değerlerini hesapla
			Dictionary<string, Dictionary<string, double>> activatedOutputs = new Dictionary<string, Dictionary<string, double>>();

			// Önce girişleri fuzzylaştır
			Dictionary<string, Dictionary<string, double>> fuzzifiedInputs = new Dictionary<string, Dictionary<string, double>>();
			foreach (var inputVar in fis.InputVariables)
			{
				double crispValue = 0;
				if (inputVar.Name == "Hassaslık")
					crispValue = trackBarSensitivity.Value;
				else if (inputVar.Name == "Miktar")
					crispValue = trackBarAmount.Value;
				else if (inputVar.Name == "Kirlilik")
					crispValue = trackBarDirtiness.Value;

				fuzzifiedInputs[inputVar.Name] = inputVar.Fuzzify(crispValue);
			}

			// Her çıkış değişkeni için aktif üyelik fonksiyonlarını bul
			foreach (var outputVar in fis.OutputVariables)
			{
				activatedOutputs[outputVar.Name] = new Dictionary<string, double>();

				// Her üyelik fonksiyonu için maksimum aktivasyon derecesini bul
				foreach (var mf in outputVar.MembershipFunctions)
				{
					activatedOutputs[outputVar.Name][mf.Name] = 0; // Başlangıç değeri
				}

				// Tüm kuralları kontrol et
				foreach (var rule in fis.Rules)
				{
					// Kuralın ateşleme gücünü hesapla
					double firingStrength = rule.GetFiringStrength(fuzzifiedInputs);

					if (firingStrength > 0)
					{
						// Bu kuralın sonuçlarını işle
						foreach (var consequent in rule.Consequents)
						{
							if (consequent.Key == outputVar.Name)
							{
								// Eğer bu üyelik fonksiyonu için daha yüksek bir aktivasyon varsa güncelle
								if (firingStrength > activatedOutputs[outputVar.Name][consequent.Value])
								{
									activatedOutputs[outputVar.Name][consequent.Value] = firingStrength;
								}
							}
						}
					}
				}
			}

			// Create tabs for each output variable if they don't exist
			if (tabControlOutputs.TabPages.Count == 0)
			{
				foreach (var outputVar in fis.OutputVariables)
				{
					TabPage tab = new TabPage(outputVar.Name);
					PictureBox pictureBox = new PictureBox();
					pictureBox.Dock = DockStyle.Fill;
					pictureBox.BackColor = Color.White;
					pictureBox.Tag = outputVar.Name;
					tab.Controls.Add(pictureBox);
					tabControlOutputs.TabPages.Add(tab);
				}
			}
			else
			{
				// Make sure each tab has a PictureBox
				foreach (TabPage tab in tabControlOutputs.TabPages)
				{
					if (tab.Controls.Count == 0)
					{
						PictureBox pictureBox = new PictureBox();
						pictureBox.Dock = DockStyle.Fill;
						pictureBox.BackColor = Color.White;

						// Find corresponding output variable name
						string varName = "";
						foreach (var outputVar in fis.OutputVariables)
						{
							if (tab.Text == outputVar.Name)
							{
								varName = outputVar.Name;
								break;
							}
						}

						pictureBox.Tag = varName;
						tab.Controls.Add(pictureBox);
					}
				}
			}

			// Draw each output variable's membership functions and defuzzification
			foreach (TabPage tab in tabControlOutputs.TabPages)
			{
				if (tab.Controls.Count > 0)
				{
					PictureBox pictureBox = tab.Controls[0] as PictureBox;
					string varName = pictureBox.Tag.ToString();
					FuzzyVariable outputVar = fis.OutputVariables.Find(v => v.Name == varName);

					Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
					using (Graphics g = Graphics.FromImage(bmp))
					{
						g.Clear(Color.White);

						// Find min and max for variable
						double min = outputVar.MinValue;
						double max = outputVar.MaxValue;
						double range = max - min;

						// Calculate scale
						int padding = 30;
						int graphWidth = pictureBox.Width - 2 * padding;
						int graphHeight = pictureBox.Height - 2 * padding;
						double xScale = graphWidth / range;

						// Draw axes
						Pen axisPen = new Pen(Color.Black, 2);
						g.DrawLine(axisPen, padding, pictureBox.Height - padding,
								  padding + graphWidth, pictureBox.Height - padding); // X-axis
						g.DrawLine(axisPen, padding, padding,
								  padding, pictureBox.Height - padding); // Y-axis

						// Draw ticks and labels on x-axis
						int tickCount = 5;
						for (int i = 0; i <= tickCount; i++)
						{
							int x = padding + (i * graphWidth / tickCount);
							double value = min + (i * range / tickCount);
							g.DrawLine(Pens.Black, x, pictureBox.Height - padding, x, pictureBox.Height - padding + 5);
							g.DrawString(value.ToString("F1"), new Font("Arial", 8), Brushes.Black,
										x - 10, pictureBox.Height - padding + 5);
						}

						// Create pens and brushes for each membership function
						Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };
						Dictionary<string, Pen> mfPens = new Dictionary<string, Pen>();
						Dictionary<string, Brush> mfBrushes = new Dictionary<string, Brush>();

						int penIndex = 0;
						foreach (var mf in outputVar.MembershipFunctions)
						{
							Color color = colors[penIndex % colors.Length];
							mfPens.Add(mf.Name, new Pen(color, 2));

							// Doldurma için yarı saydam renkler oluştur
							Color fillColor = Color.FromArgb(80, color.R, color.G, color.B);
							mfBrushes.Add(mf.Name, new SolidBrush(fillColor));

							penIndex++;
						}

						// Aktif bölgeleri doldur (üyelik fonksiyonlarını çizmeden önce)
						foreach (var mf in outputVar.MembershipFunctions)
						{
							// Bu üyelik fonksiyonu aktifse
							if (activatedOutputs[varName].ContainsKey(mf.Name) &&
								activatedOutputs[varName][mf.Name] > 0)
							{
								double activationLevel = activatedOutputs[varName][mf.Name];

								// Bu üyelik fonksiyonu için aktif bölgeyi hesapla
								List<Point> points = new List<Point>();

								// Önce x-eksenindeki başlangıç noktasını ekle
								points.Add(new Point(padding, pictureBox.Height - padding));

								// Üyelik fonksiyonu eğrisini hesapla
								for (int x = 0; x <= graphWidth; x++)
								{
									double value = min + (x / xScale);
									double degree = Math.Min(mf.GetMembershipDegree(value), activationLevel);
									int pixelX = padding + x;
									int pixelY = pictureBox.Height - padding - (int)(degree * graphHeight);
									points.Add(new Point(pixelX, pixelY));
								}

								// Son olarak x-eksenindeki bitiş noktasını ekle
								points.Add(new Point(padding + graphWidth, pictureBox.Height - padding));

								// Poligonu doldur
								g.FillPolygon(mfBrushes[mf.Name], points.ToArray());
							}
						}

						// Şimdi üyelik fonksiyonlarının çizgilerini çiz (doldurduktan sonra)
						foreach (var mf in outputVar.MembershipFunctions)
						{
							List<Point> points = new List<Point>();
							for (int x = 0; x <= graphWidth; x++)
							{
								double value = min + (x / xScale);
								double degree = mf.GetMembershipDegree(value);
								int pixelX = padding + x;
								int pixelY = pictureBox.Height - padding - (int)(degree * graphHeight);
								points.Add(new Point(pixelX, pixelY));
							}

							g.DrawLines(mfPens[mf.Name], points.ToArray());
						}

						// Draw crisp output value
						if (results.ContainsKey(varName))
						{
							double crispValue = results[varName];
							int crispX = padding + (int)((crispValue - min) * xScale);
							Pen crispPen = new Pen(Color.Black, 2);
							crispPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

							g.DrawLine(crispPen, crispX, padding, crispX, pictureBox.Height - padding);
							g.DrawString($"Result: {crispValue:F2}", new Font("Arial", 10, FontStyle.Bold),
										Brushes.Black, crispX - 40, padding - 20);
						}

						// Draw legend
						int legendX = padding + 10;
						int legendY = padding + 10;

						foreach (var mf in outputVar.MembershipFunctions)
						{
							g.DrawLine(mfPens[mf.Name], legendX, legendY, legendX + 20, legendY);
							g.DrawString(mf.Name, new Font("Arial", 8), Brushes.Black, legendX + 25, legendY - 7);
							legendY += 20;
						}

						// Aktivasyon seviyelerini lejanta ekle
						legendY += 20;
						g.DrawString("Aktivasyon Seviyeleri:", new Font("Arial", 8, FontStyle.Bold),
									Brushes.Black, legendX, legendY);
						legendY += 20;

						foreach (var mf in outputVar.MembershipFunctions)
						{
							double activationLevel = 0;
							if (activatedOutputs[varName].ContainsKey(mf.Name))
							{
								activationLevel = activatedOutputs[varName][mf.Name];
							}

							if (activationLevel > 0)
							{
								g.FillRectangle(mfBrushes[mf.Name], legendX, legendY, 20, 15);
								g.DrawRectangle(mfPens[mf.Name], legendX, legendY, 20, 15);
								g.DrawString($"{mf.Name}: {activationLevel:F2}", new Font("Arial", 8),
											Brushes.Black, legendX + 25, legendY);
								legendY += 20;
							}
						}
					}

					pictureBox.Image = bmp;
				}
			}
		}

		private void btnCalculate_Click_1(object sender, EventArgs e)
		{
			double sensitivity = trackBarSensitivity.Value;
			double amount = trackBarAmount.Value;
			double dirtiness = trackBarDirtiness.Value;

			Dictionary<string, double> inputValues = new Dictionary<string, double>
		{
			{ "Hassaslık", sensitivity },
			{ "Miktar", amount },
			{ "Kirlilik", dirtiness }
		};

			Dictionary<string, double> results = fis.Evaluate(inputValues);


			// Display results
			lblRotationSpeed.Text = $"Dönüş Hızı: {results["Dönüş Hızı"]:F2}";
			lblDuration.Text = $"Süre: {results["Süre"]:F2}";
			lblDetergentAmount.Text = $"Deterjan Miktarı: {results["Deterjan Miktarı"]:F2}";

			// Show activated rules
			ShowActivatedRules(inputValues);

			// Draw fuzzy outputs
			DrawFuzzyOutputs(results);
		}
	}
}
