using Communicator.Model.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Communicator.Data
{
    public interface IRepository
    {
        IEnumerable<TodoDto> GetTodoList();
        TodoDto GetTodoById(int id);
    }
    public class Repository : IRepository
    {
        public IEnumerable<TodoDto> GetTodoList()
        {
            return new List<TodoDto>
            {
                new TodoDto
                {
                    Id = 1,
                    Subject = "Learn ReactJs",
                    Status = "In progress => 10%"
                },
                new TodoDto
                {
                    Id = 2,
                    Subject = "Learn Identity Server",
                    Status = "In progress => 15%"
                },
            };
        }

        public TodoDto GetTodoById(int id)
        {
            return GetTodoList().ToList().SingleOrDefault(t => t.Id == id);
        }
    }
}
