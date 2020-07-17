using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator.Data;
using Communicator.Model.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Communicator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IRepository _repository;

        public TodoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("List")]
        public IEnumerable<TodoDto> GetTodoList()
        {
            return _repository.GetTodoList();
        }

        [HttpGet]
        public TodoDto Get(int id)
        {
            return _repository.GetTodoById(id);
        }
    }
}