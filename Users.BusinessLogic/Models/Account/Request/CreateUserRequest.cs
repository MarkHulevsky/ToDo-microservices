﻿namespace Users.BusinessLogic.Models.Account.Request;

public class CreateUserRequest
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public string UserName { get; set; }
}