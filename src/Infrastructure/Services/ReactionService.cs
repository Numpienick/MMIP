using Infrastructure.Repositories;
using Shared.Entities;
using Shared.StateContainers;
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

        public void CreateReaction(Reaction reaction)
        {
            try
            {
                _reactionRepository.Create(reaction);
                if (TempStateContainer.Instance().Reactions == null)
                {
                    var reactions = _reactionRepository.GetAll();
                    TempStateContainer.Instance().Reactions = reactions.Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Reaction GetReaction(Guid id)
        {
            return _reactionRepository.GetById(id).Result;
        }

        public IEnumerable<Reaction> GetReactions()
        {
            // TODO: Remove later when state container is not needed anymore.
            if (TempStateContainer.Instance().Reactions == null)
            {
                var reactions = _reactionRepository.GetAll();
                TempStateContainer.Instance().Reactions = reactions.Result;
            }

            return TempStateContainer.Instance().Reactions;

            //return _reactionRepository.GetAll().Result;
        }
    }
}
