using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<CreatePostDto>
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostDto>
        {
            private readonly IPostsApi postsApi;
            private readonly IMapper mapper;

            public CreatePostCommandHandler(IPostsApi postsApi, IMapper mapper)
            {
                this.postsApi = postsApi;
                this.mapper = mapper;
            }

            public async Task<CreatePostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                var response = await postsApi.CreatePost(mapper.Map<CreatePostRequest>(request));
                return mapper.Map<CreatePostDto>(response);
            }
        }
    }
}
