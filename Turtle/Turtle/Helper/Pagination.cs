using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turtle.Helper
{
    public class Pagination
    {
        private int PageCount;
        public int ItemCountPerPage{ get; }
        private int Offset;

        public Pagination()
        {
            ItemCountPerPage = 16;
            Offset = 0;
        }

        public int GetPageCount(int TotalItems)
        {
            PageCount = TotalItems / ItemCountPerPage;
            //To handle 1 backward page as page one will have all the records 
            return PageCount;
        }

        public int GetOffsetNumber(int? PageNumber)
        {
            //-1 to handle number of loop onfront end
            Offset = ((PageNumber ?? 1)-1) * ItemCountPerPage;
            return Offset;
        }


    }
}