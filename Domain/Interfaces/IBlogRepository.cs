using Domain.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBlogRepository
    {

        #region BlogCategory

        BlogCategory GetBlogCategoryById(int id);
        List<BlogCategory> GetAllBlogCategories();
        void AddBlogCategory(BlogCategory blogCategory);
        void UpdateBlogCategroy(BlogCategory blogCategory);
        void Savechanges();

        #endregion


        #region Videos
        List<Video> GetAllVideos();
        List<Video> GetAllDeletedVideos();
        void AddVideo(Video video);
        void UpdateVideo(Video video);
        void AddCategoryToVideo(VideoSelectedCategory video);
        List<VideoSelectedCategory> GetAllVideoSelectedCategories();
        Video GetVideoById(int VideoId);
        void EditeVideoSelectedCategory( int videoid);

        #endregion



        #region Blogs

        List<Blog> GetAllBlogs();

        //int AddBlog(Models.Entites.Blog.Blog blog, IFormFile imgBlogUp, User user);
        void AddCategoryToBlog(List<int> Categories, int BlogId);

        //int UpdateBlog(Models.Entites.Blog.Blog blog, IFormFile imgBlogUp);

        Blog GetBlogById(int blogid);

        List<BlogSelectedCategory> GetAllBlogSelectedCategory();

        void EditBlogSelectedCategory(List<int> Categories, int BlogId);

        string GetUserNameByBlog(int blogid);

        void UpdateBlog(Blog blog);

        void DeleteBlog(Blog blog);

        List<Blog> GetAllDeletedBlogs();


        #endregion



        #region HomPage

        Tuple<List<Blog>, int> GetBlogsForShowInHomePage(int? Categroyid, int pageId = 1, string filter = "",
                        int take = 0);

        Tuple<List<Video>, int> GetVideosForShowInHomePage(int? Categroyid, int pageId = 1, string filter = "",
               int take = 0);
        List<Blog> GetLastestBlogs();

        List<Video> GetLastestVideos();


        #endregion



    }
}
