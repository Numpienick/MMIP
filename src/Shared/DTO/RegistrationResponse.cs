﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class RegistrationResponse
    {
        public bool SuccesfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
