﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGroupTeamRepository
    {
        Task<List<GroupTeam>> GetList();
    }
}
