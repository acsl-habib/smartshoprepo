// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartShop.DataLib.Models.Data;

namespace SmartShop.DataLib.Migrations.Data
{
    [DbContext(typeof(SmartShopDbContext))]
    partial class SmartShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("money");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MinOrderValue")
                        .HasColumnType("money");

                    b.Property<decimal?>("PerOrderValue")
                        .HasColumnType("money");

                    b.Property<int>("RuleType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("CampaignId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("PaymentName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("TrxId")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("money");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("PriceDeterminingProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool?>("ProductStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductConfiguration", b =>
                {
                    b.Property<int>("ProductConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfigurationLabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductConfigurationId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("ProductConfigurations");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductImage", b =>
                {
                    b.Property<int>("ProductImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductPrice", b =>
                {
                    b.Property<int>("ProductPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ProductPriceId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductSpec", b =>
                {
                    b.Property<int>("ProductSpecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsChoosingLabel")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductSpecId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSpecs");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Shipping", b =>
                {
                    b.Property<int>("ShippingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("money");

                    b.HasKey("ShippingId");

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Subcategory", b =>
                {
                    b.Property<int>("SubcategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubcategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("SubcategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Campaign", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Subcategory", "Subcategory")
                        .WithMany("Campaigns")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Order", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.OrderDetail", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartShop.DataLib.Models.Data.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Product", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartShop.DataLib.Models.Data.Subcategory", "Subcategory")
                        .WithMany()
                        .HasForeignKey("SubcategoryId");
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductConfiguration", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Subcategory", "Subcategory")
                        .WithMany("ProductConfigurations")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductImage", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductPrice", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.ProductSpec", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Product", "Product")
                        .WithMany("ProductSpecs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Review", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartShop.DataLib.Models.Data.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartShop.DataLib.Models.Data.Subcategory", b =>
                {
                    b.HasOne("SmartShop.DataLib.Models.Data.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
