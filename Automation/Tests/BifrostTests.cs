using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using UIDMain = Automation.UI_Decernis_Main;

namespace Automation.Tests
{
    [TestFixture]
    public  class BifrostTests : BaseProjectSettings
    {
        //>║·SYNOPSIS·╠═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════─
        //Bifrost_Document_Upload_Success: A test to verify that a document can be uploaded to ElasticSearch and transition to correct status for itself and its files
        //>║·SYNOPSIS·╠═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════─

        #region SetUp & TearDown
        [SetUp]
        public void Initialize()
        {
            //Start session.
            StartUp();
        }

        [TearDown]
        public void Dismantle()
        {
            //End session.
            CloseDown();
        }
        #endregion

        [Test]//>WIP---
        public void Bifrost_Document_Upload_Success() //~ID 50364
        {
            //>TDD pseudocode-----------------

            //>General note: this test needs to cover 7 instances of file status mix and match cases. the test for these will likely be very similar with only certain specific assertions or interactions being unique.

            //navigate to location where document can be identified/located

            //assert/record beginning status of document and its files (DB query?). document should be in a pre R_DONE state and its files have a NULL file_status

            //Update the document so that processing may begin

            //may need to assert certain stages in this process. currently unknown

            //assert document state transition to R_DONE after update/processing is complete

            //assert correct file status transition from NULL to correct status (e.g. F_EXPERT_ES). it seems like this status is a default transitionary state, however, acceptance criteria dictates that two other status also be compataible

            //navigate to elastic search and identify document

            //assert document is accessible via elastic search UI as search criteria. (this might also require DB assertions to be thorough)

            //>these steps above will be reused to test each file state mixture with the end result being largely the same - a document and its files enter correct states and are available in elastic search

        }

    }
}