using Application.Convertors;
using Application.Genarator;
using Application.Interfaces;
using Application.Security;
using Domain.Interfaces;
using Domain.Models.Blog;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void AddCategoryToVideo(List<int> Categories, int videoid)
        {
            foreach (var item in Categories)
            {
                VideoSelectedCategory video = new VideoSelectedCategory()
                {
                    BlogCategoryId = item,
                    VideoId = videoid
                };

                _blog.AddCategoryToVideo(video);

            }
        }

        public int AddVideo(Video video, IFormFile imgBlogUp, IFormFile demoUp, User user)
        {
            video.UserId = user.UserId;
            video.IsActive = true;
            video.CreateDate = DateTime.Now;
            video.VideoImageName = "no-photo.png";  //تصویر پیشفرض


            //TODO Check Image
            if (imgBlogUp != null && imgBlogUp.IsImage())
            {
                video.VideoImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog/image", video.VideoImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog/thumb", video.VideoImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 200);
            }

            if (demoUp != null)
            {
                video.DemoFileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(demoUp.FileName);
                string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog/Videos", video.DemoFileName);
                using (var stream = new FileStream(demoPath, FileMode.Create))
                {
                    demoUp.CopyTo(stream);
                }
            }


            _blog.AddVideo(video);

            return video.VideoId;
        }

        public void DeleteBlogCategory(int id)
        {
            BlogCategory blogCategory = GetBlogCategoryById(id);
            blogCategory.IsDelete = true;

            _blog.UpdateBlogCategroy(blogCategory);
        }

        public void DeleteVideos(Video video)
        {
            video.IsDelete = true;
            _blog.UpdateVideo(video);
        }

        public void EditeVideoSelectedCategory(List<int> Categories, int videoid)
        {
            _blog.EditeVideoSelectedCategory(videoid);

            AddCategoryToVideo(Categories, videoid);
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            return _blog.GetAllBlogCategories();
        }

        public List<Video> GetAllDeletedVideos()
        {
            return _blog.GetAllDeletedVideos();
        }

        public List<Video> GetAllVideos()
        {
            return _blog.GetAllVideos();
        }

        public List<VideoSelectedCategory> GetAllVideoSelectedCategories()
        {
            return _blog.GetAllVideoSelectedCategories();
        }

        public BlogCategory GetBlogCategoryById(int id)
        {
            return _blog.GetBlogCategoryById(id);
        }

        public Video GetVideoById(int VideoId)
        {
            return _blog.GetVideoById(VideoId);
        }

        public void UpdateBlogCategroy(BlogCategory blogCategory)
        {
            _blog.UpdateBlogCategroy(blogCategory);
        }

        public void UpdateBlogForLock(Video video)
        {
            _blog.UpdateVideo(video);
        }

        public int UpdateVideo(Video video, IFormFile imgBlogUp, IFormFile demoUp)
        {
            if (imgBlogUp != null && imgBlogUp.IsImage())
            {

                if (video.VideoImageName != "no-photo.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/image", video.VideoImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/thumb", video.VideoImageName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }


                video.VideoImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog/image", video.VideoImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog/thumb", video.VideoImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 200);
            }

            if (demoUp != null)
            {

                if (video.DemoFileName != null)
                {
                    string deleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog/Videos", video.DemoFileName);
                    if (File.Exists(deleteDemoPath))
                    {
                        File.Delete(deleteDemoPath);
                    }
                }

                video.DemoFileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(demoUp.FileName);
                string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog/Videos", video.DemoFileName);
                using (var stream = new FileStream(demoPath, FileMode.Create))
                {
                    demoUp.CopyTo(stream);
                }
            }

            _blog.UpdateVideo(video);

            return video.VideoId;
        }
    }
}
