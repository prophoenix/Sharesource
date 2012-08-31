using  PnxSmartWDA.MvvmCross.Platform.Diagnostics;

namespace SmartDevice.Core
{
    public static class PnxSmartWDATrace
    {
        public const string Tag = "CustomerManagement";

        public static void Trace(string message, params object[] args)
        {
            MvxTrace.TaggedTrace(Tag, message, args);
        }
    }
}
