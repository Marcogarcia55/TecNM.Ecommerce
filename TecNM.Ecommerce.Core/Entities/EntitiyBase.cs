namespace TecNM.Ecommerce.Core.Entities;
public class EntitiyBase
{
    public int Id { get; set; }
    public Boolean IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    
}

