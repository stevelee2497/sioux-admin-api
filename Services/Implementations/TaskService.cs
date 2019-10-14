using DAL.Models;
using Services.Abstractions;

namespace Services.Implementations
{
    public class TaskService : EntityService<Task>, ITaskService
    {
    }
}