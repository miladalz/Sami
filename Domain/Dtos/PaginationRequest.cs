using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class PaginationRequest
    {
        public int Take { get; set; } = 25;
        public int Skip { get; set; } = 0;

        public int GetPage() => Take * Skip;
    }
}
