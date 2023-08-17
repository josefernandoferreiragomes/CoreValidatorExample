namespace CoreMVCValidatorExample.APILibrary.ValidationFactoryConcept
{
    public static class CustomObjectFactory
    {
        //internal static IValidatorWithFactory<T> GetObjectInstance(T obj)
        //{
        //    return (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(EmployeeValidatorWithFactory));//<T>(typeof(ProposalStateValidatorHelper));
        //}

        public static IValidatorWithFactory<T> GetObjectInstance<T>()
        {
            IValidatorWithFactory<T>? objInstance = Activator.CreateInstance(typeof(EmployeeValidatorWithFactory)) as IValidatorWithFactory<T>;
            switch (typeof(T).Name)
            {
                case "EmployeeWithFactory":
                    objInstance = (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(EmployeeValidatorWithFactory));
                    break;
                case "PersonWithFactory":
                    objInstance = (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(PersonValidatorWithFactory));
                    break;
            }
            return objInstance;
        }
    }

    //snippets

    //ForRequestedType<IValidatorWithFactory<EmployeeWithFactory>>().TheDefaultIsConcreteType<EmployeeValidatorWithFactory>();


    //public void InvalidEmployeeTest()
    //{
    //    var person = new EmployeeWithFactory { PersonWithFactory = new PersonWithFactory { FirstName = string.Empty, LastName = string.Empty } };

    //    var results = ValidationFactory.Validate(person);

    //    Assert.IsNotNull(results);
    //    Assert.IsFalse(results.Valid);
    //    Assert.IsTrue(results.Messages.Count > 0);
    //}

    //public bool SaveEmployee()
    //{
    //    var person = View.EmployeeWithFactory;

    //    var results = ValidationFactory.Validate(person);

    //    if (results.Valid)
    //        _controller.SaveEmployee(person);
    //    else
    //        View.Errors = results.Messages;
    //}


    //internal class CustomObjectFactory
    //{
    //    internal static IValidatorWithFactory<T> GetObjectInstance<T>(T obj)
    //    {
    //        return (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(ProposalStateValidatorHelper), true, obj);//<T>(typeof(ProposalStateValidatorHelper));
    //    }
    //}

    //public static class ValidatorFactory
    //{
    //public static T CreateValidator<T>( obj) where T : class
    //{
    //    return Activator.CreateInstance<T>(obj);
    //}
    //public static T Validate<T>(T obj) where T : class
    //{
    //    //ValidationResultWithFactory validationResult = new ValidationResultWithFactory();

    //    switch ((typeof(T)).Name )
    //    {
    //        case "ProposalSvcRequest":
    //            return Activator.CreateInstance<T>();
    //            //validationResult = validator.Validate(obj);
    //            break;
    //        case "DecisionSvcRequest":
    //            var validator2 = Activator.CreateInstance<DecisionStateValidatorHelper>();
    //            //validationResult = validator2.Validate(obj);
    //            break;

    //    }

    //    //return validationResult;
    //    return T;
    //}
    //}
}
