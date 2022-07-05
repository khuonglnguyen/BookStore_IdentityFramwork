using BookStore.Data.Entities;
using BookStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApplication.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var listBook = _bookRepository.GetAll();
            return View(listBook);
        }

        [Route("book/{id}")]
        public IActionResult Details(int Id)
        {
            var book = _bookRepository.GetDetails(Id);
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookRepository.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _bookRepository.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
