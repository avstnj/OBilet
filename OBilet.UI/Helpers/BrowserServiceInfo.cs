namespace OBilet.UI.Helpers
{
    public class BrowserServiceInfo
    {
        public static (string, string) GetBrowserInfoFromUserAgent(string? userAgent)
        {
            string browserName = "Unknown";
            string browserVersion = "Unknown";
            if (userAgent == null)
                return (browserName, browserVersion);

            if (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))
            {
                browserName = "Internet Explorer";
                int index = userAgent.IndexOf("MSIE");
                if (index != -1)
                {
                    browserVersion = userAgent.Substring(index + 5, userAgent.IndexOf(';', index) - index - 5).Trim();
                }
                else if ((index = userAgent.IndexOf("rv:")) != -1)
                {
                    browserVersion = userAgent.Substring(index + 3, userAgent.IndexOf(')', index) - index - 3).Trim();
                }
            }
            else if (userAgent.Contains("Edge"))
            {
                browserName = "Microsoft Edge";
                int index = userAgent.IndexOf("Edge");
                if (index != -1)
                {
                    browserVersion = userAgent.Substring(index + 5, userAgent.IndexOf(' ', index) - index - 5).Trim();
                }
            }
            else if (userAgent.Contains("Chrome"))
            {
                browserName = "Chrome";
                int index = userAgent.IndexOf("Chrome");
                if (index != -1)
                {
                    browserVersion = userAgent.Substring(index + 7, userAgent.IndexOf(' ', index) - index - 7).Trim();
                }
            }
            else if (userAgent.Contains("Firefox"))
            {
                browserName = "Firefox";
                int index = userAgent.IndexOf("Firefox");
                if (index != -1)
                {
                    browserVersion = userAgent.Substring(index + 8, userAgent.IndexOf(' ', index) - index - 8).Trim();
                }
            }

            return (browserName, browserVersion);
        }
    }
}
