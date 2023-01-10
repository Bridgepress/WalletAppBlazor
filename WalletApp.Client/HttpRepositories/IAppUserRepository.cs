using System.Text.Json;
using System;
using WalletApp.Client.DTO.AppUser;

namespace WalletApp.Client.HttpRepositories
{
    public interface IAppUserRepository
    {
        public Task<UserDTO> registerUser(RegisterDTO registerDTO);

        public Task<UserDTO> loginUser(LoginDTO login);

        public Task Logout();
    }
}
