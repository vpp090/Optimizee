﻿using ArtificialIntel.Repos.Entities;
using MediatR;


namespace ArtificialIntel.Application.Features.Commands.ResponseWriter
{
    public class ResponseWriterCommand : IRequest<IEnumerable<WorkspaceEntity>>
    {
    }
}
