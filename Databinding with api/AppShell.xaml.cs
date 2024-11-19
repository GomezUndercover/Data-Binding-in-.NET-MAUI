namespace Databinding_with_api
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FormPage), typeof(FormPage));
        }
    }
}
