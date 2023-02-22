﻿using AutoMapper;
using LeaveManagementApplication.Application.Exceptions;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;

public class DeleteLeaveAllocationCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.Get(command.Id);
        if (leaveAllocation == null) throw new NotFoundException(nameof(LeaveAllocation), command.Id);
        await _leaveAllocationRepository.delete(leaveAllocation);
        return Unit.Value;
    }
}