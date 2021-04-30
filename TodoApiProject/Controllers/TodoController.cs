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


        //[Route("Todo")
        [HttpPost]
        public IActionResult AddTodo([FromForm] TodoAddVM todoAdd) 
        {
            if (ModelState.IsValid)
            {
                Work todo = new Work();
                todo.Name = todoAdd.name;

                _todoContext.Works.Add(todo);
                _todoContext.SaveChanges();

                todoAdd.id = todo.ID;

                return Ok(todoAdd);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }


        //[Route("Todo/Delete")]
        [HttpPost]
        public IActionResult Delete([FromForm] TodoDeleteVM todoDelete)
        {
            Work todo = _todoContext.Works.Find(todoDelete.id);

            if (todo != null)
            {
                todo.IsDeleted = true;
                _todoContext.SaveChanges();

                return Ok(todo);
            }
            else 
            { 
                return BadRequest("There is no any to do has that id!");
            }

        }

        //[Route("Category/update")]
        //[HttpPost]
        //public IActionResult Update([FromForm] TodoUpdateVM categoryvm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Category category = _eCommerceContext.Categories.FirstOrDefault(q => q.ID == categoryvm.id);

        //        if (category != null)
        //        {
        //            category.Name = categoryvm.name;
        //            category.Description = categoryvm.description;

        //            _eCommerceContext.SaveChanges();


        //            return Ok(categoryvm);
        //        }
        //        else
        //        {
        //            return BadRequest("Böyle bir kategori sistemde mevcut değil");
        //        }

        //    }
        //    else
        //    {
        //        return BadRequest(ModelState.Values);
        //    }

        //}

        [HttpPost]
        public IActionResult Update([FromForm] TodoUpdateVM todoUpdate)
        {
            if (ModelState.IsValid)
            {
                Work todo = _todoContext.Works.FirstOrDefault(q => q.ID == todoUpdate.id);

                if (todo != null)
                {
                    todo.Name = todoUpdate.name;
                    todo.UpdateDate = todoUpdate.updateDate;
                 
       

                    _todoContext.SaveChanges();


                    return Ok(todoUpdate);
                }
                else
                {
                    return BadRequest("Böyle bir kategori sistemde mevcut değil");
                }

            }
            else
            {
                return BadRequest(ModelState.Values);
            }

        }

    }
}
