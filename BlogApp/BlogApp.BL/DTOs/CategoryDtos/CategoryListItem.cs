using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.CategoryDtos;

public class CategoryListItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public static implicit operator CategoryListItem(Category cat)
    {
        return new CategoryListItem
        {
            Id = cat.Id,
            Name = cat.Name,
            Icon = cat.Icon,
        };
    }
}
