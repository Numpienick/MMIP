﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public interface IProfile
    {
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string AvatarPath { get; set; }

        public string[] GetTags();
    }
}
