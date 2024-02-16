using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.App;
using AspNetCoreHero.Results;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Tickets.Commands.Create
{
    public partial class CreateTicketsCommand : IRequest<Result<Guid>>
    {
        public string Code { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid AssignedTo { get; set; }
        // platform source
    }

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketsCommand, Result<Guid>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateTicketsCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Ticket>(request);
            await _ticketRepository.InsertAsync(product);
            await _unitOfWork.SaveAndCommitAsync(cancellationToken: cancellationToken);
            return Result<Guid>.Success(product.Id);
        }
    }
}