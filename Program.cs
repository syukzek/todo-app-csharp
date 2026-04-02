// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.Data.SqlClient;

string connectionString = "Server=DESKTOP-D2LNFJV\\SQLEXPRESS;Database=TodoDB;Trusted_Connection=True;";


while (true)
{
    Console.WriteLine("Selamat datang ka To-Do List");
    Console.WriteLine("1. Tambah tugas");
    Console.WriteLine("2. Lihat tugas");
    Console.WriteLine("3. Hapus tugas");
    Console.WriteLine("4. Update tugas");
    Console.WriteLine("5. Exit");
    string input = Console.ReadLine();

    if (input == "1")
    {

        Console.WriteLine("Masukkan tugas yang ingin ditambahkan: ");
        string newTask = Console.ReadLine();
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string query = "INSERT INTO Tasks (TaskName) VALUES (@task)";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@task", newTask);

        cmd.ExecuteNonQuery();
        
    }

    else if (input == "2")
    {
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string query = "SELECT * FROM Tasks";
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nTugas Anda: ");

        while (reader.Read())
        {
            Console.WriteLine(reader["Id"] + ". " + reader["TaskName"]);
        }
        reader.Close();
        
    }

    else if (input == "3")
    {
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        // display task dulu
        string selectQuery = "SELECT * FROM Tasks";
        SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
        SqlDataReader reader = selectCmd.ExecuteReader();

        Console.WriteLine("\nTugas Anda: ");

        if (!reader.HasRows)
        {
            Console.WriteLine("Tidak ada tugas yang tersedia.");
            reader.Close();
            

        }
        else
        {
            while (reader.Read())
            {
                Console.WriteLine(reader["Id"] + ". " + reader["TaskName"]);
            }

            reader.Close(); // penting ✅

            Console.WriteLine("Masukkan ID tugas yang ingin dihapus: ");
            int id = int.Parse(Console.ReadLine());

            string deleteQuery = "DELETE FROM Tasks WHERE Id = @id";
            SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
            deleteCmd.Parameters.AddWithValue("@id", id);

            deleteCmd.ExecuteNonQuery();

            Console.WriteLine("Tugas berjaya dihapus!");

           
        }
    }

    else if (input == "4")
    {
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        // display task dulu
        string selectQuery = "SELECT * FROM Tasks";
        SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
        SqlDataReader reader = selectCmd.ExecuteReader();

        Console.WriteLine("\nTugas Anda: ");

        if (!reader.HasRows)
        {
            Console.WriteLine("Tidak ada tugas.");
            
        }
        else
        {
            while (reader.Read())
            {
                Console.WriteLine(reader["Id"] + ". " + reader["TaskName"]);
            }

            reader.Close();

            Console.WriteLine("Masukkan ID tugas yang ingin diupdate: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Masukkan task baru: ");
            string newTask = Console.ReadLine();

            string updateQuery = "UPDATE Tasks SET TaskName = @task WHERE Id = @id";
            SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
            updateCmd.Parameters.AddWithValue("@task", newTask);
            updateCmd.Parameters.AddWithValue("@id", id);

            updateCmd.ExecuteNonQuery();

            Console.WriteLine("Tugas berjaya diupdate!");

        }
    }

    else if (input == "5")
    {
        break;
    }
    

}