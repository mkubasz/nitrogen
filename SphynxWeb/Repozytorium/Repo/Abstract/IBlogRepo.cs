using System.Collections.Generic;
using System.Linq;
using Repozytorium.Models;

namespace Repozytorium.Repo.Abstract
{
    public interface IBlogRepo
    {
        BlogModel GetBlogById(int id);
        bool DeleteBlog(int id);
        void AddBlog(BlogModel blogModel);
        void EditBlog(BlogModel blogModel);
        IQueryable GetAllBlogs();
        IQueryable<BlogModel> GetStartPageBlogs();
        IQueryable<BlogModel> GetBlogsByCategory(string category);
    }
}