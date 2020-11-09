namespace TestProject1.Helpers
{
    public class HelperBase
    {
        protected ApplicationManager ApplicationManager { get; set; }

        public HelperBase(ApplicationManager applicationManager)
        {
            ApplicationManager = applicationManager;
        }
    }
}