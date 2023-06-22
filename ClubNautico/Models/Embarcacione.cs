using System;
using System.Collections.Generic;

namespace ClubNautico.Models;

public partial class Embarcacione
{
    public int Id { get; set; }

    public int NumMatricula { get; set; }

    public string Nombre { get; set; } = null!;

    public string NumAmarre { get; set; } = null!;

    public double Cuota { get; set; }

    public int IdSocio { get; set; }

    public virtual Socio IdSocioNavigation { get; set; } = null!;
}
