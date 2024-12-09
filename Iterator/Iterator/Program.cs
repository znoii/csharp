using System;
using System.Collections;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, published in {Year}";
    }
}
interface IEnumerable
{
    IEnumerator GetEnumerator();
}
class Library : IEnumerable
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }
    public IEnumerator GetEnumerator()
    {
        return new LibraryIterator(this);
    }

    public Book this[int index]
    {
        get { return books[index]; }
        set { books.Insert(index, value); }
    }

    public int Count => books.Count;
}
interface IEnumerator
{
    bool MoveNext();
    void Reset();
    object Current { get; }
}

class LibraryIterator : IEnumerator
{
    private Library _library;
    private int _currentIndex = -1;

    public LibraryIterator(Library library)
    {
        _library = library;
    }

    public bool MoveNext()
    {
        if (_currentIndex < _library.Count - 1)
        {
            _currentIndex++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
    public object Current => _library[_currentIndex];
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        library.AddBook(new Book("Чайные дракончики", "Кэти О’Нилл", 1960));
        library.AddBook(new Book("Дивный новый мир", "Хаксли", 1932));

        IEnumerator libraryIterator = library.GetEnumerator();

        while (libraryIterator.MoveNext())
        {
            Book book = libraryIterator.Current as Book;
            Console.WriteLine(book); 
        }
    }
}
