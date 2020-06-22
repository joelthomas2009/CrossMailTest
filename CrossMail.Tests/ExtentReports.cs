using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AventStack.ExtentReports;

namespace CrossMail.Tests
{
    [Collection("ExtentReports")]
    public class ExtentReports
    {
        public static ExtentReports extent;

        public void ExtentReportTestCase()
        {
            //var htmlReporter = new ExtentHtmlReporter("Sample.html");
            var htmlReporter = new ExtentHtmlReporter("");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);          
        }
    }
}
