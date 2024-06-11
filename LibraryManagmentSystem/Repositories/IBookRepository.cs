using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);

        List<Book> GetAllBooks();
        
        Book GetBookById(int id);

        void DeleteBook(Book book);

        void UpdateBook(Book book);
    }
}
