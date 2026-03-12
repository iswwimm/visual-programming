using System;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class FormKomputer : Form
{
    public string WybranaNazwa { get; private set; }
    public decimal WybranaCena { get; private set; }

    public FormKomputer()
    {
        InitializeComponent();
        
        comboBoxProcesor.Items.Add("Intel Core i5");
        comboBoxProcesor.Items.Add("AMD Ryzen 5");
        comboBoxProcesor.Items.Add("Intel Core i7");
        comboBoxProcesor.SelectedIndex = 0;
    }
    
    private void btnOK_Click(object sender, EventArgs e)
    {
        decimal cena = 0m;
        string procesor = comboBoxProcesor.SelectedItem.ToString();
        
        if (procesor == "Intel Core i5") cena += 800m;
        else if (procesor == "AMD Ryzen 5") cena += 750m;
        else if (procesor == "Intel Core i7") cena += 1200m;
        
        string dysk = "";
        if (rbSSD.Checked)
        {
            dysk = "240 GB SSD";
            cena += 150m;
        }
        else if (rbHDD.Checked)
        {
            dysk = "1000 GB SATA";
            cena += 220m;
        }
        
        WybranaNazwa = $"PC: {procesor} + {dysk}";
        WybranaCena = cena;
        
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnAnuluj_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void rbHDD_CheckedChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}