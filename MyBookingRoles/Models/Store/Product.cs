﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Models.Store
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Brand")]
        public int BrandID { get; set; }

        [Display(Name = "Product Category")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        [Display(Name = "Product Category")]
        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public string Description { get; set; }

        //[Display(Name = "Product Image")]
        //[DataType(DataType.ImageUrl)]

        //Image
        public byte[] ProductPics { get; set; }



        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 99999.99, ErrorMessage = "Price must be between 0.01 and 99999.99")]
        public decimal Price { get; set; }    }
}