﻿using System;
using System.Collections.Generic;

namespace personapi_dotnet.Models.Entities;

public partial class Estudio
{
    public int IdProf { get; set; }

    public int CcPer { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Univer { get; set; }

    public virtual Persona CcPerNavigation { get; set; } = null!;

    public virtual Profesión IdProfNavigation { get; set; } = null!;
}
