namespace Infrastructure.JsonPlaceHolderApi
{
    public class Endpoints
    {
        public class Posts
        {

            private const string PostPath = "/posts";

            public static string GetAllPosts => PostPath;
            public static string CreatePost => PostPath;
            public static string GetPostById(int postId) => $"{PostPath}/{postId}";
            public static string GetCommentsForPost(int postId) => $"{PostPath}/{postId}/comments";
        }
    }
}
