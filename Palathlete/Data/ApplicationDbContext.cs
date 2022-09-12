using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PalathleteLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Palathlete.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Hoodie", Description = "Palathlete Hoodies" },
                new Category() { CategoryId = 2, CategoryName = "Tshirt", Description = "Palathlete T-shirts and shirts" },
                new Category() { CategoryId = 3, CategoryName = "Cap", Description = "Palathlete caps and headwear" }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    Name = "Red hoodie",
                    ShortDescription = "This is a red hoodie.",
                    LongDescription = "This is the best red hoodie ever in planet earth. Made up of pure cotton, doesn't fade.",
                    Price = 30,
                    ImageUrl = "https://i.ibb.co/c1xdX4G/redhoodie.jpg",
                    ImageThumbnailUrl = "https://i.ibb.co/c1xdX4G/redhoodie.jpg",
                    IsItemOfTheWeek = true,
                    InStock = true,
                    CategoryId = 1
                },
                new Item()
                {
                    ItemId = 2,
                    Name = "Black hoodie",
                    ShortDescription = "This is a black hoodie.",
                    LongDescription = "This is the best black hoodie ever in planet earth. Made up of pure cotton, doesn't fade.",
                    Price = 30,
                    ImageUrl = "https://i.ibb.co/kx79mcx/blackhoodie.jpg",
                    ImageThumbnailUrl = "https://i.ibb.co/kx79mcx/blackhoodie.jpg",
                    IsItemOfTheWeek = true,
                    InStock = true,
                    CategoryId = 1
                },
                new Item()
                {
                    ItemId = 3,
                    Name = "Black T shirt",
                    ShortDescription = "This is a black T shirt.",
                    LongDescription = "This is the best black T shirt ever in planet earth. Made up of pure cotton, doesn't fade.",
                    Price = 15,
                    ImageUrl = "https://i.ibb.co/KF4x25R/blacktshirt.jpg",
                    ImageThumbnailUrl = "https://i.ibb.co/KF4x25R/blacktshirt.jpg",
                    IsItemOfTheWeek = true,
                    InStock = true,
                    CategoryId = 2
                },
                new Item()
                {
                    ItemId = 4,
                    Name = "Red T shirt",
                    ShortDescription = "This is a red T shirt.",
                    LongDescription = "This is the best red T shirt ever in planet earth. Made up of pure cotton, doesn't fade.",
                    Price = 15,
                    ImageUrl = "https://i.ibb.co/vd5mfKn/redtshirt.jpg",
                    ImageThumbnailUrl = "https://i.ibb.co/vd5mfKn/redtshirt.jpg",
                    IsItemOfTheWeek = true,
                    InStock = true,
                    CategoryId = 2
                },
                new Item()
                {
                    ItemId = 5,
                    Name = "Black cap",
                    ShortDescription = "This is a black cap.",
                    LongDescription = "This is the best black cap ever in planet earth. Made up of pure cotton, doesn't fade.",
                    Price = 25,
                    ImageUrl = "https://i.ibb.co/vs3YQzc/blackcap.jpg",
                    ImageThumbnailUrl = "https://i.ibb.co/vs3YQzc/blackcap.jpg",
                    IsItemOfTheWeek = true,
                    InStock = true,
                    CategoryId = 3
                }
            );

            //new Item() { Id = 2, Name = "Black t-shirt", Description = "This is a black tshirt.", Price = 15, ImageUrl = "https://i.imgur.com/JuMPO5R.jpeg", ItemCategory = Enums.ItemCategory.Tshirt },
            //new Item() { Id = 3, Name = "White cap", Description = "This is a white cap.", Price = 10, ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpurepng.com%2Fpublic%2Fuploads%2Flarge%2Fpurepng.com-simple-white-capcapfittedsportssimplewhite-1421526278639br9kb.png&f=1&nofb=1", ItemCategory = Enums.ItemCategory.Caps }


        }
    }
}
