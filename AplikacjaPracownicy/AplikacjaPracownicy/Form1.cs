using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AplikacjaPracownicy
{
    public partial class Form1 : Form
    {
        private BindingList<Pracownik> _listaPracownikow;

        public Form1()
        {
            InitializeComponent();
            _listaPracownikow = new BindingList<Pracownik>();
            dataGridView1.DataSource = _listaPracownikow;
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            using (Form2 formDodaj = new Form2())
            {
                if (formDodaj.ShowDialog() == DialogResult.OK)
                {
                    _listaPracownikow.Add(formDodaj.NowyPracownik);
                }
            }
        }

        private void buttonUsun_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var indeks = dataGridView1.SelectedRows[0].Index;
                _listaPracownikow.RemoveAt(indeks);
            }
            else
            {
                MessageBox.Show("Zaznacz cały wiersz do usunięcia (klikając na margines z lewej strony).");
            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Plik CSV|*.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var linie = _listaPracownikow.Select(p => $"{p.Id},{p.Imie},{p.Nazwisko},{p.Wiek},{p.Stanowisko}");
                    File.WriteAllLines(sfd.FileName, linie);
                    MessageBox.Show("Zapisano pomyślnie!");
                }
            }
        }

        private void buttonWczytaj_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Plik CSV|*.csv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _listaPracownikow.Clear();
                    var linie = File.ReadAllLines(ofd.FileName);
                    foreach (var linia in linie)
                    {
                        var dane = linia.Split(',');
                        if (dane.Length == 5)
                        {
                            var pracownik = new Pracownik(
                                int.Parse(dane[0]), dane[1], dane[2], int.Parse(dane[3]), dane[4]
                            );
                            _listaPracownikow.Add(pracownik);
                        }
                    }
                }
            }
        }
    }
}