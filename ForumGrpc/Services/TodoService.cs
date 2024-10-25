using Grpc.Core;

namespace ForumGrpc.Services;

public class TodoService: Todo.TodoBase
{
    
    // add db context
    public TodoService()
    {
        
    }

    public override async Task<CreateTodoResponse> CreateTodo(CreateTodoRequest request, ServerCallContext context)
    {
        if (request.Title == string.Empty || request.Description == string.Empty)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "you must filll a valid object"));
        }

        var todoItem = new Model.Todo
        {
            Title = request.Title,
            Description = request.Description
        };
        
        //TODO: ADD TO DB

        return await Task.FromResult(new CreateTodoResponse
        {
            Id = 1
        });
        
    }

    public override async Task<ReadTodoResponse> ReadTodo(ReadTodoRequest request, ServerCallContext context)
    {
        if (request.Id == 0)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "resource index must be greater than 0"));
        }
        
        var todoItem = new Model.Todo
        {
            Id = 1,
            Title = "test",
            Description = "test description"
        };

        return new ReadTodoResponse
        {
            Id = todoItem.Id,
            Description = todoItem.Description,
            Title = todoItem.Title,
            ToDoStatus = todoItem.Status
        };
    }
}