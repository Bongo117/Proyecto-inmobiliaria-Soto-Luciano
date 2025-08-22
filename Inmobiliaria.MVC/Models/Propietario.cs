using System;
using System.Collections.Generic;

namespace Inmobiliaria.MVC.Models;

public partial class Propietario
{
    public int Id { get; set; }

    public string Dni { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Domicilio { get; set; }

    public bool? Estado { get; set; }
}
