﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Net
{
    public class VMLocator
    {
        public static MainViewModel MainVM { get; set; } = new MainViewModel();
    }
}