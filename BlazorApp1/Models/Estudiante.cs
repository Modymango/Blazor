using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
[Table("estudiante")]
public class Estudiante : BaseModel
{
    [Column("nombre")]
    public string? nombre { get; set; }

    [Column("carrera")]
    public string? carrera { get; set; }

}