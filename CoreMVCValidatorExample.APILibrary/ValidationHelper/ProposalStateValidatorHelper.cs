using System.Dynamic;
using CoreValidatorExample.APILibrary.Data;

namespace CoreValidatorExample.APILibrary.Data
{
    public class ProposalStateValidatorHelper : IStateValidator<ProposalChangeStateSvcRequest>
    {
        private ProposalChangeStateSvcRequest _request;

        public ProposalStateValidatorHelper(ProposalChangeStateSvcRequest request)
        {
            _request = request;
        }

        public WFValidationResult<ProposalChangeStateSvcRequest> ValidateSimple(ProposalChangeStateSvcRequest obj)
        {
            //simulate true
            WFValidationResult<ProposalChangeStateSvcRequest> result = new WFValidationResult<ProposalChangeStateSvcRequest>(obj);
            result.MessageList = new List<WFValidationMessage>();



            switch (_request.ActionName)
            {
                case 1:
                    result.IsSuccess = ValidateStateTransfer1(_request);
                    break;
                case 2:
                    result.IsSuccess = InValidationProposalValidatedInTreatment(_request);
                    break;

            }
            return result;
        }

        //public WFValidationResult Validate()
        //{
        //    //simulate true
        //    WFValidationResult result = new WFValidationResult();
        //    result.MessageList = new List<WFValidationMessage>();



        //    switch (_request.ActionName)
        //    {
        //        case 1:
        //            result.IsSuccess = ValidateStateTransfer1(_request);
        //            break;
        //        case 2:
        //            result.IsSuccess = InValidationProposalValidatedInTreatment(_request);
        //            break;

        //    }
        //    return result;
        //}
        /// <summary>
        /// WF Proposta - Regras validação: 206 Em Validação (Proposta Validada) > Em Produção MP
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool InValidationProposalValidatedInTreatment(ProposalChangeStateSvcRequest request)
        {
            int businessLogicValue = 0;
            bool result = false;
            //Checklist de documentos (obrigatórios para a validação) todos OK
            result = VerifyIfDocumentsAreValid();
            //Critérios / Cálculos para validação da proposta dentro dos limites previstos nas Regras de flexibilidade e condicionalismos informados
            FlexibilityRulesValidator flexibilityRulesValidator = new FlexibilityRulesValidator();
            result = flexibilityRulesValidator.ValidateFlexibilityRules();

            //Regras para correta constituição de Garantias Hipotecárias/reais/financeiras
            //Validade do despacho

            //Emissão da FINE de Aprovação e da Carta de Aprovação
            result = VerifyIfFINEWasPublished();                      
            
            businessLogicValue = CallServiceA(request);
            if (businessLogicValue == 0)
            {
                result = businessLogicValue == 1;
            }
            return result;
        }

        private bool VerifyIfDocumentsAreValid()
        {
            throw new NotImplementedException();
        }

        private bool VerifyIfFINEWasPublished()
        {
            throw new NotImplementedException();
        }

        private bool ValidateStateTransfer1(ProposalChangeStateSvcRequest request)
        {
            int businessLogicValue = 0;
            bool result = false;
            
            businessLogicValue = CallServiceB(request);
            if (businessLogicValue == 0)
            {
                result = businessLogicValue == 2;
            }
            
            return result;
        }

        private int CallServiceA(ProposalChangeStateSvcRequest request)
        {
            //simulate service call
            return 1;
        }

        private int CallServiceB(ProposalChangeStateSvcRequest request)
        {
            //simulate service call
            return 2;
        }

    }
}
