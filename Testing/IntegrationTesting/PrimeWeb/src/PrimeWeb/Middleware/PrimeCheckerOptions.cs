﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PrimeWeb.Middleware
{
    public class PrimeCheckerOptions
    {
        public PathString Path { get; set; }
    }
}