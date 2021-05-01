using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApiProject.Models.Context;
using TodoApiProject.Models.Entities;
using TodoApiProject.Models.VM;

namespace TodoApiProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _todoContext;
        public TodoController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }



      
        [HttpGet]
        public IActionResult GetTodos()
        {
            List<TodoListVM> todos = _todoContext.Works.Where(q => q.IsDeleted == false).Select(q => new TodoListVM()
            {
                id = q.ID,
                name = q.Name,
                addDate = q.AddDate,
                updateDate = q.UpdateDate
            }).ToList();
            return Ok(todos);
        }


   
        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoAddVM obj) 
        {
            if (ModelState.IsValid)
            {
                Work todo = new Work();
                todo.Name = obj.name;

                _todoContext.Works.Add(todo);
                _todoContext.SaveChanges();

                obj.id = todo.ID;

                return Ok(obj);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }


       
        [HttpPost]
        public IActionResult Delete([FromForm] TodoDeleteVM todoDelete)
        {
            Work todo = _todoContext.Works.Find(todoDelete.id);

            if (todo != null)
            {
                todo.IsDeleted = true;
                _todoContext.SaveChanges();

                return Ok("Person added successfully!");
            }
            else 
            { 
                return BadRequest("There is no any todo has that id!");
            }

        }

        
        [HttpPost]
        public IActionResult Update([FromBody] TodoUpdateVM obj)
        {
            if (ModelState.IsValid)
            {
                Work todo = _todoContext.Works.FirstOrDefault(q => q.ID == obj.id);

                if (todo != null)
                {
                    todo.ID = obj.id;
                    todo.Name = obj.name;
                    todo.UpdateDate = obj.updateDate;
                 

                    _todoContext.SaveChanges();


                    return Ok(obj);
                }
                else
                {
                    return BadRequest("There is no any todo has that id!");
                }

            }
            else
            {
                return BadRequest(ModelState.Values);
            }

        }

    }
}
