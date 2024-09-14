namespace CoreValidatorExample.APILibrary.Data
{
    public abstract class SvcRequestBase
    {
        public int UserId { get; set; }
        public int UserCorporateUnitId { get; set; }
        public int ActionName { get; set; }
      
    }
}
