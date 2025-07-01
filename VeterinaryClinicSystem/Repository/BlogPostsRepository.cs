using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repository
{

    public class BlogPostsRepository : IBlogPostsRepository
    {
        public List<BlogPost> GetAll() => BlogPostsDAO.GetAll();
        public BlogPost? GetById(int id) => BlogPostsDAO.GetById(id);
        public void Add(BlogPost post) => BlogPostsDAO.Add(post);
        public void Update(BlogPost post) => BlogPostsDAO.Update(post);
        public void Delete(int id) => BlogPostsDAO.Delete(id);
    }
}