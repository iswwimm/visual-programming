using System;

namespace AplikacjaPracownicy
{
    [Serializable]
    public class Pracownik
    {
        private static int _nastepneId = 1;

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string Stanowisko { get; set; }

        public Pracownik()
        {
            Id = _nastepneId++;
        }

        public Pracownik(int id, string imie, string nazwisko, int wiek, string stanowisko)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Stanowisko = stanowisko;
            
            if (id >= _nastepneId) _nastepneId = id + 1;
        }
    }
}