using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartShop.DataLib.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartShop.DataLib.Models.Data
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        [Required, StringLength(30)]
        public string CampaignName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required, EnumDataType(typeof(DiscountAmountType))]
        public DiscountAmountType DiscountType { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal DiscountAmount { get; set; }
        [Column(TypeName = "money")]
        public decimal? PerOrderValue { get; set; }
        [Required, EnumDataType(typeof(DiscountRuleType))]
        public DiscountRuleType RuleType { get; set; }
        [Column(TypeName = "money")]
        public decimal? MinOrderValue { get; set; }
       
    }
    public class Category
    {
        public Category()
        {
            this.Subcategories = new List<Subcategory>();
        }
        public int CategoryId { get; set; }
        [Required, StringLength(30), Display(Name = "Category")]
        public string CategoryName { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }

    public class Subcategory
    {
        public Subcategory()
        {
            this.Products = new List<Product>();
            this.ProductConfigurations = new List<ProductConfiguration>();
        }
        public int SubcategoryId { get; set; }
        [Required, StringLength(30), Display(Name = "Sub Category")]
        public string SubcategoryName { get; set; }
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProductConfiguration> ProductConfigurations { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public class Brand
    {
        public Brand() { this.Products = new List<Product>(); }
        public int BrandId { get; set; }
        [Required, StringLength(30), Display(Name = "Brand")]
        public string BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }

    public class Shipping
    {
        public int ShippingId { get; set; }
        [Required, StringLength(150), Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Shipping Cost")]
        public decimal ShippingCost { get; set; }
        public virtual IList<Order> Orders { get; set; }

    }
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
            this.Reviews = new List<Review>();
            this.Carts = new List<Cart>();
        }
        public int CustomerId { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [Required, StringLength(450)]
        public string UserId { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

    /*
     * Associated entities
     * 
     * */


    public class ProductPrice
    {
        public int ProductPriceId { get; set; }
        [Required, StringLength(20)]
        public string PropertyValue { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        //FK
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        //navigation
        public virtual Product Product { get; set; }
    }
    public class ProductSpec
    {
        public int ProductSpecId { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public bool IsChoosingLabel { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        [Required, StringLength(150)]
        public string ImageName { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class ProductConfiguration
    {
        public int ProductConfigurationId { get; set; }
        [Required, StringLength(60)]
        public string ConfigurationLabel { get; set; }
        [Required, ForeignKey("Subcategory")]
        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
    public class Product
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();

            this.ProductImages = new List<ProductImage>();
            this.ProductSpecs = new List<ProductSpec>();
            this.ProductPrices = new List<ProductPrice>();
            this.Reviews = new List<Review>();
            this.Carts = new List<Cart>();
        }
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [Required, StringLength(200)]
        public string ProductDescription { get; set; }

        //[Required, Column(TypeName = "money")]
        //public decimal ProductPrice { get; set; }
        [Required, StringLength(30)]
        public string PriceDeterminingProperty { get; set; }

        public bool? ProductStatus { get; set; }

        [Required, ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Subcategory")]
        public int? SubcategoryId { get; set; }

        [ForeignKey("SubcategoryId")]
        public virtual Subcategory Subcategory { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public virtual IList<Cart> Carts { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }

        public virtual IList<ProductImage> ProductImages { get; set; }
        public virtual IList<ProductSpec> ProductSpecs { get; set; }
        public virtual IList<ProductPrice> ProductPrices { get; set; }
        public IList<Review> Reviews { get; set; }
    }
    public class Cart
    {
        public int CartId { get; set; }
        [Required, ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }
        [Required, ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public int OrderId { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }
        [Required, ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required, ForeignKey("Shipping")]
        public int ShippingId { get; set; }
        [StringLength(30)]
        public string TrxId { get; set; }
        [StringLength(30)]
        public string PaymentName { get; set; }
        public bool IsConfirmed { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Comment { get; set; }


        public virtual Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public class Payment
    {
        public int PaymentId { get; set; }
        [Required, StringLength(50)]
        public string PaymentName { get; set; }
        [StringLength(30)]
        public string ShortName { get; set; }
        [StringLength(30)]
        public string PaymentType { get; set; }
        [StringLength(50)]
        public string AccountNo { get; set; }


    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [Required, ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }

        [Required, ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [Required, ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
    public class Review
    {
        public int ReviewId { get; set; }

        [StringLength(300)]
        public string Comment { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Rating { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }

    public class SmartShopDbContext : DbContext
    {
        public SmartShopDbContext(DbContextOptions<SmartShopDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        /*
         * Top label tables
         * 
         * */
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<ProductConfiguration> ProductConfigurations { get; set; }

        public DbSet<Shipping> Shippings { get; set; }

        /*
         * Vital entities
         * 
         * */
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductSpec> ProductSpecs { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
