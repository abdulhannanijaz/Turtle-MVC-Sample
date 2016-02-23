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
}