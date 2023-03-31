using ContactManager.Data.Models.Result.Interfaces;

namespace ContactManager.Data.Models.Result.Generics
{
    public interface IResult<out TData> : IResult
    {
        TData Data { get; }
    }
}
