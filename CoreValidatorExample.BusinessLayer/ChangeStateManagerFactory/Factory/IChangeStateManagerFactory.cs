namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public interface IChangeStateManagerFactory<T> where T : class
    {
        public T? ObjectInstance { get; set; }
        public IChangeStateManager<T> GetObjectInstance(int userId, int userCorporateUnitId, int itemId, T obj);

    }


}
