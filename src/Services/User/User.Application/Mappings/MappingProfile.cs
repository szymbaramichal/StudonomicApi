using AutoMapper;
using User.Application.Features.Commands.Todos.CreateTodo;
using User.Application.Features.Commands.Todos.UpdateTodo;
using User.Application.Models.Todos;
using User.Domain.Entities;

namespace User.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoViewModel>();
        CreateMap<CreateTodoCommand, Todo>();
        CreateMap<UpdateTodoCommand, Todo>();
    }
}