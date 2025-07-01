using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogPostsDAO
    {
        public static List<BlogPost> GetBlogByPublish()
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.BlogPosts
                          .Where(p => p.IsPublished == true)
                          .OrderByDescending(p => p.CreatedAt)
                          .ToList();
        }
        public static List<BlogPost> GetAllBlogByAdmin()
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.BlogPosts
                          .OrderByDescending(p => p.CreatedAt)
                          .ToList();
        }

        public static BlogPost? GetById(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.BlogPosts.FirstOrDefault(p => p.PostId == id);
        }

        public static void Add(BlogPost post)
        {
            using var context = new VeterinaryClinicSystemContext();           
            context.BlogPosts.Add(post);
            context.SaveChanges();
        }

        public static void Update(BlogPost updatedPost)
        {
            using var context = new VeterinaryClinicSystemContext();
            var existing = context.BlogPosts.FirstOrDefault(p => p.PostId == updatedPost.PostId);

            if (existing != null)
            {
                if (!string.IsNullOrWhiteSpace(updatedPost.Title))
                    existing.Title = updatedPost.Title;
                //if (!string.IsNullOrWhiteSpace(updatedPost.Slug))
                //    existing.Slug = updatedPost.Slug;
                if (string.IsNullOrWhiteSpace(updatedPost.Slug))
                    updatedPost.Slug = updatedPost.Title?.ToLower().Replace(" ", "-") ?? "";

                if (!string.IsNullOrWhiteSpace(updatedPost.Content))
                    existing.Content = updatedPost.Content;

                if (!string.IsNullOrWhiteSpace(updatedPost.CoverImageUrl))
                    existing.CoverImageUrl = updatedPost.CoverImageUrl;

                if (updatedPost.AuthorId != null)
                    existing.AuthorId = updatedPost.AuthorId;

                if (!string.IsNullOrWhiteSpace(updatedPost.Category))
                    existing.Category = updatedPost.Category;

                if (updatedPost.IsPublished != null)
                    existing.IsPublished = updatedPost.IsPublished;

                existing.UpdatedAt = DateTime.Now;

                context.SaveChanges();
            }
        }


        public static void Delete(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            var post = context.BlogPosts.FirstOrDefault(p => p.PostId == id);
            if (post != null)
            {
                context.BlogPosts.Remove(post);
                context.SaveChanges();
            }
        }
    }
}
