using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turtle.Models
{
    public class PictureModel
    {
        private string ImageName { get; set; }

        //toReplace old image
        public string GetImageName(string OldImageName, string Extension)
        {
            ImageName = String.IsNullOrWhiteSpace(OldImageName) ?
                  //True Case 
                  Guid.NewGuid().ToString() + Extension :
                //False Case
                OldImageName;

            return ImageName;
        }
    }
}