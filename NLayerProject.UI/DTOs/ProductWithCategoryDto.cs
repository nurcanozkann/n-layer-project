using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.UI.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public IEnumerable<CategoryDto> Category { get; set; }
    }
}