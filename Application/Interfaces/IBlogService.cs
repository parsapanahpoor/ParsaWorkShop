using Domain.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBlogService
    {
        #region MyRegion

        BlogCategory GetBlogCategoryById(int id);
        List<BlogCategory> GetAllBlogCategories();
        void AddBlogCategory(BlogCategory blogCategory);
        void UpdateBlogCategroy(BlogCategory blogCategory);
        void DeleteBlogCategory(int id);

        #endregion


    }
}
