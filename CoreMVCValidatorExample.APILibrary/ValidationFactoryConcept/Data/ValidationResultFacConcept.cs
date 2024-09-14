namespace CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data
{
    public sealed class ValidationResultFacConcept
    {
        private bool _dirty = true;
        private bool _valid;

        public bool Valid
        {
            get
            {
                //theoretically O(n) time but in pratice will be constant time
                //Still, no need for multiple traversals, Traverse only if it's changed
                if (_dirty)
                {
                    _valid = Messages.FirstOrDefault(msg => msg.Warning == false) == null;
                    _dirty = false;
                }

                return _valid;
            }
        }

        public ValidationResultFacConcept()
        {
            Messages = new List<ValidationMessageFacConcept>();
        }

        public IList<ValidationMessageFacConcept> Messages { get; internal set; }

        /// <summary>
        /// Adds the error. 
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void AddError(string errorMessage)
        {
            _dirty = true;
            Messages.Add(new ValidationMessageFacConcept { Message = errorMessage });
        }

        /// <summary>
        /// Adds the warning. 
        /// </summary>
        /// <param name="warningMessage">The warning message.</param>
        public void AddWarning(string warningMessage)
        {
            //No need to mark collection dirty since warnings never generate validation changes
            Messages.Add(new ValidationMessageFacConcept { Message = warningMessage, Warning = true });
        }
    }

}
