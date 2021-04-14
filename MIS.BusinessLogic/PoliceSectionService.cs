﻿using MIS.DataAccess.Abstractions;
using MSI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIS.BusinessLogic
{
    public class PoliceSectionService
    {
        private readonly IPoliceSectionRepository policeStationRepository;

        public PoliceSectionService(IPoliceSectionRepository policeStationRepository)
        {
            this.policeStationRepository = policeStationRepository;
        }

        public IEnumerable<PoliceSection> GetAll()
        {
            return policeStationRepository.GetAll();
        }

        public void Add(PoliceSection policeSection)
        {
            policeStationRepository.Add(policeSection);
        }

        public void Update(PoliceSection policeSection)
        {
            policeStationRepository.Update(policeSection);
        }

        public PoliceSection Get(Guid id)
        {
            return policeStationRepository.Get(id);
        }

        public void Delete(Guid id)
        {
            var policeStation =  policeStationRepository.Get(id);
            policeStation.Policemen.Clear();
            Update(policeStation);
            
            policeStationRepository.Remove(id);
        }



    }
}