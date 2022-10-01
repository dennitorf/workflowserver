using AutoMapper;

namespace Cudataware.WorkflowServer.Application.Common.Interfaces.Mappings
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
