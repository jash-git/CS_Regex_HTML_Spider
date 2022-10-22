using System.Text.RegularExpressions;

namespace CS_Regex_HTML_Spider
{
    class Program
    {
        static String Get_Html_stock_d(string data)
        {
            //D<i parameter1="">9</i><span data-char="↓" decimals="2" d="">14.23</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" d="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        static String Get_Html_stock_k(string data)
        {
            //K<i parameter1="">9</i><span data-char="↓" decimals="2" k="">8.90</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" k="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        static String Get_Html_stock_rsi2(string data)
        {
            //RSI<i parameter2="">10</i><span data-char="" decimals="2" rsi2="">20.78</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" rsi2="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        static String Get_Html_stock_rsi1(string data)
        {
            //RSI<i parameter1="">5</i><span data-char="↓" decimals="2" rsi1="">13.90</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" rsi1="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        static String Get_Html_stock_lastQuoteTime(string data)
        {
            //<time class="last-time ml-5" id="lastQuoteTime">2022-10-14 13:30</time>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"id=""lastQuoteTime"">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

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
            string s22 = @"<time class=""last-time ml-5"" id=""lastQuoteTime"">2022-10-14 13:30</time>";
            string s33 = @"RSI<i parameter1="""">5</i><span data-char=""↓"" decimals=""2"" rsi1="""">13.90</span></li>";
            string s44 = @"RSI<i parameter2="""">10</i><span data-char="""" decimals=""2"" rsi2="""">20.78</span></li>";
            string s55 = @"K<i parameter1="""">9</i><span data-char=""↓"" decimals=""2"" k="""">8.90</span></li>";
            string s66 = @"D<i parameter1="""">9</i><span data-char=""↓"" decimals=""2"" d="""">14.23</span></li>";

            string r00 = Get_Html_img_url(s00);
            Console.WriteLine(r00);

            string r11 = Get_Html_a_url(s11);
            Console.WriteLine(r11);

            string r22 = Get_Html_stock_lastQuoteTime(s22);
            Console.WriteLine(r22);

            string r33 = Get_Html_stock_rsi1(s33);
            Console.WriteLine(r33);

            string r44 = Get_Html_stock_rsi2(s44);
            Console.WriteLine(r44);

            string r55 = Get_Html_stock_k(s55);
            Console.WriteLine(r55);

            string r66 = Get_Html_stock_d(s66);
            Console.WriteLine(r66);

            Pause();
        }
    }
}