﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Movielib.Entities
{
    class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }

        public Movie(int id, string name, string desc, int lenght)
        {
            this.Id = id;
            this.Name = name;
            this.Description = desc;
            this.Length = lenght;

        }

    }
}
