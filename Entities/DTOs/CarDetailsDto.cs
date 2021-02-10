using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    class CarDetailsDto
    {
        public int Id { get; set; }
        public int BrandName { get; set; }
        public int ColorName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
