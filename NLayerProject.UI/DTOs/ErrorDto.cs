﻿using System.Collections.Generic;

namespace NLayerProject.UI.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }

        public int Status { get; set; }
    }
}
