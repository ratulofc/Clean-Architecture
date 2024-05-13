using AutoMapper;
using Ecommerce.Core.Interfaces.Repositories;
using Ecommerce.Core.Interfaces.Services;
using Ecommerce.Core.Models;
using Ecommerce.Core.Request;
using Ecommerce.Core.Response;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;
        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserResponse> Add(UserRequest requestDTO)
        {
            var user = mapper.Map<User>(requestDTO);
            var userResponse = await this.repositoryWrapper.UserRepository.CreateAsync(user);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<UserResponse>(userResponse);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await this.repositoryWrapper.UserRepository.DeleteAsync(id);
            await this.repositoryWrapper.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var users = await this.repositoryWrapper.UserRepository.GetAllAsync("Product");
            var result = mapper.Map<IEnumerable<UserResponse>>(users);
            return result;
        }

        public async Task<UserResponse?> GetById(int id)
        {
            var user = await this.repositoryWrapper.UserRepository.GetById(id);
            if (user is null) return null;
            var result = mapper.Map<UserResponse>(user);
            return result;
        }

        public async Task<UserResponse?> Update(int id, UserRequest requestDTO)
        {
            var user = mapper.Map<User>(requestDTO);
            var userResponse = await this.repositoryWrapper.UserRepository.UpdateAsync(id, user);
            if (userResponse is not null)
            {
                await this.repositoryWrapper.SaveAsync();
                return mapper.Map<UserResponse>(userResponse);
            }
            return null;
        }

        public async Task<UserResponse?> UpdatePatch(int id, JsonPatchDocument<User> request)
        {
            var userResponse = await this.repositoryWrapper.UserRepository.UpdatePatchAsync(id, request);
            if (userResponse is not null)
            {
                await this.repositoryWrapper.SaveAsync();
                return mapper.Map<UserResponse>(userResponse);
            }
            return null;
        }
    }
}