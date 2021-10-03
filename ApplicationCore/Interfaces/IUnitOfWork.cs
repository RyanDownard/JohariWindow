﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Adjective> Adjective { get; }
        public IGenericRepository<Client> Client { get; }
        public IGenericRepository<ClientResponse> ClientResponse { get; }
        public IGenericRepository<Friend> Friend { get; }
        public IGenericRepository<FriendResponse> FriendResponse { get; }
        public IGenericRepository<InvitedFriend> InvitedFriend { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
