﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Categoria: BaseEntity
{
    // public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
