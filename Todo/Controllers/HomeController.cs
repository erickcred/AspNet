using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controller
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/Home")]
        // [Route("/")]
        public List<TodoModel> Get([FromServices]AppDbContext context)
        {
            return context.Todos.ToList();
        }

        [HttpGet("/Home/{id:int}")]
        public TodoModel GetById(
            [FromRoute]int id,
            [FromServices]AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/Home")]
        public TodoModel Post(
            [FromBody]TodoModel model, 
            [FromServices]AppDbContext context)
        {
            context.Todos.Add(model);
            context.SaveChanges();
            return model;
        }

        [HttpPut("/Home")]
        public TodoModel Put(
            [FromBody] TodoModel model,
            [FromServices]AppDbContext context)
        {
            context.Todos.Update(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("/Home")]
        public TodoModel Delete(
            [FromBody]TodoModel model,
            [FromServices]AppDbContext context)
        {
            context.Todos.Remove(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("/Home/{id:int}")]
        public TodoModel Delete(
            [FromRoute]int id,
            [FromServices]AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            context.Remove(model);

            return model;
        }

    }
}