﻿using ShoppingVilla.Data.Data;
using ShoppingVilla.Data.Entities.Interface;
using ShoppingVilla.Data.Entities.Interface.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IUserRegisterRepository userRegisterRepository { get; private set; }

        public IUserLoginRepository userLoginRepository { get; private set; }

        public IRoleRepository roleRepository { get; private set; }

        public IModuleRepository moduleRepository { get; private set; }

        public IMenuRepository menuRepository { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;         
            userRegisterRepository = new UserRegisterRepository(_context);
            userLoginRepository = new UserLoginRepository(_context);
            roleRepository = new RoleRepository(_context);
            moduleRepository = new ModuleRepository(_context);
            menuRepository = new MenuRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
