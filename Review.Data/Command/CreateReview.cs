using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Review.Data.Command
{
    public class CreateReviewCommand : IRequest
    {
        public int ProductId { get; set; }
        public Service.Models.Review Review { get; set; }
    }

    public class CreateReview
    {
        public class Handler : AsyncRequestHandler<CreateReviewCommand>
        {
            private readonly IMapper _mapper;
            private readonly ReviewDbContext _dbContext;

            public Handler(IMapper mapper, ReviewDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            protected override async Task Handle(CreateReviewCommand command, CancellationToken cancellationToken)
            {
                var review = _mapper.Map<Entities.Review>(command.Review);
                review.ProductId = command.ProductId;
                await _dbContext.Reviews.AddAsync(review);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
