using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Models.Todos;

namespace User.Application.Features.Queries.GetTodosList;
public class GetTodosListQueryHandler : IRequestHandler<GetTodosListQuery, List<TodoViewModel>>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    
    public GetTodosListQueryHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    public async Task<List<TodoViewModel>> Handle(GetTodosListQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetActiveTodosForDate(request.Date);
        return _mapper.Map<List<TodoViewModel>>(todos);
    }
}