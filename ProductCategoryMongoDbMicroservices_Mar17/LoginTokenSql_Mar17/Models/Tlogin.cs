using System;
using System.Collections.Generic;

namespace LoginTokenSql_Mar17.Models;

public partial class Tlogin
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
