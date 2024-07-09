using APLIACACIONWEB_APIPLUS_BLOGUDLA.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Services
{
    public interface IBlogNodoApi
    {
        [Get("/api/nodo/blogs")]
        Task<IEnumerable<BlogNodo>> GetBlogsAsync();

        [Get("/api/nodo/blogs/{id}")]
        Task<BlogNodo> GetBlogAsync(Guid id);

        [Post("/api/nodo/blogs")]
        Task CreateBlogAsync([Body] BlogNodo blog);

        [Put("/api/nodo/blogs/{id}")]
        Task UpdateBlogAsync(Guid id, [Body] BlogNodo blog);

        [Delete("/api/nodo/blogs/{id}")]
        Task DeleteBlogAsync(Guid id);
    }

    public interface ICommentNodoApi
    {
        [Get("/api/comments/nodo/byBlogNodo/{blogNodoId}")]
        Task<IEnumerable<CommentNodo>> GetCommentsByBlogNodoIdAsync(Guid blogNodoId);

        [Get("/api/comments/nodo/{id}")]
        Task<CommentNodo> GetCommentAsync(Guid id);

        [Post("/api/comments/nodo")]
        Task CreateCommentAsync([Body] CommentNodo comment);

        [Put("/api/comments/nodo/{id}")]
        Task UpdateCommentAsync(Guid id, [Body] CommentNodo comment);

        [Delete("/api/comments/nodo/{id}")]
        Task DeleteCommentAsync(Guid id);
    }

    public interface IUserApi
    {
        [Get("/api/users")]
        Task<IEnumerable<User>> GetUsersAsync();

        [Get("/api/users/{username}")]
        Task<User> GetUserAsync(string username);

        [Post("/api/users")]
        Task CreateUserAsync([Body] User user);

        [Put("/api/users/{username}")]
        Task UpdateUserAsync(string username, [Body] User user);

        [Delete("/api/users/{username}")]
        Task DeleteUserAsync(string username);
    }
}
