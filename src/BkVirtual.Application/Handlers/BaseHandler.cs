using AutoMapper;
using BkVirtual.Core.DTOs;
using BkVirtual.Core.NotificationError;
using FluentValidation;
using MediatR;

namespace BkVirtual.Application.Handlers;

public abstract class BaseHandler
{
    protected readonly IMediator Mediator;
    protected readonly IMapper Mapper;

    protected BaseHandler(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator;
        Mapper = mapper;
    }

    protected async Task<bool> ValidarAsync<TRequest, TValidator>(TRequest entity, TValidator validator)
        where TRequest : IRequest<BaseResponse> where TValidator : AbstractValidator<TRequest>
    {
        var resultadoValidacao = validator.Validate(entity);

        foreach (var erro in resultadoValidacao.Errors)
        {
            await Mediator.Publish(new NotificacaoErro(entity.GetType().Name, erro.ErrorMessage));
        }

        return resultadoValidacao.IsValid;
    }
}