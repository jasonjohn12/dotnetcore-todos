﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Controllers
{
    [Route("api/todos")]
    public class TodosController : Controller
    {
        [HttpGet()]
        public IActionResult GetTodos()
        {
            return Ok(TodosDataStore.Current.Todos);
        }
        /// <summary>
        /// Retrieve a single Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            var todo = TodosDataStore.Current.Todos.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                return NotFound("Todo not found");
            }

            return Ok(todo);
        }
    }
}
