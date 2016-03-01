using System;
using System.ComponentModel.DataAnnotations;

namespace TurtleDAL
{
    public partial class ClanMetadata
    {

        [Required]
        [Display(Name="Clan Name",Description ="Name of clan")]
        [StringLength(50,ErrorMessage ="between 0 and 50 characters",MinimumLength =3)]
        [DataType(DataType.Text)]

        public string Name { get; set; }
      
        [Display(Name = "Symbol Picture", Description = "Logo of clan")]
        [DataType(DataType.Upload)]
     
        public string SymbolPic { get; set; }

    
        [Display(Name = "Is Clan Evil ?", Description = "nature of clan")]

        public Nullable<bool> IsEvil { get; set; }

    }

    public partial class NinjaMetadata
    {
        [Required]
        [Display(Name ="Clan")]
        public Nullable<int> ClanID { get; set; }
        [Required(ErrorMessage ="{0} is requried")]
        [StringLength(30,ErrorMessage ="{0} must be between {2} and {1} Length",MinimumLength =1)]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }


        [Display(Name = "Age (in years)")]
        [Range(0,100,ErrorMessage ="{0} must be between {1} and {2}")]
        [DataType(DataType.Text)]
        public Nullable<int> Age { get; set; }
        [Display(Name ="Picture Link")]
        public string Picture { get; set; }

    }
}