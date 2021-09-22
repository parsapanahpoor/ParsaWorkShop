using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository _blog;

        public BlogService(IBlogRepository blog)
        {
            _blog = blog;
        }

        public void AddBlogCategory(BlogCategory blogCategory)
        {
            _blog.AddBlogCategory(blogCategory);
        }

        public void DeleteBlogCategory(int id)
        {
            BlogCategory blogCategory = GetBlogCategoryById(id);
            blogCategory.IsDelete = true;

            _blog.UpdateBlogCategroy(blogCategory);
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            return _blog.GetAllBlogCategories();
        }

        public BlogCategory GetBlogCategoryById(int id)
        {
            return _blog.GetBlogCategoryById(id);
        }

        public void UpdateBlogCategroy(BlogCategory blogCategory)
        {
            _blog.UpdateBlogCategroy(blogCategory);
        }
    }
}
