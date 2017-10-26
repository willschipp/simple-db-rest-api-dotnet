﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using TodoApi.Models;

namespace TodoApi.Controllers {
    
    [Route("api/[controller]")]
    public class TodoController : Controller {
    
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0) 
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll() 
        {
            return _context.TodoItems.ToList();
        }
    }
}
