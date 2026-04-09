using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Serialization;
using AplikacjaPracownicy;

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

        // ==========================================
        //  OBSŁUGA BAZOWA I CSV (Laboratorium 3)
        // ==========================================

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

        // ==========================================
        //  OBSŁUGA XML (Laboratorium 5)
        // ==========================================

        private void ZapiszDoXML(string filePath)
        {
            try
            {
                List<Pracownik> listaDoZapisu = _listaPracownikow.ToList();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pracownik>));
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, listaDoZapisu);
                }
                MessageBox.Show("Pomyślnie zapisano do pliku XML!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisu XML:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonZapiszXML_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Plik XML|*.xml" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ZapiszDoXML(sfd.FileName);
                }
            }
        }

        private void WczytajZXML(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pracownik>));
                using (TextReader reader = new StreamReader(filePath))
                {
                    List<Pracownik> wczytanaLista = (List<Pracownik>)serializer.Deserialize(reader);
                    
                    _listaPracownikow.Clear();
                    foreach (var pracownik in wczytanaLista)
                    {
                        _listaPracownikow.Add(pracownik);
                    }
                }
                MessageBox.Show("Pomyślnie wczytano dane z pliku XML!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas odczytu pliku XML:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWczytajXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Plik XML|*.xml" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    WczytajZXML(ofd.FileName);
                }
            }
        }

        // ==========================================
        //  OBSŁUGA JSON (Laboratorium 5)
        // ==========================================

        private void ZapiszDoJSON(string filePath)
        {
            try
            {
                List<Pracownik> listaDoZapisu = _listaPracownikow.ToList();
                JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(listaDoZapisu, options);
                
                File.WriteAllText(filePath, jsonString);
                
                MessageBox.Show("Pomyślnie zapisano do pliku JSON!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisu JSON:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonZapiszJSON_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Plik JSON|*.json" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ZapiszDoJSON(sfd.FileName);
                }
            }
        }

        private void WczytajZJSON(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                List<Pracownik> wczytanaLista = JsonSerializer.Deserialize<List<Pracownik>>(jsonString);
                
                if (wczytanaLista != null)
                {
                    _listaPracownikow.Clear();
                    foreach (var pracownik in wczytanaLista)
                    {
                        _listaPracownikow.Add(pracownik);
                    }
                }
                MessageBox.Show("Pomyślnie wczytano dane z pliku JSON!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas odczytu pliku JSON:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWczytajJSON_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Plik JSON|*.json" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    WczytajZJSON(ofd.FileName);
                }
            }
        }
    }
}