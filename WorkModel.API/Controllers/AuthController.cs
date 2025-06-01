using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkModel.Application.Auth;
using WorkModel.Application.Auth.Commands;
using WorkModel.Application.DTO;
using WorkModel.Application.Services;

namespace WorkModel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IValidator<RegisterRequest> _validator;
  private readonly IMediator _mediator;

  public AuthController(IMediator mediator, IValidator<RegisterRequest> validator)
  {
    _mediator = mediator;
    _validator = validator;
  }


  [AllowAnonymous]
  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {

    var validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      return (IActionResult)Result.Failure(errors);
    }

    var command = new RegisterCommand(
        request.FirstName,
        request.LastName,
        request.UserName,
        request.Email,
        request.Password,
        request.Role
    );

    var result = await _mediator.Send(command);
    return Ok(result);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var command = new LoginCommand(
        request.Email,
        request.Password
    );

    var result = await _mediator.Send(command);
    return Ok(result);
  }
}
