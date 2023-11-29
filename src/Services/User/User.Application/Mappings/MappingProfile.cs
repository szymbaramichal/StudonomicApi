using AutoMapper;
using User.Application.Features.Commands.Labels.CreateLabel;
using User.Application.Features.Commands.Labels.UpdateLabel;
using User.Application.Features.Commands.Todos.CreateTodo;
using User.Application.Features.Commands.Todos.UpdateTodo;
using User.Application.Models.Labels;
using User.Application.Models.Todos;
using User.Domain.Entities;

namespace User.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        TodoProfile();
        LabelProfile();
    }

    protected void TodoProfile()
    {
        CreateMap<Todo, TodoViewModel>();
        CreateMap<CreateTodoCommand, Todo>();
        CreateMap<UpdateTodoCommand, Todo>();
    }

    protected void LabelProfile()
    {
        CreateMap<Label, LabelViewModel>();
        CreateMap<CreateLabelCommand, Label>();
        CreateMap<UpdateLabelCommand, Label>();
    }
}