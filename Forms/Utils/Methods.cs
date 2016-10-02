namespace Forms.Utils
{
    public static class Methods
    {
        public static void Lock(this System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
        public static void Free(this System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
