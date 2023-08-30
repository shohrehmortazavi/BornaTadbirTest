﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BornaTadbirTest.Application.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }


}
