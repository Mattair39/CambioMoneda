using CambioMoneda.Repositorios;

namespace CambioMoneda
{
    public partial class App : Application
    {
        public static ChuckNorrisRespositorio ChuckRepo { get; private set; }

        public App(ChuckNorrisRespositorio repo)
        {
            InitializeComponent();

            MainPage = new AppShell();
            ChuckRepo = repo;
        }
    }
}
