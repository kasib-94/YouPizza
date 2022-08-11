﻿namespace YouPizza.Data.Repository.IRepository;

public interface IUnitOfWork
{
    
    ISauceRepository Sauce { get; }
    IIngredientsRepository Ingredients { get; }
    ICategoryRepository Category { get; }
    IProductRepository Products { get; }
    IIngredientsProductRepository IngredientsProduct { get; }
  

    void Save();
}