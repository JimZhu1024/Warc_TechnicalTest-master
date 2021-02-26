using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductShop.Models
{
    public class EditProductViewModel
    {
        [Display(Name = "Id", Description = "", ShortName = "Id", ResourceType = typeof(Resources.ProductItem))]
        public int Id { get; set; }
        [Display(Name ="Price", Description ="", ShortName ="Price", ResourceType = typeof(Resources.ProductItem))]
        public decimal Price { get; set; }
        [Display(Name = "Title", Description = "", ShortName = "Title", ResourceType = typeof(Resources.ProductItem))]
        public string Title { get; set; }
        [Display(Name = "ImagePath", Description = "", ShortName = "ImagePath", ResourceType = typeof(Resources.ProductItem))]
        public string ImagePath { get; set; }
        [Display(Name = "Description", Description = "", ShortName = "Description", ResourceType = typeof(Resources.ProductItem))]
        public string Description { get; set; }
    }
}