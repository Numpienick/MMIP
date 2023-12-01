using Shared.Entities;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class ReactionRepository : BaseEntityRepository<Reaction>
    {
        private List<Reaction> _reactions = new();

        public override void Create(Reaction reaction)
        {
            _reactions.Add(reaction);
        }

        public override void Delete(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        public override async Task<IQueryable<Reaction>> GetAll()
        {
            IQueryable<Reaction> reactions;

            Reaction reaction = new Reaction();
            reaction.ReactionType = ReactionType.Participation;
            reaction.Concluded = false;
            reaction.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            _reactions.Add(reaction);

            Reaction reaction2 = new Reaction();
            reaction2.ReactionType = ReactionType.Feedback;
            reaction2.Concluded = true;
            reaction2.Text =
                "Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND! Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND! Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND!";
            _reactions.Add(reaction2);

            Reaction reaction3 = new Reaction();
            reaction3.ReactionType = ReactionType.Question;
            reaction3.Concluded = false;
            reaction3.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            _reactions.Add(reaction3);

            Reaction reaction4 = new Reaction();
            reaction4.ReactionType = ReactionType.Idea;
            reaction4.Concluded = false;
            reaction4.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            _reactions.Add(reaction4);

            reactions = _reactions.AsQueryable();
            return reactions;
        }

        public override Task<IQueryable<Reaction>> GetAllReadonly()
        {
            throw new NotImplementedException();
        }

        public override async Task<Reaction> GetById(Guid id)
        {
            var reactions = GetAll();
            return reactions.Result.FirstOrDefault();
        }

        public override Task<Reaction> GetReadonlyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Reaction reaction)
        {
            throw new NotImplementedException();
        }
    }
}
