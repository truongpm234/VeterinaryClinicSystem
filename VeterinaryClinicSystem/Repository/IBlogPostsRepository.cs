using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBlogPostsRepository
    {
        List<BlogPost> GetBlogByPublish();
        List<BlogPost> GetAllBlogByAdmin();
        BlogPost? GetById(int id);
        void Add(BlogPost post);
        void Update(BlogPost post);
        void Delete(int id);
    }
}