namespace AplikacjaPracownicy
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Button buttonWczytaj;
        private System.Windows.Forms.Button buttonZapiszJSON;
        private System.Windows.Forms.Button buttonWczytajJSON;
        private System.Windows.Forms.Button buttonZapiszXML;
        private System.Windows.Forms.Button buttonWczytajXML;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.buttonZapisz = new System.Windows.Forms.Button();
            this.buttonWczytaj = new System.Windows.Forms.Button();
            this.buttonZapiszJSON = new System.Windows.Forms.Button();
            this.buttonWczytajJSON = new System.Windows.Forms.Button();
            this.buttonZapiszXML = new System.Windows.Forms.Button();
            this.buttonWczytajXML = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(686, 380);
            this.dataGridView1.TabIndex = 0;
            
            this.buttonDodaj.Location = new System.Drawing.Point(710, 12);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(120, 35);
            this.buttonDodaj.TabIndex = 1;
            this.buttonDodaj.Text = "Dodaj";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            
            this.buttonUsun.Location = new System.Drawing.Point(710, 60);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(120, 35);
            this.buttonUsun.TabIndex = 2;
            this.buttonUsun.Text = "Usuń";
            this.buttonUsun.UseVisualStyleBackColor = true;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            
            this.buttonZapisz.Location = new System.Drawing.Point(12, 400);
            this.buttonZapisz.Name = "buttonZapisz";
            this.buttonZapisz.Size = new System.Drawing.Size(110, 35);
            this.buttonZapisz.TabIndex = 3;
            this.buttonZapisz.Text = "Zapisz CSV";
            this.buttonZapisz.UseVisualStyleBackColor = true;
            this.buttonZapisz.Click += new System.EventHandler(this.buttonZapisz_Click);
            
            this.buttonWczytaj.Location = new System.Drawing.Point(128, 400);
            this.buttonWczytaj.Name = "buttonWczytaj";
            this.buttonWczytaj.Size = new System.Drawing.Size(110, 35);
            this.buttonWczytaj.TabIndex = 4;
            this.buttonWczytaj.Text = "Odczyt CSV";
            this.buttonWczytaj.UseVisualStyleBackColor = true;
            this.buttonWczytaj.Click += new System.EventHandler(this.buttonWczytaj_Click);
            
            this.buttonZapiszXML.Location = new System.Drawing.Point(244, 400);
            this.buttonZapiszXML.Name = "buttonZapiszXML";
            this.buttonZapiszXML.Size = new System.Drawing.Size(110, 35);
            this.buttonZapiszXML.TabIndex = 5;
            this.buttonZapiszXML.Text = "Zapisz XML";
            this.buttonZapiszXML.UseVisualStyleBackColor = true;
            this.buttonZapiszXML.Click += new System.EventHandler(this.buttonZapiszXML_Click);
            
            this.buttonWczytajXML.Location = new System.Drawing.Point(360, 400);
            this.buttonWczytajXML.Name = "buttonWczytajXML";
            this.buttonWczytajXML.Size = new System.Drawing.Size(110, 35);
            this.buttonWczytajXML.TabIndex = 6;
            this.buttonWczytajXML.Text = "Odczyt XML";
            this.buttonWczytajXML.UseVisualStyleBackColor = true;
            this.buttonWczytajXML.Click += new System.EventHandler(this.buttonWczytajXML_Click);
            
            this.buttonZapiszJSON.Location = new System.Drawing.Point(476, 400);
            this.buttonZapiszJSON.Name = "buttonZapiszJSON";
            this.buttonZapiszJSON.Size = new System.Drawing.Size(110, 35);
            this.buttonZapiszJSON.TabIndex = 7;
            this.buttonZapiszJSON.Text = "Zapisz JSON";
            this.buttonZapiszJSON.UseVisualStyleBackColor = true;
            this.buttonZapiszJSON.Click += new System.EventHandler(this.buttonZapiszJSON_Click);
            
            this.buttonWczytajJSON.Location = new System.Drawing.Point(592, 400);
            this.buttonWczytajJSON.Name = "buttonWczytajJSON";
            this.buttonWczytajJSON.Size = new System.Drawing.Size(110, 35);
            this.buttonWczytajJSON.TabIndex = 8;
            this.buttonWczytajJSON.Text = "Odczyt JSON";
            this.buttonWczytajJSON.UseVisualStyleBackColor = true;
            this.buttonWczytajJSON.Click += new System.EventHandler(this.buttonWczytajJSON_Click);
            
            this.ClientSize = new System.Drawing.Size(840, 461);
            this.Controls.Add(this.buttonWczytajJSON);
            this.Controls.Add(this.buttonZapiszJSON);
            this.Controls.Add(this.buttonWczytajXML);
            this.Controls.Add(this.buttonZapiszXML);
            this.Controls.Add(this.buttonWczytaj);
            this.Controls.Add(this.buttonZapisz);
            this.Controls.Add(this.buttonUsun);
            this.Controls.Add(this.buttonDodaj);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Arkusz Pracowników";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}