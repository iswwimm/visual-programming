using System.ComponentModel;

namespace WinFormsApp1;

partial class FormKomputer
{
    private IContainer components = null;
    
    private System.Windows.Forms.ComboBox comboBoxProcesor;
    private System.Windows.Forms.GroupBox groupBoxDysk;
    private System.Windows.Forms.RadioButton rbSSD;
    private System.Windows.Forms.RadioButton rbHDD;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnAnuluj;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    
    private void InitializeComponent()
    {
        comboBoxProcesor = new System.Windows.Forms.ComboBox();
        groupBoxDysk = new System.Windows.Forms.GroupBox();
        rbHDD = new System.Windows.Forms.RadioButton();
        rbSSD = new System.Windows.Forms.RadioButton();
        btnOK = new System.Windows.Forms.Button();
        btnAnuluj = new System.Windows.Forms.Button();
        groupBoxDysk.SuspendLayout();
        SuspendLayout();
        comboBoxProcesor.FormattingEnabled = true;
        comboBoxProcesor.Location = new System.Drawing.Point(30, 30);
        comboBoxProcesor.Name = "comboBoxProcesor";
        comboBoxProcesor.Size = new System.Drawing.Size(200, 28);
        comboBoxProcesor.TabIndex = 3;
        groupBoxDysk.Controls.Add(rbHDD);
        groupBoxDysk.Controls.Add(rbSSD);
        groupBoxDysk.Location = new System.Drawing.Point(30, 80);
        groupBoxDysk.Name = "groupBoxDysk";
        groupBoxDysk.Size = new System.Drawing.Size(200, 100);
        groupBoxDysk.TabIndex = 2;
        groupBoxDysk.TabStop = false;
        groupBoxDysk.Text = "Wybór dysku";
        rbHDD.AutoSize = true;
        rbHDD.Location = new System.Drawing.Point(20, 60);
        rbHDD.Name = "rbHDD";
        rbHDD.Size = new System.Drawing.Size(123, 24);
        rbHDD.TabIndex = 0;
        rbHDD.Text = "1000 GB SATA";
        rbHDD.CheckedChanged += rbHDD_CheckedChanged;
        rbSSD.AutoSize = true;
        rbSSD.Checked = true;
        rbSSD.Location = new System.Drawing.Point(20, 30);
        rbSSD.Name = "rbSSD";
        rbSSD.Size = new System.Drawing.Size(108, 24);
        rbSSD.TabIndex = 1;
        rbSSD.TabStop = true;
        rbSSD.Text = "240 GB SSD";

        btnOK.Location = new System.Drawing.Point(30, 200);
        btnOK.Name = "btnOK";
        btnOK.Size = new System.Drawing.Size(90, 30);
        btnOK.TabIndex = 1;
        btnOK.Text = "OK";
        btnOK.Click += btnOK_Click;

        btnAnuluj.Location = new System.Drawing.Point(140, 200);
        btnAnuluj.Name = "btnAnuluj";
        btnAnuluj.Size = new System.Drawing.Size(90, 30);
        btnAnuluj.TabIndex = 0;
        btnAnuluj.Text = "Anuluj";
        btnAnuluj.Click += btnAnuluj_Click;

        ClientSize = new System.Drawing.Size(271, 264);
        Controls.Add(btnAnuluj);
        Controls.Add(btnOK);
        Controls.Add(groupBoxDysk);
        Controls.Add(comboBoxProcesor);
        Text = "Konfigurator PC";
        groupBoxDysk.ResumeLayout(false);
        groupBoxDysk.PerformLayout();
        ResumeLayout(false);
    }
    #endregion
}