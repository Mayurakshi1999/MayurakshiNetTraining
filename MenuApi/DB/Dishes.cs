using System;
using System.Collections.Generic;

namespace MenuApi.DB
{
    public partial class Dishes
    {
        public int DishId { get; set; }
        public string? DishName { get; set; }
        public int? Price { get; set; }
        public int? MenuId { get; set; }
        public int? ChoiceId { get; set; }
    }
}
