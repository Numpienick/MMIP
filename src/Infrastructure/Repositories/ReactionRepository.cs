using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class ReactionRepository : BaseEntityRepository<Reaction>
    {
        public override void Create(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        public override async Task<IQueryable<Reaction>> GetAll()
        {
            IQueryable<Reaction> reactions;
            List<Reaction> list = new List<Reaction>();

            Reaction reaction = new Reaction();
            reaction.ReactionType = ReactionType.Participate();
            reaction.Concluded = false;
            reaction.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            list.Add(reaction);

            Reaction reaction2 = new Reaction();
            reaction2.ReactionType = ReactionType.Feedback();
            reaction2.Concluded = false;
            reaction2.Text =
                "Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND! Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND! Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND!";
            list.Add(reaction2);

            Reaction reaction3 = new Reaction();
            reaction3.ReactionType = ReactionType.Question();
            reaction3.Concluded = false;
            reaction3.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            list.Add(reaction3);

            Reaction reaction4 = new Reaction();
            reaction4.ReactionType = ReactionType.Idea();
            reaction4.Concluded = false;
            reaction4.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            list.Add(reaction4);

            reactions = list.AsQueryable();
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
