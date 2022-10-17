using System.Text.RegularExpressions;

namespace CS_Regex_HTML_Spider
{
    class Program
    {

        static String Get_Html_a_url(string data)
        {
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"<a href=""(([\s\S])*?)""");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                StrResult = match.Value;
                StrResult = StrResult.Replace("<a href=", "");
                StrResult = StrResult.Replace("\"", "");
            }

            return StrResult;
        }

        static String Get_Html_img_url(string data)
        {
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"<img src=""(([\s\S])*?)""");           


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                StrResult = match.Value;
                StrResult = StrResult.Replace("<img src=", "");
                StrResult = StrResult.Replace("\"", "");
            }

            return StrResult;
        }
        static void Pause()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void Main(string[] args)
        {
            string s00 = @"<img src=""https://example.com/media/photo.jpg"" with=""600"" heigh=""400"" alt=""一張圖片"">";
            string s11 = @"<a href=""https://www.baidu.com"" rel=""nofollow"">链接标签</a>"; 
            
            string r00 = Get_Html_img_url(s00);
            Console.WriteLine(r00);

            string r11 = Get_Html_a_url(s11);
            Console.WriteLine(r11);
            Pause();
        }
    }
}