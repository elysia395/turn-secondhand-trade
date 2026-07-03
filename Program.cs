namespace 转一转校园二手物品交易系统
{
    internal static class Program
    {
        public static int CurrentUserId = 0;
        public static string CurrentUserName = "";
        public static string CurrentUserRole = "";

        // 背景主题：0=经典原版, 1=简约新样式
        public static int BackgroundTheme = 1;
        public static string BackgroundDir => BackgroundTheme switch { 1 => "NewBackgrounds", _ => "Backgrounds" };

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmLogin());
        }
    }
}
