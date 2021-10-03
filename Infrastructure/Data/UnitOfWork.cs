﻿using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IGenericRepository<Adjective> _Adjective;
        private IGenericRepository<Client> _Client;
        private IGenericRepository<ClientResponse> _ClientResponse;
        private IGenericRepository<Friend> _Friend;
        private IGenericRepository<FriendResponse> _FriendResponse;
        private IGenericRepository<InvitedFriend> _InvitedFriend;

        public IGenericRepository<Adjective> Adjective 
        {
            get
            {
                if(_Adjective == null)
                {
                    _Adjective = new GenericRepository<Adjective>(_dbContext);
                }
                return _Adjective;
            }
        }

        public IGenericRepository<Client> Client
        {
            get
            {
                if (_Client == null)
                {
                    _Client = new GenericRepository<Client>(_dbContext);
                }
                return _Client;
            }
        }

        public IGenericRepository<ClientResponse> ClientResponse
        {
            get
            {
                if (_ClientResponse == null)
                {
                    _ClientResponse = new GenericRepository<ClientResponse>(_dbContext);
                }
                return _ClientResponse;
            }
        }

        public IGenericRepository<Friend> Friend
        {
            get
            {
                if (_Friend == null)
                {
                    _Friend = new GenericRepository<Friend>(_dbContext);
                }
                return _Friend;
            }
        }

        public IGenericRepository<FriendResponse> FriendResponse
        {
            get
            {
                if (_FriendResponse == null)
                {
                    _FriendResponse = new GenericRepository<FriendResponse>(_dbContext);
                }
                return _FriendResponse;
            }
        }

        public IGenericRepository<InvitedFriend> InvitedFriend
        {
            get
            {
                if(_InvitedFriend == null)
                {
                    _InvitedFriend = new GenericRepository<InvitedFriend>(_dbContext);
                }
                return _InvitedFriend;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
