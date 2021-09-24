namespace Compact_RAM_Cleaner
{
    public static class Popup
    {
        public static string NotifyText = "";
        public static void Show(string text)
        {
            NotifyText = text;
            new Notify().Show();
        }
    }
}
