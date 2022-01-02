using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts.Queries.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<IEnumerable<GetAllPostsDto>>
    {
        public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<GetAllPostsDto>>
        {
            private readonly IPostsApi postsApi;
            private readonly IMapper mapper;

            public GetAllPostsQueryHandler(IPostsApi postsApi, IMapper mapper)
            {
                this.postsApi = postsApi;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<GetAllPostsDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
            {
                var posts = await postsApi.GetAllPosts();
                return mapper.Map<IEnumerable<GetAllPostsDto>>(posts);
            }
        }
    }
}
