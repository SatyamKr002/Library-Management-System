using System;
using System.Threading;
using System.Collections.Generic;
namespace LibraryMangementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Member m1 = new Member("Satyam", 101);
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                int val;
                Console.WriteLine("Welcome To Library Management System");
                Console.WriteLine("***************************************");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Show All Books");
                Console.WriteLine("5. Show Member Info");
                Console.WriteLine("6. Exit");

                val = Convert.ToInt32(Console.ReadLine());

                // Console.WriteLine(val);

                switch (val)
                {
                    case 1:
                        Console.Clear();
                        addBook(books);
                        Thread.Sleep(3000);
                        break;
                    case 2:
                        Console.Clear();
                        BorrowBook(books, m1);
                        Thread.Sleep(4000);
                        break;
                    case 3:
                        Console.Clear();
                        ReturnBook(books, m1);
                        Thread.Sleep(3000);
                        break;
                    case 4:
                        Console.Clear();
                        showAllBooks(books);
                        Thread.Sleep(5000);
                        break;
                    case 5:
                        Console.Clear();
                        m1.MemberInfo();
                        Thread.Sleep(5000);
                        break;
                    case 6:
                        Console.Clear();
                        exit = true;
                        Console.WriteLine("Good Luck!");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You entered Wrong Input.");
                        exit = true;
                        Thread.Sleep(2000);
                        break;
                }
                // Console.ReadKey();
            }
        }
        public static void addBook(List<Book> books)
        {
            string Title, Author;
            int ISBN, CopiesAvailable;

            Console.WriteLine("Enter the Title of The Book: ");
            Title = Console.ReadLine();

            Console.WriteLine("Enter the Author Name of The Book: ");
            Author = Console.ReadLine();

            Console.WriteLine("Isbn Number: ");
            ISBN = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Number of Copies Available: ");
            CopiesAvailable = Convert.ToInt32(Console.ReadLine());

            Book b = new Book();
            b.setTitle(Title);
            b.setAuthor(Author);
            b.setISBN(ISBN);
            b.setCopiesAvailable(CopiesAvailable);

            books.Add(b);

            Console.WriteLine($"\n[ Title: \"{Title}\" | Author: \"{Author}\" | ISBN: #{ISBN} | Copies: {CopiesAvailable} ]");

            Console.WriteLine("Book added Succesfully!!\n");
        }
        public static void showAllBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No Books Avialable");
            }
            else
            {
                foreach (Book b in books)
                {
                    Console.WriteLine($"[ Title: \"{b.getTitle()}\" | Author: \"{b.getAuthor()}\" | ISBN: #{b.getISBN()} | Copies: {b.getCopiesAvailable()} ]");
                }
                Console.WriteLine("\n");
            }
        }
        public static void BorrowBook(List<Book> books, Member m)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available to borrow.");
                return;
            }

            int i = 1;
            Console.WriteLine("Which book You want To Borrow: ");
            foreach (Book b in books)
            {
                Console.WriteLine($"{i++}: {b.getTitle()} (Available: {b.getCopiesAvailable()})");
            }

            int val = Convert.ToInt32(Console.ReadLine()) - 1;

            if (val >= 0 && val < books.Count && books[val].getCopiesAvailable() > 0)
            {
                books[val].isBorrowed();
                m.Borrowed(books[val]);

                Console.WriteLine("\n==============================================");
                Console.WriteLine("Congratulations!");
                Console.WriteLine($"You have successfully borrowed: \"{books[val].getTitle()}\"");
                Console.WriteLine("Happy Reading! Enjoy your book!");
                Console.WriteLine("==============================================\n");
            }
            else
            {
                Console.WriteLine("Invalid selection or book not available.");
            }
        }
        public static void ReturnBook(List<Book> books, Member m)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available to return.");
                return;
            }

            int i = 1;
            Console.WriteLine("Which book do you want to return:");
            foreach (Book b in books)
            {
                Console.WriteLine($"{i++}: {b.getTitle()}");
            }

            int val = Convert.ToInt32(Console.ReadLine()) - 1;

            if (val >= 0 && val < books.Count)
            {
                Book selectedBook = books[val];
                if (m.HasBorrowed(selectedBook.getTitle()))
                {
                    selectedBook.isReturned();
                    m.Returned(selectedBook);

                    Console.WriteLine("\nBook returned successfully!");
                    Console.WriteLine($"Title: \"{books[val].getTitle()}\"");
                    Console.WriteLine("Thank you for returning the book!\n");
                }
                else
                {
                    Console.WriteLine("\nYou cannot return a book you haven't borrowed!\n");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid selection.\n");
            }
        }
    }
    class Book
    {
        string Title, Author;
        public int ISBN, CopiesAvailable;

        public Book()
        {
            Title = "";
            Author = "";
            ISBN = 0;
            CopiesAvailable = 0;
        }

        public void setTitle(string Title)
        {
            this.Title = Title;
        }
        public void setAuthor(string Author)
        {
            this.Author = Author;
        }
        public void setISBN(int ISBN)
        {
            this.ISBN = ISBN;
        }
        public void setCopiesAvailable(int CopiesAvailable)
        {
            this.CopiesAvailable = CopiesAvailable;
        }

        public string getTitle()
        {
            return Title;
        }
        public string getAuthor()
        {
            return Author;
        }
        public int getISBN()
        {
            return ISBN;
        }
        public int getCopiesAvailable()
        {
            return CopiesAvailable;
        }
        public void isBorrowed()
        {
            CopiesAvailable--;
        }
        public void isReturned()
        {
            CopiesAvailable++;
        }
    }
    class Member
    {
        string Name;
        int MemberID, BooksBorrowCount;
        List<string> bookBorrowed = new List<string>();

        public Member(string Name, int MemberID)
        {
            this.Name = Name;
            this.MemberID = MemberID;
        }

        public bool HasBorrowed(string Title)
        {
            return bookBorrowed.Contains(Title);
        }
        public void Borrowed(Book b)
        {
            bookBorrowed.Add(b.getTitle());
        }
        public void Returned(Book b)
        {
            bookBorrowed.Remove(b.getTitle());
        }
        public void MemberInfo()
        {
            Console.WriteLine("\nMember Information");
            Console.WriteLine("********************");
            Console.WriteLine($"Name       : {Name}");
            Console.WriteLine($"MemberID   : {MemberID}");
            Console.WriteLine($"Books Borrowed: {bookBorrowed.Count}\n");
            Console.WriteLine("Borrowed Books: " + string.Join(", ", bookBorrowed) + "\n");
        }
    }

}

