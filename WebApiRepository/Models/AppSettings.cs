﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRepository.Models
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string Secret { get; set; }
    }
}
