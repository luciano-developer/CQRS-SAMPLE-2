using Application.Posts;
using Application.Posts.Commands.CreatePost;
using Application.Posts.Queries.GetAllPosts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.JsonPlaceHolderApi
{
    public class PostsApi : IPostsApi
    {
        private readonly JsonPlaceHolderClient client;

        public PostsApi(JsonPlaceHolderClient client)
        {
            this.client = client;
        }
        public async Task<CreatePostResponse> CreatePost(CreatePostRequest request)
        {
            return await client.CreatePost(request);
        }

        public async Task<IEnumerable<GetAllPostsResponse>> GetAllPosts()
        {
            return await client.GetAllPosts();
        }
    }
}
