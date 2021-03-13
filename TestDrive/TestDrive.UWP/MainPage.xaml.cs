namespace TestDrive.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TestDrive.App());
        }
    }
}
