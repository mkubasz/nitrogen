using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SphynxWeb.Models;
using SphynxWeb.Repo;
using SphynxWeb.Repo.Abstract;


namespace SphynxWeb.Tests.repo
{
    [TestClass]
    public class BlogRepoTests
    {

        [TestMethod]
        public void AddNewPostTest()
        {
            IBlogRepo blogRepo = new BlogRepo();
            blogRepo.AddBlog(new BlogModel()
            {
                ShowOnStartPage = true,
                AddDate = DateTime.Now,
                Post = "some text"
            });
        }
         
    }
}