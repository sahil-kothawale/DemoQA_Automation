using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using Reqnroll;

namespace DemoQA_Automation.Helpers
{
    [Binding]
    internal class TestRunHooks : BrowserDriver
    {
        private static ExtentTest featureNode = null!;
        private static ExtentTest scenarioTest = null!;

        [BeforeTestRun]
        internal static void BeforeTestRun()
        {
            ExtentReportHelper.InitiaizeReport();
        }

        [BeforeFeature]
        internal static void BeforeFeature(FeatureContext featureContext) 
        {
            string featureName = featureContext.FeatureInfo.Title;
            featureNode = ExtentReportHelper.CreateFeature(featureName);
        }

        [BeforeScenario]
        internal static void BeforeScenario(ScenarioContext scenarioContext)
        {
            string scenarioName = scenarioContext.ScenarioInfo.Title;
            scenarioTest = ExtentReportHelper.CreateScenarioNodeForFeature(featureNode, scenarioName);
        }

        [AfterStep]
        internal static void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepDetails = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                ExtentReportHelper.Pass(scenarioTest, stepType, stepDetails);
            }
            else
            {
                ExtentReportHelper.Fail(scenarioTest, stepType, stepDetails, MarkupHelper.CreateCodeBlock(scenarioContext.TestError.Message));
            }
        }

        [AfterScenario]
        internal static void AfterScenario()
        {
            driver.Quit();
        }

        [AfterScenario]
        internal static void AfterTestRun()
        {
            ExtentReportHelper.FlushReport();
        }
    }
}
