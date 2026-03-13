using System.ComponentModel;

namespace WinFormsApp1;

partial class Form1
{
    private IContainer components = null;

    private System.Windows.Forms.ListView listViewKoszyk;
    private System.Windows.Forms.ColumnHeader columnHeaderProdukt;
    private System.Windows.Forms.ColumnHeader columnHeaderCena;
    private System.Windows.Forms.Button btnDodajKomputer;
    private System.Windows.Forms.Button btnDodajMonitor;
    private System.Windows.Forms.Button btnZaplac;
    private System.Windows.Forms.Label lblCenaCalkowita;

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
        this.listViewKoszyk = new System.Windows.Forms.ListView();
        this.columnHeaderProdukt = new System.Windows.Forms.ColumnHeader();
        this.columnHeaderCena = new System.Windows.Forms.ColumnHeader();
        this.btnDodajKomputer = new System.Windows.Forms.Button();
        this.btnDodajMonitor = new System.Windows.Forms.Button();
        this.btnZaplac = new System.Windows.Forms.Button();
        this.lblCenaCalkowita = new System.Windows.Forms.Label();
        this.SuspendLayout();
        
        this.listViewKoszyk.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProdukt,
            this.columnHeaderCena});
        this.listViewKoszyk.FullRowSelect = true;
        this.listViewKoszyk.GridLines = true;
        this.listViewKoszyk.Location = new System.Drawing.Point(20, 20);
        this.listViewKoszyk.Name = "listViewKoszyk";
        this.listViewKoszyk.Size = new System.Drawing.Size(350, 200);
        this.listViewKoszyk.TabIndex = 0;
        this.listViewKoszyk.UseCompatibleStateImageBehavior = false;
        this.listViewKoszyk.View = System.Windows.Forms.View.Details;
        
        this.columnHeaderProdukt.Text = "Produkt";
        this.columnHeaderProdukt.Width = 230;
        
        this.columnHeaderCena.Text = "Cena (zł)";
        this.columnHeaderCena.Width = 100;
        
        this.btnDodajKomputer.Location = new System.Drawing.Point(400, 20);
        this.btnDodajKomputer.Name = "btnDodajKomputer";
        this.btnDodajKomputer.Size = new System.Drawing.Size(150, 40);
        this.btnDodajKomputer.TabIndex = 1;
        this.btnDodajKomputer.Text = "Dodaj Komputer";
        this.btnDodajKomputer.UseVisualStyleBackColor = true;
        this.btnDodajKomputer.Click += new System.EventHandler(this.btnDodajKomputer_Click);
        
        this.btnDodajMonitor.Location = new System.Drawing.Point(400, 80);
        this.btnDodajMonitor.Name = "btnDodajMonitor";
        this.btnDodajMonitor.Size = new System.Drawing.Size(150, 40);
        this.btnDodajMonitor.TabIndex = 2;
        this.btnDodajMonitor.Text = "Dodaj Monitor";
        this.btnDodajMonitor.UseVisualStyleBackColor = true;
        this.btnDodajMonitor.Click += new System.EventHandler(this.btnDodajMonitor_Click);
        
        this.btnZaplac.Location = new System.Drawing.Point(400, 180);
        this.btnZaplac.Name = "btnZaplac";
        this.btnZaplac.Size = new System.Drawing.Size(150, 40);
        this.btnZaplac.TabIndex = 4;
        this.btnZaplac.Text = "Zapłać";
        this.btnZaplac.UseVisualStyleBackColor = true;
        this.btnZaplac.Click += new System.EventHandler(this.btnZaplac_Click);
        
        this.lblCenaCalkowita.AutoSize = true;
        this.lblCenaCalkowita.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblCenaCalkowita.Location = new System.Drawing.Point(20, 230);
        this.lblCenaCalkowita.Name = "lblCenaCalkowita";
        this.lblCenaCalkowita.Size = new System.Drawing.Size(143, 21);
        this.lblCenaCalkowita.TabIndex = 3;
        this.lblCenaCalkowita.Text = "Do zapłaty: 0,00 zł";
        
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(580, 280);
        this.Controls.Add(this.lblCenaCalkowita);
        this.Controls.Add(this.btnZaplac);
        this.Controls.Add(this.btnDodajMonitor);
        this.Controls.Add(this.btnDodajKomputer);
        this.Controls.Add(this.listViewKoszyk);
        this.Name = "Form1";
        this.Text = "Kalkulator Zestawów Komputerowych";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}