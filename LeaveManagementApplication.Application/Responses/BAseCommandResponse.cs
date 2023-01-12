﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementApplication.Application.Responses
{
    public class BAseCommandResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }

        public List<string> Error { get; set; }

    }
}