﻿using SQLite;
using System;

namespace TescoSWTestApp.Models
{
    public class Item
    {
        [PrimaryKey,AutoIncrement]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}