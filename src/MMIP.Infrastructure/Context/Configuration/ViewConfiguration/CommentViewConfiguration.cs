using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Infrastructure.Migrations;
using MMIP.Shared.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMIP.Infrastructure.Context.Configuration.ViewConfiguration
{
    internal class CommentViewConfiguration : IEntityTypeConfiguration<CommentView>
    {
        public void Configure(EntityTypeBuilder<CommentView> builder)
        {
            builder.ToView("comment_view").HasNoKey();
        }
    }
}
