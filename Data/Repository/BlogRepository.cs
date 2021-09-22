using Data.Context;
using Domain.Interfaces;
using Domain.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private ParsaWorkShopContext _context;

        public BlogRepository(ParsaWorkShopContext context)
        {
            _context = context;
        }

        public void AddBlogCategory(BlogCategory blogCategory)
        {
            _context.BlogCategories.Add(blogCategory);

            Savechanges();
        }

        public void AddCategoryToBlog(List<int> Categories, int BlogId)
        {
            throw new NotImplementedException();
        }

        public void AddCategoryToVideo(List<int> Categories, int videoid)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteVideos(Video video)
        {
            throw new NotImplementedException();
        }

        public void EditBlogSelectedCategory(List<int> Categories, int BlogId)
        {
            throw new NotImplementedException();
        }

        public void EditeVideoSelectedCategory(List<int> Categories, int videoid)
        {
            throw new NotImplementedException();
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            return _context.BlogCategories.ToList();
        }

        public List<Blog> GetAllBlogs()
        {
            throw new NotImplementedException();
        }

        public List<BlogSelectedCategory> GetAllBlogSelectedCategory()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAllDeletedBlogs()
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAllDeletedVideos()
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAllVideos()
        {
            throw new NotImplementedException();
        }

        public List<VideoSelectedCategory> GetAllVideoSelectedCategories()
        {
            throw new NotImplementedException();
        }

        public Blog GetBlogById(int blogid)
        {
            throw new NotImplementedException();
        }

        public BlogCategory GetBlogCategoryById(int id)
        {
            return _context.BlogCategories.Find(id);
        }

        public Tuple<List<Blog>, int> GetBlogsForShowInHomePage(int? Categroyid, int pageId = 1, string filter = "", int take = 0)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetLastestBlogs()
        {
            throw new NotImplementedException();
        }

        public List<Video> GetLastestVideos()
        {
            throw new NotImplementedException();
        }

        public string GetUserNameByBlog(int blogid)
        {
            throw new NotImplementedException();
        }

        public Video GetVideoById(int VideoId)
        {
            throw new NotImplementedException();
        }

        public Tuple<List<Video>, int> GetVideosForShowInHomePage(int? Categroyid, int pageId = 1, string filter = "", int take = 0)
        {
            throw new NotImplementedException();
        }

        public void Savechanges()
        {
            _context.SaveChanges();
        }

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlogCategroy(BlogCategory blogCategory)
        {
            _context.BlogCategories.Update(blogCategory);

            Savechanges();
        }

        public void UpdateBlogForLock(Video video)
        {
            throw new NotImplementedException();
        }
    }
}
