var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var tasks = new List<TodoTask>
{
    new TodoTask { Id = 1, Title = "Сделать домашнее задание", IsCompleted = false },
    new TodoTask { Id = 2, Title = "Купить продукты", IsCompleted = true },
    new TodoTask { Id = 3, Title = "Позвонить другу", IsCompleted = false },
};
var commonId = 3;

app.MapGet("/tasks", (bool? completed) =>
{
    var result = completed is null ? tasks : tasks.Where(t => t.IsCompleted == completed);
    return Results.Ok(result);
});

app.MapGet("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    return task is null ? Results.NotFound() : Results.Ok(task);
});

app.MapPost("/tasks", (TodoTaskDto taskDto) =>
{
    if (string.IsNullOrWhiteSpace(taskDto.Title))
        return Results.BadRequest("Title is empty or have to be filled.");
    
    var newTask = new TodoTask
    {
        Id = ++commonId,
        Title = taskDto.Title,
        IsCompleted = taskDto.IsCompleted,
    };
    tasks.Add(newTask);
    return Results.Created($"/tasks/{newTask.Id}", newTask);
});

app.MapPut("/tasks/{id}", (int id, TodoTaskDto newTaskDto) =>
{
    if (string.IsNullOrWhiteSpace(newTaskDto.Title))
        return Results.BadRequest("Title is empty or have to be filled.");
    
    var updateTask = tasks.FirstOrDefault(t => t.Id == id);
    
    if(updateTask is null) return Results.NotFound();
    
    updateTask.Title = newTaskDto.Title;
    updateTask.IsCompleted = newTaskDto.IsCompleted;
    return Results.Ok(updateTask);
});


app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task is null)
        return Results.NotFound();
    tasks.Remove(task);
    return Results.NoContent();
});



app.Run();