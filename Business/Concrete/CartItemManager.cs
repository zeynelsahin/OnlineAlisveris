using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;

namespace Business.Concrete;

public class CartItemManager : ICartItemService
{
    private readonly ICartItemDal _cartItemDal;
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public CartItemManager(ICartItemDal cartItemDal, IProductService productService, ICartService cartService)
    {
        _cartItemDal = cartItemDal;
        _productService = productService;
        _cartService = cartService;
    }
    
    public async Task<IDataResult<CartItem>> GetByIdAsync(int id)
    {
        var cartItem = await _cartItemDal.GetByIdAsync(id);
        return new SuccessDataResult<CartItem>(cartItem);
    }

    public async Task<IDataResult<IEnumerable<CartItem>>> GetAllByUserIdAsync(int userId)
    {
        var cartItems = await _cartItemDal.GetAllByUserIdAsync(userId);
        return new SuccessDataResult<IEnumerable<CartItem>>(cartItems);
    }

    public async Task<IDataResult<IEnumerable<CartItemDto>>> GetCartItemProductsAsync()
    {
        var cartItemDto = await _cartItemDal.GetCartItemProductsAsync();
        return new SuccessDataResult<IEnumerable<CartItemDto>>(cartItemDto,Messages.CartItemListed);
    }

    public async Task<IDataResult<IEnumerable<CartItemDto>>> GetCartItemProductsByCartIdAsync(int cartId)
    {
        var cartItemDto = await _cartItemDal.GetCartItemProductsByCartIdAsync(cartId);
        return new SuccessDataResult<IEnumerable<CartItemDto>>(cartItemDto,Messages.CartItemListed);
    }

    public async Task<IDataResult<IEnumerable<CartItemDto>>> GetCartItemProductsByUserIdAsync(int userId)
    {
        var cartItemDto = await _cartItemDal.GetCartItemProductByUserIdAsync(userId);
        return new SuccessDataResult<IEnumerable<CartItemDto>>(cartItemDto,Messages.CartItemListed);
    }


    public async Task<IResult> AddItem(CartItemToAddDto cartItemToAddDto)
    {
       var result = await BusinessRules.Run(await CheckIfCartIdCorrectToCartItemAdd(cartItemToAddDto),await CheckIfCartItemExists(cartItemToAddDto.CartId,cartItemToAddDto.ProductId),await CheckIfProductCorrectToCartItemAdd(cartItemToAddDto));
       if (result.Success == false)  
            return result;
       
        _cartItemDal.AddAsync(new CartItem()
        {
            CartId = cartItemToAddDto.CartId,
            ProductId = cartItemToAddDto.ProductId,
            Qty = cartItemToAddDto.Qty
        }); 
        return new SuccessResult(Messages.CartItemAdd);
    }

    public async Task<IResult> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto)
    {
        var item = await _cartItemDal.GetByIdAsync(cartItemQtyUpdateDto.CartItemId);
        if (item!=null)
        {
            item.Qty = cartItemQtyUpdateDto.Qty;
            _cartItemDal.Update(item);
            return new  SuccessResult(Messages.CartItemUpdated);
        }

        return new ErrorResult(Messages.ErrorCartItemUpdated);
    }

    public async Task<IResult> DeleteItem(int id)
    {
        var item = await _cartItemDal.GetByIdAsync(id);
        if (item==null)
        {
            return new ErrorResult(Messages.CartItemNotFound);
        }
        _cartItemDal.DeleteAsync(item);
        return new SuccessResult(Messages.CartItemDeleted);
    }
    
    private async Task<IResult> CheckIfProductCorrectToCartItemAdd(CartItemToAddDto cartItemToAddDto)
    {
        var result = await _productService.GetById(cartItemToAddDto.ProductId);
        if (result.Data == null)
            return new ErrorResult(Messages.ProductNotFound);
        return new SuccessResult();
    }   
    private async Task<IResult> CheckIfCartIdCorrectToCartItemAdd(CartItemToAddDto cartItemToAddDto)
    {
        var result = await _cartService.GetById(cartItemToAddDto.CartId);
        if (!result.Success)
            return new ErrorResult(Messages.CartNotFound);
        return new SuccessResult();
    } 
    private async Task<IResult> CheckIfCartItemExists(int cartId,int productId)
    {
        var result = await _cartItemDal.GetAsync(cartItem=> cartItem.CartId==cartId && cartItem.ProductId==productId);
        if (result != null)
            return new ErrorResult(Messages.CartItemAlreadyExists);
        return new SuccessResult();
    }
}