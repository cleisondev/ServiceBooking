﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Repositories
{
    public interface IEntity
    {
        Guid UsuarioId { get; set; }
    }
}
