﻿using AutoMapper;
using FluentValidation.Internal;
using LeaveManagementApplication.Application.Exceptions;
using LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Validators;
using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using MediatR;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public int id { get; set; }
    public int numberOfDays { get;set; }
    public int leaveTypeId { get;set; }
    public int period { get;set; }
    public LeaveAllocationViewModel leaveAllocationViewModel { get;set; }
}

public class UpdateLeaveAllocationCommandHandler  : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{

    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }


    public async Task<Unit> Handle( UpdateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationValidator();
        var validatorResult = await validator.ValidateAsync(command.leaveAllocationViewModel);

        if (validatorResult.IsValid==false)
        {
            throw new ValidationException(validatorResult);
        }

        var leaveAllocation = _leaveAllocationRepository.Get(command.leaveAllocationViewModel.Id);
        await _mapper.Map(command.leaveAllocationViewModel, leaveAllocation);
        await _leaveAllocationRepository.update(leaveAllocation.Result);
        return Unit.Value;
    }
}
