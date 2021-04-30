﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Configuration
{
    public class ApplicationConfig
    {
        public TypeOfEnvironment Environment { get; set; }
        public TypeOfDatabase DatabaseType { get; set; }
        public string ConnectionString { get; set; }
    }
}
