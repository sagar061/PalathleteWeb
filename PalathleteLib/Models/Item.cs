using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace PalathleteLib.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Picture")]
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

        [Display(Name = "Item of the Week")]
        public bool IsItemOfTheWeek { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
