﻿using Domain.Entities.Identity;

namespace Application.IServices;

public interface IUserService
{
    public User? ChangePassword(Guid id, string newPassword);

    public User? ChangeEmail(Guid id, string newEmail);
    public User? GetByEmail(string email);

    public Task<User?> ChangePasswordAsync(Guid id, string newPassword);

    public Task<User?> ChangeEmailAsync(Guid id, string newEmail);
}
