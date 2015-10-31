using System;
using System.Data.Entity;
using System.Linq;

using SphynxWeb.Models;
using SphynxWeb.Repo.Abstract;

namespace SphynxWeb.Repo
{
    public class BlogRepo : IBlogRepo
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public BlogModel DeleteBlog(int? id)
        {
            BlogModel blogModel = _dbContext.Posts.Find(id);
            if (blogModel != null)
            {
                _dbContext.Posts.Remove(blogModel);
                _dbContext.SaveChanges();
                return blogModel;
            }
            return null;
        }

        public void AddBlog(BlogModel blogModel)
        {
            blogModel.AddDate = DateTime.Now;
            _dbContext.Posts.Add(blogModel);
            _dbContext.SaveChanges();
        }

        public void EditBlog(BlogModel blogModel)
        {
            _dbContext.Entry(blogModel).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IQueryable<BlogModel> GetAllBlogs()
        {
            return _dbContext.Posts;
        }

        public IQueryable<BlogModel> GetStartPageBlogs()
        {
            return _dbContext.Posts.Where(post => post.ShowOnStartPage);
        }

        public BlogModel GetBlogById(int? id)
        {
            return _dbContext.Posts.Find(id);
        }


        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}