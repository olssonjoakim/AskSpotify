using AskSpotify.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AskSpotify.Models
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "Query")]
        public string SearchString { get; set; }

        public ItemType ItemType { get; set; }
    }
}