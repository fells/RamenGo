﻿using System.Runtime.CompilerServices;

namespace ramengo.Models
{
    public class Broth
    {
        public int Id { get; set; }
        public string ImageInactive { get; set; }
        public string ImageActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
