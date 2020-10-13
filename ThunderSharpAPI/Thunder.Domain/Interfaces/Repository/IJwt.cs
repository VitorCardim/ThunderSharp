using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Domain.Interfaces.Repository
{
    public interface IJwt
    {
        string GenerateToken(string role, string id);
    }
}
