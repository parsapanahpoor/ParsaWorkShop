using Domain.Models.Blog;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
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

        #region Videos
        List<Video> GetAllVideos();
        List<Video> GetAllDeletedVideos();
        int AddVideo(Video video, IFormFile imgBlogUp, IFormFile demoUp, User user);
        int UpdateVideo(Video video, IFormFile imgBlogUp, IFormFile demoUp);
        void AddCategoryToVideo(List<int> Categories, int videoid);
        List<VideoSelectedCategory> GetAllVideoSelectedCategories();
        Video GetVideoById(int VideoId);
        void EditeVideoSelectedCategory(List<int> Categories, int videoid);
        void DeleteVideos(Video video);
        void UpdateBlogForLock(Video video);
        #endregion


    }
}
