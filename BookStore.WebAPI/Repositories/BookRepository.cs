﻿using BookStore.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.WebAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private DbCon _context;
        public BookRepository(DbCon context)
        {
            _context = context;

            if (!_context.Books.Any())
            {

                _context.Books.Add(new Book
                {
                    Name = "Tom and Jerry",
                    Price = 123.5,
                    Author = "Unknow",
                    Publisher = "Kim Dong"
                });

                _context.Books.Add(new Book
                {
                    Name = "Steve Job",
                    Price = 200,
                    Author = "Unknow",
                    Publisher = "BBC"
                });

                _context.Books.Add(new Book
                {
                    Name = "Golden Axe",
                    Price = 199,
                    Author = "David Copy and Paste",
                    Publisher = "SEGA"
                });
                _context.SaveChanges();
            }
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var book = _context.Books.Find(Id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetDetails(int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.Id == bookId);
        }
    }
    public interface IBookRepository
    {
        void Add(Book book);
        Book GetDetails(int bookId);
        IEnumerable<Book> GetAll();
        void Delete(int Id);
    }
}
