using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet("/")]
        // [Route("/")]
        public List<TodoModel> Get(
            [FromServices]AppDbContext context)
        {
            return context.Todos.ToList();
        }

        [HttpGet("/{id:int}")]
        public TodoModel GetById(
            [FromRoute]int id,
            [FromServices]AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/")]
        public TodoModel Post(
            [FromBody]TodoModel model, 
            [FromServices]AppDbContext context)
        {
            context.Todos.Add(model);
            context.SaveChanges();
            return model;
        }

        [HttpPut("/")]
        public TodoModel Put(
            [FromBody] TodoModel model,
            [FromServices]AppDbContext context)
        {
            context.Todos.Update(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("/")]
        public TodoModel Delete(
            [FromBody]TodoModel model,
            [FromServices]AppDbContext context)
        {
            context.Todos.Remove(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("/{id:int}")]
        public TodoModel Delete(
            [FromRoute]int id,
            [FromServices]AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            context.Remove(model);
            context.SaveChanges();

            return model;
        }

        [HttpGet("/home")]
        public IActionResult Home()
        {
            var context = new AppDbContext();
            var model = context.Todos.ToList();
            return View(model);
        }
    }
}