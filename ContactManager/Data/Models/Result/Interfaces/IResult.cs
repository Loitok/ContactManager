using ContactManager.Data.Models.Result.Implementations;

namespace ContactManager.Data.Models.Result.Interfaces
{
    public interface IResult
    {
        bool Success { get; }
        ResponseMessage ErrorMessage { get; }
    }
}
