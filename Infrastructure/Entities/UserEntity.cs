﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;
}

public class AddressEntity
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    public string AddressLine_1 { get; set; } = null!;
    public string? AddressLine_2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;


}
