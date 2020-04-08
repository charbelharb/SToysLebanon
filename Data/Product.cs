﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public short Quantity { get; set; }

        public string ImagePath { get; set; }

        public string ResizedImagePath { get; set; }

        public Gender Gender { get; set; }

        public Age Age { get; set; }

        public Category Category { get; set; }
    }

    public enum Gender
    {
        Boy = 1,
        Girl = 2,
        Unisex = 3
    }

    public enum Age
    {
        ZeroToThree = 1,
        ThreeToSix = 2,
        SixToNine = 3,
        NinteToTwelve = 4,
        TwelvePlus = 5
    }

    public enum Category
    {
        Cars = 1,
        Dolls = 2
    }
}
