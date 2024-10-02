using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;

namespace CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Validators
{
    public class PersonValidatorWithFactory : Interfaces.IValidatorFacConcept<PersonExample>
    {
        #region Implementation of IValidation<Person>

        public ValidationResultFacConcept Validate(PersonExample person)
        {
            return Validate(person, false);
        }

        public ValidationResultFacConcept Validate(PersonExample person, bool suppressWarnings)
        {
            var result = new ValidationResultFacConcept();

            //This code here would be replaced with a validation rules engine later

            if (person != null)
            {


                if (person != null)
                {
                    if (string.IsNullOrEmpty(person.FirstName))
                        result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample FirstName is required." });
                    if (string.IsNullOrEmpty(person.LastName))
                        result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample LastName is required." });
                }
                else
                    result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample data is missing." });
            }
            else
                result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample data is missing." });

            return result;
        }

        #endregion
    }


}
