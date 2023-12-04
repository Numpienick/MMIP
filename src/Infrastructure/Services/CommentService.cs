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
    public class CommentService : BaseEntityService
    {
        private readonly CommentRepository _commentRepository = new();

        public void CreateComment(Comment comment)
        {
            try
            {
                _commentRepository.Create(comment);
                if (TempStateContainer.Instance().Comments == null)
                {
                    var comments = _commentRepository.GetAll();
                    TempStateContainer.Instance().Comments = comments.Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Comment GetComment(Guid id)
        {
            return _commentRepository.GetById(id).Result;
        }

        public IEnumerable<Comment> GetComments()
        {
            // TODO: Remove later when state container is not needed anymore.
            if (TempStateContainer.Instance().Comments == null)
            {
                var comments = _commentRepository.GetAll();
                TempStateContainer.Instance().Comments = comments.Result;
            }

            return TempStateContainer.Instance().Comments;

            //return _commentRepository.GetAll().Result;
        }
    }
}
