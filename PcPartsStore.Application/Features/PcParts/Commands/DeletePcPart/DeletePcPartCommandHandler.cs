﻿using MediatR;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Features.PcParts.Commands.DeletePcPart
{
    public class DeletePcPartCommandHandler : IRequestHandler<DeletePcPartCommand, DeletePcPartCommandResponse>
    {
        private readonly IAsyncReposotory<Parts> _asyncReposotory;

        public DeletePcPartCommandHandler(IAsyncReposotory<Parts> asyncReposotory)
        {
            _asyncReposotory = asyncReposotory;
        }

        public async Task<DeletePcPartCommandResponse> Handle(DeletePcPartCommand request, CancellationToken cancellationToken)
        {
            var deletePcPartResponse = new DeletePcPartCommandResponse();

            var pcPartToDelete = await _asyncReposotory.GetByIdAsync(request.PartId);

            if (pcPartToDelete == null)
            {
                deletePcPartResponse.Success = false;
                deletePcPartResponse.Message = "Part Not Found";
                return deletePcPartResponse;
            }

            await _asyncReposotory.DeleteAsync(pcPartToDelete);

            return deletePcPartResponse;
        }
    }
}
