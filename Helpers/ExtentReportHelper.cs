using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;

namespace DemoQA_Automation.Helpers
{
    internal class ExtentReportHelper
    {
        private static ExtentReports extentReport = null!;

        internal static void InitiaizeReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Report.html");
            ExtentSparkReporter reporter = new ExtentSparkReporter(path);
            extentReport = new ExtentReports();
            extentReport.AttachReporter(reporter);
        }

        internal static ExtentTest CreateFeature(string featureName)
        {
            return extentReport.CreateTest(new GherkinKeyword("Feature"), featureName);
        }

        internal static ExtentTest CreateScenarioNodeForFeature(ExtentTest featureNode, string scenarioName)
        {
            return featureNode.CreateNode(new GherkinKeyword("Scenario"), scenarioName);
        }

        internal static void LogInfo(ExtentTest test, string stepDetails)
        {
            test.Info(stepDetails);
        }

        internal static void Pass(ExtentTest test, string stepType, string stepDetails)
        {
            test.CreateNode(new GherkinKeyword(stepType.ToString()), stepDetails);
        }

        internal static void Fail(ExtentTest test, string stepType, string stepDetails, IMarkup testError)
        {
            test.CreateNode(new GherkinKeyword(stepType.ToString()), stepDetails).Fail(testError);
        }

        internal static void Skip(ExtentTest test, string stepDetails)
        {
            test.Skip(stepDetails);
        }

        internal static void Warning(ExtentTest test, string stepDetails)
        {
            test.Warning(stepDetails);
        }

        internal static void FlushReport()
        {
            extentReport.Flush();
        }
    }
}
