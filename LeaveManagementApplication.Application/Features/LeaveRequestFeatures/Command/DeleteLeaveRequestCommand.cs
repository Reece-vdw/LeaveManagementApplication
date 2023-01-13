﻿using AutoMapper;
using LeaveManagementApplication.Application.Exceptions;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command
{

    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }

    }

    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {

        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand command, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(command.Id);


            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), command.Id);
            }
            await _leaveRequestRepository.delete(leaveRequest);
            return Unit.Value;
        }
    }
}
