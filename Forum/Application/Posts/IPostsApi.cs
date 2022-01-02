using Application.Posts.Commands.CreatePost;
using Application.Posts.Queries.GetAllPosts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Posts
{
    public interface IPostsApi
    {
        Task<IEnumerable<GetAllPostsResponse>> GetAllPosts();
        Task<CreatePostResponse> CreatePost(CreatePostRequest request);
    }
}
