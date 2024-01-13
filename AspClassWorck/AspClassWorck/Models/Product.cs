namespace AspClassWorck.Models
{
    public class Product : BaseModel
    {
        public int Cost { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public int Price { get; set; }
        public virtual List<Storage>? Storeges { get; set; }

    }
}
