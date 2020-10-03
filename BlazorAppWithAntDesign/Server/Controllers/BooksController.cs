﻿using System.Collections.Generic;
using System.Linq;
using BlazorAppWithAntDesign.Server.Data;
using BlazorAppWithAntDesign.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWithAntDesign.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext context;

        public BooksController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> List()
        {
            var books = context.Books;
            return books;
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = context.Books.SingleOrDefault(b => b.BookId.Equals(id));
            return book;
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = book.BookId }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = context.Books.SingleOrDefault(b => b.BookId.Equals(id));
            context.Books.Remove(book);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }
    }
}
