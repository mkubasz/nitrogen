using System.Linq;

using SphynxWeb.Models;

namespace SphynxWeb.Repo.Abstract
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