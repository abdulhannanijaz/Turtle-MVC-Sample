using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleDAL
{
    public partial class ClanMetadata
    {

        [Required]
        public string Name { get; set; }

    }
}