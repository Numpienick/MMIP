using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMIP.Shared.Views
{
    public class CommentView
    {
        public Guid CommentId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Text { get; set; } = null!;
        public bool Concluded { get; set; }
        public string CommentTypeName { get; set; } = null!;
        public string CommentTypeDescription { get; set; } = null!;
        public string CommentTypeIconPath { get; set; } = null!;
    }
}
