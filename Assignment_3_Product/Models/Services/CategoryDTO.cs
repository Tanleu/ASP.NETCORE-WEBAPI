using System;

namespace Assignment_3_Product.Models;

public class CategoryDTO: IDisposable
{
    public Guid? Id { get; set; }
    public string Name { get; set; }

    void IDisposable.Dispose()
    {
 
    }
}