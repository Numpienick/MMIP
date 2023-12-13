using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMIP.Infrastructure.Services
{
    public class PhaseService : BaseEntityService<Phase>
    {
        private readonly IDataRepository<Phase> _repository;

        public PhaseService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = unitOfWork.Repository<Phase>();
        }
    }
}
