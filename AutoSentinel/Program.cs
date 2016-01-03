using EloBuddy.SDK.Events;

namespace AutoSentinel
{
    class Program
    {
        private static void Main(string[] args)
        {
           Loading.OnLoadingComplete += initialize.OnLoadingComplete;
        }
    }
}
