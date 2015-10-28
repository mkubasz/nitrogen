using System.Collections.Generic;
using System.Linq;
using Repozytorium.Models;

namespace Repozytorium.Repo.Abstract
{
    public interface IBlogRepo
    {
        void SaveChange();
        BlogModel GetBlogById(int? id);
        BlogModel DeleteBlog(int? id);
        void AddBlog(BlogModel blogModel);
        void EditBlog(BlogModel blogModel);
        IQueryable<BlogModel> GetAllBlogs();
        IQueryable<BlogModel> GetStartPageBlogs();
    }
}