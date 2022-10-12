﻿using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.BusinessLogic.Models.ToDoDirectory.Request;
using ToDo.BusinessLogic.Models.ToDoDirectory.Response;
using ToDo.BusinessLogic.Services.Interfaces;

namespace ToDo.Api.Controllers;

[Authorize]
[Route("todo/api/[controller]/[action]")]
public class ToDoDirectoryController: ControllerBase
{
    private readonly IToDoDirectoryService _toDoDirectoryService;

    public ToDoDirectoryController(IToDoDirectoryService toDoDirectoryService)
    {
        _toDoDirectoryService = toDoDirectoryService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByFilter([FromBody] GetAllDirectoriesByFilterRequest request)
    {
        GetAllDirectoriesByFilterResponse byFilterResponse = await _toDoDirectoryService.GetAllUserDirectoriesAsync(request);

        return Ok(byFilterResponse);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateToDoDirectoryRequest request)
    {
        BaseResponseModel response = await _toDoDirectoryService.CreateAsync(request);

        if (!response.IsSucceeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetToDoDirectoryByIdResponse response = await _toDoDirectoryService.GetByIdAsync(id);

        return Ok(response);
    }
}