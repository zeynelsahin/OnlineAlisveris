using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete;

public class CartManager : ICartService
{
    private ICartDal _cartDal;


    public CartManager(ICartDal cartDal)
    {
        _cartDal = cartDal;
    }

    public async Task<IResult> GetById(int id)
    {
        var result =  await _cartDal.GetAsync(cart => cart.Id == id);
        if (result != null)
            return new SuccessResult();
        return new ErrorResult(Messages.CartNotFound);
    }
}