csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

// This file is created to demonstrate the creation of the IUserRepository interface.
\nnamespace HotelBookingSystem.Domain.Interfaces;\n\npublic interface IUserRepository\n{\n    Task<User> AddAsync(User user);\n    Task<bool> UpdateAsync(User user);\n    Task<bool> DeleteAsync(long userId);\n    Task<User> GetByIdAsync(long userId);\n    Task<IEnumerable<User>> GetAllAsync();\n}