using BlogApp.BL.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryListItem>> GetAllAsync();
    Task<int> CreateAsync(CategoryCreateDto dto);

}
