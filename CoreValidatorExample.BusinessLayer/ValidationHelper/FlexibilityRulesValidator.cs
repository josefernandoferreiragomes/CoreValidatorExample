namespace CoreValidatorExample.BusinessLayer.Data
{
    /// <summary>
    /// FlexibilityRulesValidator
    /// </summary>
    public class FlexibilityRulesValidator
    {

        public FlexibilityRulesValidator() { }

        public bool ValidateFlexibilityRules()
        {
            bool result = false;
            result = ValidateDC();
            result = ValidateDSTI();
            result = ValidateLTV();
            result = ValidateNR();
            result = ValidateTE();
            return result;
        }

        /* Regras de Flexibilidade:*/
        
        /// <summary>
        /// //'1 - DSTI (Debt Service to Income) - não ocorre uma variação positiva superior 3 pontos percentuais, condicionado a que a regra se aplique unicamente dentro do intervalo de decisão/aprovação da proposta original (0-50%, ou 50-60%, ou > 60%);
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool ValidateDC()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// //'2 - NR (Nível de Risco/Scoring) - não se verifica um agravamento do risco superior a 1 nível e que não é ultrapassado o limite standard definido na delegação de competências (OS 26/2018), atualmente de 7, nem ocorre alteração do escalão de decisão por limite de montante;
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool ValidateDSTI()
        {
            throw new NotImplementedException();
        }

        
        /// <summary>
        /// //'3 - LTV (Loan to Value) - não se verifica uma variação positiva superior 3 pontos percentuais, e que se mantém dentro dos limites standard definidos na delegação de competências (OS 26/2018);
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool ValidateLTV()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// //'4 - TE (Taxa Esforço) - não se verifica uma variação positiva superior 3 pontos percentuais, com limite de 40%;
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool ValidateNR()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// //'5 - Despacho Caducado - Ainda que se verifique a caducidade do despacho mas não tenha decorrido mais de 30 dias sobre o seu termo e desde que não se verifique degradação das condições aprovadas na data da emissão da Carta de Aprovação, permitir às operações de CH prosseguir para a formalização de escritura sempre que os processos estejam concluídos e com data de escritura agendada.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool ValidateTE()
        {
            throw new NotImplementedException();
        }
    }
}