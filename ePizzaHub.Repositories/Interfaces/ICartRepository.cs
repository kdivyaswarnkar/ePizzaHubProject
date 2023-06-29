﻿

using ePizzaHub.DAL.Entities;
using ePizzaHub.Models;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface ICartRepository :IRepository<Cart>
    {
        Cart GetCart(Guid CartId);
        CartModel GetCartDetails(Guid CartId);
        int DeleteItem(Guid cartId,int itemId);
        int UpdateQuantity(Guid cartId,int itemId,int Quantity);
        int UpdateCart(Guid cartId,int userId);
    }
}
