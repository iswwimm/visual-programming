using System;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private decimal _sumaCalkowita = 0m;

    public Form1()
    {
        InitializeComponent();
    }

    private void btnDodajKomputer_Click(object sender, EventArgs e)
    {
        FormKomputer formKomp = new FormKomputer();
        
        if (formKomp.ShowDialog() == DialogResult.OK)
        {
            string nazwa = formKomp.WybranaNazwa;
            decimal cena = formKomp.WybranaCena;
            DodajDoKoszyka(nazwa, cena);
        }
    }

    private void btnDodajMonitor_Click(object sender, EventArgs e)
    {
        FormMonitor formMon = new FormMonitor(this);
        formMon.Show();
    }

    public void DodajDoKoszyka(string nazwaProduktu, decimal cenaProduktu)
    {
        ListViewItem item = new ListViewItem(nazwaProduktu);
        item.SubItems.Add(cenaProduktu.ToString("0.00"));
        listViewKoszyk.Items.Add(item);

        _sumaCalkowita += cenaProduktu;
        lblCenaCalkowita.Text = $"Do zapłaty: {_sumaCalkowita:0.00} zł";
    }
    
    private void btnZaplac_Click(object sender, EventArgs e)
    {
        if (listViewKoszyk.Items.Count == 0)
        {
            MessageBox.Show("Twój koszyk jest pusty. Dodaj produkty przed płatnością!", 
                            "Brak produktów", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
            return;
        }
        
        MessageBox.Show($"Dziękujemy za zakupy!\n\nPobrano z konta: {_sumaCalkowita:0.00} zł", 
                        "Transakcja zakończona sukcesem", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
        
        listViewKoszyk.Items.Clear();
        _sumaCalkowita = 0m;
        lblCenaCalkowita.Text = "Do zapłaty: 0,00 zł";
    }
}