using Infrastructure.Repositories;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ReactionService : BaseEntityService
    {
        private ReactionRepository _reactionRepository = new ReactionRepository();

        public Reaction GetReaction(Guid id)
        {
            return _reactionRepository.GetById(id).Result;
        }

        public IEnumerable<Reaction> GetReactions()
        {
            return _reactionRepository.GetAll().Result;
        }
    }
}
