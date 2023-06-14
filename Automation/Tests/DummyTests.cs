//using JMSeleniumExcercise.CommonObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using UIDMain = Automation.UI_Decernis_Main;

namespace Automation.Tests
{
    [TestFixture]
    public class Dummy : BaseProjectSettings
    {
        //>║·SYNOPSIS·╠═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════─
        //DummyTestForTestingDummyTests: A test for testing.
        //>║·SYNOPSIS·╠═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════─

        #region SetUp & TearDown
        //[SetUp]
        //public void Initialize()
        //{
        //    //Start session.
        //    StartUp();
        //}

        //[TearDown]
        //public void Dismantle()
        //{
        //    //End session.
        //    CloseDown();
        //}
        #endregion


        [Test]//>This is a dummy test useful for testing individual blocks of code
        public void DummyTestForTestingDummyTests()
        {
            //>MD5 comparison of two files.
            MD5FileCompare(UIDMain.gComplyPlusLandscapeFileXLS1, UIDMain.gComplyPlusLandscapeFileXLS1Copy);

            //string file1 = UIDMain.gComplyPlusLandscapeFileXLS1;
            //string file2 = UIDMain.gComplyPlusLandscapeFileXLS2;

            ////Convert file to FileInfo.
            //var sourceFile1 = Path.Combine(downloadDirectory, file1);
            //FileInfo downloadFile1 = new FileInfo(sourceFile1);

            //var sourceFile2 = Path.Combine(downloadDirectory, file2);
            //FileInfo downloadFile2 = new FileInfo(sourceFile2);

            ////Compare files.
            //Assert.IsTrue(FileMD5AreSame(downloadFile1, downloadFile2));




        }

    }
}