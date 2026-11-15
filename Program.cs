namespace Club1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using FormLoginAndDbConnection login = new FormLoginAndDbConnection();
            if (login.ShowDialog() != DialogResult.OK || login.UsuarioAutenticadoId <= 0)
            {
                return;
            }

            Club club = new Club();
            Application.Run(new formMain(club, login.UsuarioAutenticadoId));
        }
    }
}