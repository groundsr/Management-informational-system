﻿using MIS.DataAccess.Abstractions;
using MSI.Model;
using System;

namespace MIS.BusinessLogic
{
    public class PolicemanService
    {
        private readonly IPolicemanRepository policemanRepository;

        public PolicemanService(IPolicemanRepository policemanRepository)
        {
            this.policemanRepository = policemanRepository;
        }

        public Policeman GetByUserId(string id)
        {
            return policemanRepository.GetByUserId(Guid.Parse(id));
        }
    }
}