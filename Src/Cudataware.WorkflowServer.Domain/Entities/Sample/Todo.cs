using Cudataware.WorkflowServer.Domain.Common;
using System.Collections.Generic;

namespace Cudataware.WorkflowServer.Domain.Entities.Sample
{
    public class Todo : BaseEntity
    {
        public string Name { set; get; }        
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
