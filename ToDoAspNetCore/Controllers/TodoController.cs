﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAspNetCore.Models;
using ToDoAspNetCore.Services;

namespace ToDoAspNetCore.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            // Get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // Put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };

            // Pass the view to a model and render
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var success = await _todoItemService.AddItemAsync(newItem);
            if (!success)
            {
                return BadRequest("Could not add item to list.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                RedirectToAction("Index");
            }

            var success = await _todoItemService.MarkDoneAsync(id);
            if (!success)
            {
                return BadRequest("Could not mark item as complete");
            }

            return RedirectToAction("Index");
        }

    }
}