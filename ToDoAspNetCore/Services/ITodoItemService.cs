using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAspNetCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAspNetCore.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(TodoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}
