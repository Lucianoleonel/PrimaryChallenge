﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary.Infrastructure.Abstractions
{
    public interface IRepository<T> : ICrud<T>
    {
    }
}
