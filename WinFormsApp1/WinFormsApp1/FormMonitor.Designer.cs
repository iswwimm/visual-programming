using System.ComponentModel;

namespace WinFormsApp1;

partial class FormMonitor
{
    private IContainer components = null;

    private System.Windows.Forms.ListBox listBoxMonitory;
    private System.Windows.Forms.CheckBox cbKabel;
    private System.Windows.Forms.CheckBox cbGwarancja;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.Button btnAnuluj;
    private System.Windows.Forms.Label labelInfo;

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
        this.listBoxMonitory = new System.Windows.Forms.ListBox();
        this.cbKabel = new System.Windows.Forms.CheckBox();
        this.cbGwarancja = new System.Windows.Forms.CheckBox();
        this.btnDodaj = new System.Windows.Forms.Button();
        this.btnAnuluj = new System.Windows.Forms.Button();
        this.labelInfo = new System.Windows.Forms.Label();
        this.SuspendLayout();
        
        this.labelInfo.AutoSize = true;
        this.labelInfo.Location = new System.Drawing.Point(20, 15);
        this.labelInfo.Name = "labelInfo";
        this.labelInfo.Text = "Wybierz model monitora:";
        
        this.listBoxMonitory.FormattingEnabled = true;
        this.listBoxMonitory.ItemHeight = 15;
        this.listBoxMonitory.Location = new System.Drawing.Point(20, 35);
        this.listBoxMonitory.Name = "listBoxMonitory";
        this.listBoxMonitory.Size = new System.Drawing.Size(240, 79);
        
        this.cbKabel.AutoSize = true;
        this.cbKabel.Location = new System.Drawing.Point(20, 130);
        this.cbKabel.Name = "cbKabel";
        this.cbKabel.Text = "Dodatkowy kabel HDMI (+50 zł)";
        
        this.cbGwarancja.AutoSize = true;
        this.cbGwarancja.Location = new System.Drawing.Point(20, 160);
        this.cbGwarancja.Name = "cbGwarancja";
        this.cbGwarancja.Text = "Przedłużona gwarancja (+150 zł)";
        
        this.btnDodaj.Location = new System.Drawing.Point(20, 200);
        this.btnDodaj.Name = "btnDodaj";
        this.btnDodaj.Size = new System.Drawing.Size(110, 30);
        this.btnDodaj.Text = "Dodaj do koszyka";
        this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
        
        this.btnAnuluj.Location = new System.Drawing.Point(150, 200);
        this.btnAnuluj.Name = "btnAnuluj";
        this.btnAnuluj.Size = new System.Drawing.Size(110, 30);
        this.btnAnuluj.Text = "Anuluj";
        this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click);
        
        this.ClientSize = new System.Drawing.Size(284, 251);
        this.Controls.Add(this.labelInfo);
        this.Controls.Add(this.btnAnuluj);
        this.Controls.Add(this.btnDodaj);
        this.Controls.Add(this.cbGwarancja);
        this.Controls.Add(this.cbKabel);
        this.Controls.Add(this.listBoxMonitory);
        this.Name = "FormMonitor";
        this.Text = "Wybór Monitora";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}