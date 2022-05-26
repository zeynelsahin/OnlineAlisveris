using Core.Utilities.Results;
using Entities;

namespace Business.Abstract;

public interface ICartService
{
    Task<IResult> GetById(int id);
}