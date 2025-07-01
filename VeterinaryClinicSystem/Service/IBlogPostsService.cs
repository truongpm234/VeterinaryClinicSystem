using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBlogPostsService
    {
        List<BlogPost> GetBlogByPublish();
        List<BlogPost> GetAllBlogByAdmin();
        BlogPost? GetById(int id);
        void Add(BlogPost post);
        void Update(BlogPost post);
        void Delete(int id);
    }
}