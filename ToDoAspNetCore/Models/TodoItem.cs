﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAspNetCore.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public bool IsDone { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }
    }
}
