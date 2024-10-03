namespace CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data
{
    public sealed class ValidationMessageFacConcept
    {
        public string Message { get; internal set; }
        public bool Warning { get; internal set; }

        //Only allow creation internally or by ValidationResultFacConcept class.
        internal ValidationMessageFacConcept()
        {
        }
    }

    
}
