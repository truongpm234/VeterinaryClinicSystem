using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BlogPostsService : IBlogPostsService
    {
        private readonly IBlogPostsRepository _repo;

        public BlogPostsService(IBlogPostsRepository _blogPostRepository)
        {
            _repo = _blogPostRepository;
        }

        public List<BlogPost> GetBlogByPublish() => _repo.GetBlogByPublish();
        public List<BlogPost> GetAllBlogByAdmin() => _repo.GetAllBlogByAdmin();
        public BlogPost? GetById(int id) => _repo.GetById(id);
        public void Add(BlogPost post) => _repo.Add(post);
        public void Update(BlogPost post) => _repo.Update(post);
        public void Delete(int id) => _repo.Delete(id);
    }
}
