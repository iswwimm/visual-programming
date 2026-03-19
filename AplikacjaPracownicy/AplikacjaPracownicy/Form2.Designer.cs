namespace AplikacjaPracownicy
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxWiek;
        private System.Windows.Forms.ComboBox comboBoxStanowisko;
        private System.Windows.Forms.Button buttonZatwierdz;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.Label labelImie;
        private System.Windows.Forms.Label labelNazwisko;
        private System.Windows.Forms.Label labelWiek;
        private System.Windows.Forms.Label labelStanowisko;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxImie = new System.Windows.Forms.TextBox();
            textBoxNazwisko = new System.Windows.Forms.TextBox();
            textBoxWiek = new System.Windows.Forms.TextBox();
            comboBoxStanowisko = new System.Windows.Forms.ComboBox();
            buttonZatwierdz = new System.Windows.Forms.Button();
            buttonAnuluj = new System.Windows.Forms.Button();
            labelImie = new System.Windows.Forms.Label();
            labelNazwisko = new System.Windows.Forms.Label();
            labelWiek = new System.Windows.Forms.Label();
            labelStanowisko = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // textBoxImie
            // 
            textBoxImie.Location = new System.Drawing.Point(120, 27);
            textBoxImie.Name = "textBoxImie";
            textBoxImie.Size = new System.Drawing.Size(150, 27);
            textBoxImie.TabIndex = 8;
            // 
            // textBoxNazwisko
            // 
            textBoxNazwisko.Location = new System.Drawing.Point(120, 67);
            textBoxNazwisko.Name = "textBoxNazwisko";
            textBoxNazwisko.Size = new System.Drawing.Size(150, 27);
            textBoxNazwisko.TabIndex = 6;
            // 
            // textBoxWiek
            // 
            textBoxWiek.Location = new System.Drawing.Point(120, 107);
            textBoxWiek.Name = "textBoxWiek";
            textBoxWiek.Size = new System.Drawing.Size(150, 27);
            textBoxWiek.TabIndex = 4;
            // 
            // comboBoxStanowisko
            // 
            comboBoxStanowisko.FormattingEnabled = true;
            comboBoxStanowisko.Location = new System.Drawing.Point(120, 147);
            comboBoxStanowisko.Name = "comboBoxStanowisko";
            comboBoxStanowisko.Size = new System.Drawing.Size(150, 28);
            comboBoxStanowisko.TabIndex = 2;
            // 
            // buttonZatwierdz
            // 
            buttonZatwierdz.Location = new System.Drawing.Point(30, 200);
            buttonZatwierdz.Name = "buttonZatwierdz";
            buttonZatwierdz.Size = new System.Drawing.Size(100, 30);
            buttonZatwierdz.TabIndex = 1;
            buttonZatwierdz.Text = "Zatwierdź";
            buttonZatwierdz.UseVisualStyleBackColor = true;
            buttonZatwierdz.Click += buttonZatwierdz_Click;
            // 
            // buttonAnuluj
            // 
            buttonAnuluj.Location = new System.Drawing.Point(170, 200);
            buttonAnuluj.Name = "buttonAnuluj";
            buttonAnuluj.Size = new System.Drawing.Size(100, 30);
            buttonAnuluj.TabIndex = 0;
            buttonAnuluj.Text = "Anuluj";
            buttonAnuluj.UseVisualStyleBackColor = true;
            buttonAnuluj.Click += buttonAnuluj_Click;
            // 
            // labelImie
            // 
            labelImie.AutoSize = true;
            labelImie.Location = new System.Drawing.Point(30, 30);
            labelImie.Name = "labelImie";
            labelImie.Size = new System.Drawing.Size(41, 20);
            labelImie.TabIndex = 9;
            labelImie.Text = "Imię:";
            // 
            // labelNazwisko
            // 
            labelNazwisko.AutoSize = true;
            labelNazwisko.Location = new System.Drawing.Point(30, 70);
            labelNazwisko.Name = "labelNazwisko";
            labelNazwisko.Size = new System.Drawing.Size(75, 20);
            labelNazwisko.TabIndex = 7;
            labelNazwisko.Text = "Nazwisko:";
            // 
            // labelWiek
            // 
            labelWiek.AutoSize = true;
            labelWiek.Location = new System.Drawing.Point(30, 110);
            labelWiek.Name = "labelWiek";
            labelWiek.Size = new System.Drawing.Size(45, 20);
            labelWiek.TabIndex = 5;
            labelWiek.Text = "Wiek:";
            // 
            // labelStanowisko
            // 
            labelStanowisko.AutoSize = true;
            labelStanowisko.Location = new System.Drawing.Point(30, 150);
            labelStanowisko.Name = "labelStanowisko";
            labelStanowisko.Size = new System.Drawing.Size(87, 20);
            labelStanowisko.TabIndex = 3;
            labelStanowisko.Text = "Stanowisko:";
            // 
            // Form2
            // 
            ClientSize = new System.Drawing.Size(314, 261);
            Controls.Add(buttonAnuluj);
            Controls.Add(buttonZatwierdz);
            Controls.Add(comboBoxStanowisko);
            Controls.Add(labelStanowisko);
            Controls.Add(textBoxWiek);
            Controls.Add(labelWiek);
            Controls.Add(textBoxNazwisko);
            Controls.Add(labelNazwisko);
            Controls.Add(textBoxImie);
            Controls.Add(labelImie);
            Text = "Dodaj Pracownika";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}