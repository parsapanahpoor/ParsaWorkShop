using Data.Context;
using Domain.Interfaces;
using Domain.Models.Blog;
using Microsoft.EntityFrameworkCore;
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

        public void AddCategoryToVideo(VideoSelectedCategory video)
        {
            _context.VideoSelectedCategory.Add(video);
            Savechanges();
        }

        public void AddVideo(Video video)
        {
            _context.Video.Add(video);

            Savechanges();
        }

        public void DeleteBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void EditBlogSelectedCategory(List<int> Categories, int BlogId)
        {
            throw new NotImplementedException();
        }

        public void EditeVideoSelectedCategory( int videoid)
        {
            var groups = _context.VideoSelectedCategory.Where(p => p.VideoId == videoid).ToList();

            foreach (var item in groups)
            {
                _context.VideoSelectedCategory.Remove(item);
            }
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
            IQueryable<Video> result = _context.Video.Include(p => p.Users)
                            .IgnoreQueryFilters().Where(u => u.IsDelete);

            return result.ToList();
        }

        public List<Video> GetAllVideos()
        {
            return _context.Video.Include(p => p.Users).ToList();
        }

        public List<VideoSelectedCategory> GetAllVideoSelectedCategories()
        {
            return _context.VideoSelectedCategory.ToList();
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
            return _context.Video.Include(p => p.Users).Include(p => p.VideoSelectedCategory)
                                            .FirstOrDefault(p => p.VideoId == VideoId);
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

        public void UpdateVideo(Video video)
        {
            _context.Video.Update(video);

            Savechanges();
        }
    }
}
