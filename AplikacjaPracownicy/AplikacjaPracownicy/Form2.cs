using System;
using System;
using System.Windows.Forms;

namespace AplikacjaPracownicy
{
    public partial class Form2 : Form
    {
        public Pracownik NowyPracownik { get; private set; }

        public Form2()
        {
            InitializeComponent();
            comboBoxStanowisko.Items.AddRange(new string[] { "Programista", "Księgowy", "Dyrektor" });
            comboBoxStanowisko.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxWiek.Text, out int wiek))
            {
                MessageBox.Show("Wiek musi być poprawną liczbą całkowitą.");
                return;
            }

            if (comboBoxStanowisko.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać stanowisko.");
                return;
            }

            NowyPracownik = new Pracownik()
            {
                Imie = textBoxImie.Text,
                Nazwisko = textBoxNazwisko.Text,
                Wiek = wiek,
                Stanowisko = comboBoxStanowisko.SelectedItem.ToString()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}