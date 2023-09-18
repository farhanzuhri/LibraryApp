// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
}

class LibraryCatalog
{
    private List<Book> books;

    public LibraryCatalog()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Buku '{book.Title}' ditambahkan ke katalog.");
    }

    public void RemoveBook(Book book)
    {
        if (books.Remove(book))
        {
            Console.WriteLine($"Buku '{book.Title}' dihapus dari katalog.");
        }
        else
        {
            Console.WriteLine($"Buku '{book.Title}' tidak ditemukan dalam katalog.");
        }
    }

    public Book FindBook(string title)
    {
        return books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public void ListBooks()
    {
        Console.WriteLine("Daftar Buku dalam Katalog:");
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Title} oleh {book.Author}, Tahun Terbit: {book.PublicationYear}");
        }
    }
}

class ErrorHandler
{
    public static void HandleError(string message)
    {
        Console.WriteLine($"Error: {message}");
    }
}

class LibraryApp
{
    static void Main()
    {
        LibraryCatalog catalog = new LibraryCatalog();

        while (true)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("Selamat Datang di Aplikasi Perpustakaan");
            Console.WriteLine("=======================================");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Tambahkan Buku");
            Console.WriteLine("2. Hapus Buku");
            Console.WriteLine("3. Cari Buku");
            Console.WriteLine("4. Tampilkan Semua Buku");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih opsi (1/2/3/4/5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddBook(catalog);
                        break;
                    case 2:
                        RemoveBook(catalog);
                        break;
                    case 3:
                        FindBook(catalog);
                        break;
                    case 4:
                        catalog.ListBooks();
                        break;
                    case 5:
                        Console.WriteLine("Terima kasih telah menggunakan aplikasi perpustakaan.");
                        return;
                    default:
                        ErrorHandler.HandleError("Opsi tidak valid.");
                        break;
                }
            }
            else
            {
                ErrorHandler.HandleError("Masukan harus berupa angka.");
            }
        }
    }

    static void AddBook(LibraryCatalog catalog)
    {
        Console.Write("Judul Buku: ");
        string title = Console.ReadLine();
        Console.Write("Penulis: ");
        string author = Console.ReadLine();
        Console.Write("Tahun Terbit: ");
        if (int.TryParse(Console.ReadLine(), out int publicationYear))
        {
            Book book = new Book { Title = title, Author = author, PublicationYear = publicationYear };
            catalog.AddBook(book);
        }
        else
        {
            ErrorHandler.HandleError("Tahun terbit harus berupa angka.");
        }
    }

    static void RemoveBook(LibraryCatalog catalog)
    {
        Console.Write("Masukkan judul buku yang ingin dihapus: ");
        string title = Console.ReadLine();
        Book book = catalog.FindBook(title);
        if (book != null)
        {
            catalog.RemoveBook(book);
        }
        else
        {
            ErrorHandler.HandleError("Buku tidak ditemukan dalam katalog.");
        }
    }

    static void FindBook(LibraryCatalog catalog)
    {
        Console.Write("Masukkan judul buku yang ingin dicari: ");
        string title = Console.ReadLine();
        Book book = catalog.FindBook(title);
        if (book != null)
        {
            Console.WriteLine($"Buku ditemukan: '{book.Title}' oleh {book.Author}, Tahun Terbit: {book.PublicationYear}");
        }
        else
        {
            ErrorHandler.HandleError("Buku tidak ditemukan dalam katalog.");
        }
    }
}

