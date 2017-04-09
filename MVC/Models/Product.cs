using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

public partial class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public byte[] ProductImage { get; set; }
    public int id { get; set; }
}

public class ProductDBContext : DbContext
{
    public DbSet<Product> products { get; set; }
}
