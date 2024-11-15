using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility;

namespace CoreValidatorExample.BusinessLayer.Tests.Unit
{    
    [TestFixture]
    public class ProposalChangeStateManagerChainTests
    {
        private ProposalChangeStateManager _changeStateManager;

        [SetUp]
        public void Setup()
        {
            _changeStateManager = new ProposalChangeStateManager();
        }

        //TO BE IMPLEMENTED
    }    

}
