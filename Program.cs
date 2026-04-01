// See https://aka.ms/new-console-template for more information


using System;
using System.Net;

List<string> Listtask = new List<string>();

while (true)
{
    Console.WriteLine("Selamat datang ka To-Do List");
    Console.WriteLine("1. Tambah tugas");
    Console.WriteLine("2. Lihat tugas");
    Console.WriteLine("3. Hapus tugas");
    Console.WriteLine("4. Exit");
    string input = Console.ReadLine();

    if (input == "1")
    {

        Console.WriteLine("Masukkan tugas yang ingin ditambahkan: ");
        string newTask = Console.ReadLine();
        Listtask.Add(newTask);
    }

    else if (input == "2")
    {

        if (Listtask.Count == 0)
        {
            Console.WriteLine("Tidak ada tugas yang tersedia.");

        }

        else
        {
            Console.WriteLine("\nTugas Anda: ");
            for (int i = 0; i < Listtask.Count; i++)
            {
                Console.WriteLine((i + 1) + "." + (Listtask[i]));
            }
        }
    }

    else if (input == "3")
    {
   
        if (Listtask.Count == 0)
        {
            Console.WriteLine("Tidak ada tugas yang tersedia.");

        }

        else
        {
            Console.WriteLine("\nTugas Anda: ");
            for (int i = 0; i < Listtask.Count; i++)
            {
                Console.WriteLine((i + 1) + "." + (Listtask[i]));
            }
            Console.WriteLine("Masukkan nomor tugas yang ingin dihapus: "); 
            string delete = Console.ReadLine();
            int intdelete = int.Parse(delete);
            int index = intdelete - 1;
            if (index >= 0 && index < Listtask.Count)
            {
                Listtask.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Nombor tidak sah");
            }


        }

    }

    else if (input == "4")
    {
        break;
    }
    

}