using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turtle.Helper
{
    public class Picture
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

        //To validate Image
        public bool IsValidImage(string contentType)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (validImageTypes.Contains(contentType))
                return true;

            return false;
        }

    }
}