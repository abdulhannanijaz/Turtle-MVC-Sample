using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turtle.Helper
{
    public class Pagination
    {
        private int TotalPages;
        public int ItemCountPerPage{ get; }
        private int Offset;

        public Pagination()
        {
            ItemCountPerPage = 20;
            Offset = 0;
            TotalPages = 1;
        }

        public int GetPageCount(int TotalItems)
        {
            TotalPages = TotalItems / ItemCountPerPage;
            //To handle 1 backward page as page one will have all the records 
            return TotalPages;
        }

        public int GetOffsetNumber(int? PageNumber)
        {
            //-1 to handle number of loop onfront end
            Offset = ((PageNumber ?? 1)-1) * ItemCountPerPage;
            return Offset;
        }


    }
}