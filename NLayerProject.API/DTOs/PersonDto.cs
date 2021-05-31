﻿using System.ComponentModel.DataAnnotations;

namespace NLayerProject.API.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
