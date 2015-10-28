﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repozytorium.Models;
using Repozytorium.Repo;
using Repozytorium.Repo.Abstract;

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