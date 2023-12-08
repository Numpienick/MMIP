using MMIP.Shared.Entities;
using MMIP.Shared.Enums;

namespace MMIP.Infrastructure.Repositories
{
    public class CommentRepository : BaseEntityRepository<Comment>
    {
        private List<Comment> _comments = new();

        public override void Create(Comment comment)
        {
            _comments.Add(comment);
        }

        public override void Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public override async Task<IQueryable<Comment>> GetAll()
        {
            IQueryable<Comment> comments;

            Comment comment = new Comment();
            comment.CommentType = CommentType.Participation;
            comment.Concluded = false;
            comment.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            _comments.Add(comment);

            Comment comment2 = new Comment();
            comment2.CommentType = CommentType.Feedback;
            comment2.Concluded = true;
            comment2.Text =
                "Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND! Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND! Dit is even een iets langere reactie. Deze reactie gaat over het testen van een lange reactie die veel tekst bevat. Is dat niet even leuk en gezellig? MAND!";
            _comments.Add(comment2);

            Comment comment3 = new Comment();
            comment3.CommentType = CommentType.Question;
            comment3.Concluded = false;
            comment3.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            _comments.Add(comment3);

            Comment comment4 = new Comment();
            comment4.CommentType = CommentType.Idea;
            comment4.Concluded = false;
            comment4.Text =
                "Dit is een reactie. Ik wil kaas. Ik hou van mandjes. Ik shop altijd bij de lijdel";
            _comments.Add(comment4);

            comments = _comments.AsQueryable();
            return comments;
        }

        public override Task<IQueryable<Comment>> GetAllReadonly()
        {
            throw new NotImplementedException();
        }

        public override async Task<Comment> GetById(Guid id)
        {
            var comments = GetAll();
            return comments.Result.FirstOrDefault();
        }

        public override Task<Comment> GetReadonlyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
