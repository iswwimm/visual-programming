using System;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class FormMonitor : Form
{
    private Form1 _mainWindow;
    
    public FormMonitor(Form1 mainWindow)
    {
        InitializeComponent();
        _mainWindow = mainWindow;
        
        listBoxMonitory.Items.Add("Monitor Dell 24 cale (600 zł)");
        listBoxMonitory.Items.Add("Monitor LG 27 cali (850 zł)");
        listBoxMonitory.Items.Add("Monitor Samsung 32 cale Curved (1200 zł)");
        
        listBoxMonitory.SelectedIndex = 0;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        decimal cena = 0m;
        string nazwa = "Monitor: ";
        
        string wybranyMonitor = listBoxMonitory.SelectedItem.ToString();
        
        if (wybranyMonitor.Contains("Dell")) 
        {
            cena += 600m;
            nazwa += "Dell 24\"";
        }
        else if (wybranyMonitor.Contains("LG")) 
        {
            cena += 850m;
            nazwa += "LG 27\"";
        }
        else if (wybranyMonitor.Contains("Samsung")) 
        {
            cena += 1200m;
            nazwa += "Samsung 32\"";
        }
        
        if (cbKabel.Checked)
        {
            cena += 50m;
            nazwa += " + HDMI";
        }
        
        if (cbGwarancja.Checked)
        {
            cena += 150m;
            nazwa += " + Gwarancja";
        }
        
        _mainWindow.DodajDoKoszyka(nazwa, cena);
        
        this.Close();
    }

    private void btnAnuluj_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}