using Lab9;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class DatabaseManager
{
    private string connectionString = @"Data Source=EgzaminKomisyjny.db;Version=3;";

    public DatabaseManager()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
           string query = @"CREATE TABLE IF NOT EXISTS Wnioski (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Pole1 TEXT, Pole2 TEXT, Pole3 TEXT, Pole4 TEXT, Pole5 TEXT,
                                Pole6 TEXT, Pole7 TEXT, Pole8 TEXT, Pole9 TEXT, Pole10 TEXT,
                                Pole11 TEXT, Pole12 TEXT, Pole13 TEXT, Pole14 TEXT, Pole15 TEXT
                             )";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void WriteData(string[] dane)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            string query = @"INSERT INTO Wnioski (Pole1, Pole2, Pole3, Pole4, Pole5, Pole6, Pole7, Pole8, Pole9, Pole10, Pole11, Pole12, Pole13, Pole14, Pole15) 
                             VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15)";

            SQLiteCommand command = new SQLiteCommand(query, connection);

            for (int i = 0; i < 15; i++)
            {
                command.Parameters.AddWithValue($"@p{i + 1}", dane[i] ?? "");
            }

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public string[] ReadLastData()
    {
        string[] dane = new string[15];
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
           string query = "SELECT * FROM Wnioski ORDER BY Id DESC LIMIT 1";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            try
            {
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < 15; i++)
                    {
                        dane[i] = reader.IsDBNull(i + 1) ? "" : reader.GetString(i + 1);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return dane;
    }
    public List<WniosekItem> GetWnioskiList()
    {
        List<WniosekItem> lista = new List<WniosekItem>();
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            string query = "SELECT Id, Pole2 FROM Wnioski ORDER BY Id DESC";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            try
            {
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nazwisko = reader.IsDBNull(1) ? "Brak nazwiska" : reader.GetString(1);
                    lista.Add(new WniosekItem { Id = id, Opis = nazwisko });
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }
        return lista;
    }

    public string[] ReadDataById(int id)
    {
        string[] dane = new string[15];
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            string query = "SELECT * FROM Wnioski WHERE Id = @Id";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < 15; i++)
                    {
                        dane[i] = reader.IsDBNull(i + 1) ? "" : reader.GetString(i + 1);
                    }
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }
        return dane;
    }
}
public class WniosekItem
{
    public int Id { get; set; }
    public string Opis { get; set; }

    public override string ToString()
    {
        return $"ID: {Id} - {Opis}";
    }
}