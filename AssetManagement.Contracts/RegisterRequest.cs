﻿
namespace AssetManagement.Contracts
{
    public record RegisterRequest(
        string UserName,
        string Email,
        string Password);
}


