﻿using MediatR;

namespace labor.Application.Mediatr.Commands
{
    public interface ICommand<out T> : IRequest<T>
    {
    }

    public interface ICommand : ICommand<bool>
    {
    }
}
