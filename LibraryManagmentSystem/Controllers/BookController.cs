using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.Controllers
{
    public class BookController : Controller
    {
        readonly IBookRepository _bookRepository;
        readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public ActionResult AddBook()
        {
            List<Category> categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = categories; 
            Book book = new Book();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(Book book)
        {
            List<Category> categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = categories;

            if (ModelState.IsValid)
            {
                if (book.File != null && book.File.Length > 0)
                {
                    var fileType = Path.GetExtension(book.File.FileName);
                    string fileName = Guid.NewGuid().ToString() + fileType;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await book.File.CopyToAsync(stream);
                    }
                    book.CoverImgPath = "/img/" + fileName;

                    _bookRepository.AddBook(book);
                    return RedirectToAction("BookList");
                }
                else
                {
                    ViewBag.Message = "Lütfen Bir Dosya Seçiniz";
                }
            }
            return View(book);
        }

        public ActionResult BookList()
        {
            List<Category> categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = categories;
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public ActionResult UpdateBook(int id)
        {
            List<Category> categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = categories;
            var exBook = _bookRepository.GetBookById(id);
            if (exBook == null)
            {
                NotFound();
            }
            return View(exBook);
        }

        [HttpPost]

        public ActionResult UpdateBook(Book book)
        {
            List<Category> categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                var existingBook = _bookRepository.GetBookById(book.Id ?? 1);
                if (existingBook == null)
                {
                    return NotFound();
                }

                if (book.File != null && book.File.Length > 0)
                {
                    // Eski dosyayı silme
                    if (!string.IsNullOrEmpty(existingBook.CoverImgPath))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingBook.CoverImgPath.TrimStart('/'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    // Yeni dosyayı kaydetme
                    var fileExtension = Path.GetExtension(book.File.FileName);
                    string fileName = Guid.NewGuid().ToString() + fileExtension;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        book.File.CopyToAsync(stream).Wait(); // .Wait() ekleyerek senkronize hale getiriyoruz
                    }
                    existingBook.CoverImgPath = "/img/" + fileName;
                }
                else
                {
                    existingBook.CoverImgPath = book.CoverImgPath; // Mevcut resmi koruyoruz
                }

                // Diğer alanları güncelleme
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PageCount = book.PageCount;
                existingBook.CategoryId = book.CategoryId;

                _bookRepository.UpdateBook(existingBook);
                return RedirectToAction("BookList");
            }

            return View(book);
        }
        public ActionResult DeleteBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                NotFound();
            }
            _bookRepository.DeleteBook(book);
            return RedirectToAction("BookList");
        }
    }
}
