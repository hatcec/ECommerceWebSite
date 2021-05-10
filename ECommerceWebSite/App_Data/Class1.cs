using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class Class1
{
	
        public static string GetRandom(int length)
    {
    char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    string image = string.Empty;
    Random random = new Random();

    for (int i = 0; i < length; i++)
    {
    int x = random.Next(1, chars.Length);

    if (!image.Contains(chars.GetValue(x).ToString()))
    image += chars.GetValue(x);
    else
    i=i-1;
    }
    return image;
    }

}
