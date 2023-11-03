using AutoMapper;
using User.Application.Features.Commands.CreateTodo;
using User.Application.Features.Commands.UpdateTodo;
using User.Application.Models.Todos;
using User.Domain.Common;

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