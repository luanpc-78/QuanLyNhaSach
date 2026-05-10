namespace QuanLyNhaSach
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration .
            ApplicationConfiguration.Initialize();

            // Chạy Form Login trước, sau đó mở Form chính nếu đăng nhập thành công
            Application.Run(new FormLogin());
        }
    }
}