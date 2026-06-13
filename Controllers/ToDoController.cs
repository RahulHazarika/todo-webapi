using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoservices todoservices;
        public ToDoController(ITodoservices todoservices)
        {
            this.todoservices = todoservices;
        }

        [HttpGet]
        public ActionResult<List<TodoModel>> GetAll()
        {
            var todos = todoservices.GetToDoList();
            return Ok(todos);
        }

        [HttpPost]
        public ActionResult AddNewToDo([FromBody] RequestBody todo)
        {
            string sError = "";
            try
            {
                if (todo != null)
                {
                    if (todoservices.AddNewToDo(todo.Title, ref sError))
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("AddNewToDo Error: " + sError);
                    }
                }
                else
                {
                    return BadRequest("AddNewToDo Error: Body is Null");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("AddNewToDo Error: " + ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateToDo(string id,[FromBody] TodoModel todo)
        {
            string sError = "";
            try
            {
                if (todo != null)
                {
                    if (id != todo.Id.ToString())
                    {
                        return BadRequest("UpdateToDo Error: Id Mis-match");
                    }
                    else
                    {
                        if (todoservices.UpdateToDo(todo,ref sError))
                        {
                            return NoContent();
                        }
                        else
                        {
                            return BadRequest($"UpdateToDo Error: {sError}");
                        }
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("UpdateToDo Error: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteToDO(string id)
        {
            string sError = "";
            try
            {              
                if (todoservices.DeleteToDo(id))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("DeleteToDO Error: Nothing to Update");
                }
                            
            }
            catch (Exception ex)
            {
                return BadRequest("DeleteToDO Error: " + ex.Message);
            }
        }


    }
}
