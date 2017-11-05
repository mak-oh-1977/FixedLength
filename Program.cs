using System;
using System.Text;
using Utils;

namespace FixedLength
{
    [FixedText(Encode = "Shift_JIS")]
    public class Todofuken
    {
        /// <summary>
        /// 都道府県コード
        /// </summary>
        [Fixed(ByteLength = 2)]
        public int Code { set; get; }

        /// <summary>
        /// 都道府県名
        /// </summary>
        [Fixed(ByteLength = 10)]
        public string Name { set; get; }

        /// <summary>
        /// 県庁所在地
        /// </summary>
        public string Capital { set; get; }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var a = new Todofuken();
            a.Code = 1;
            a.Name = "北海道";
            a.Capital = "札幌市";

            //固定長バイトデータを出力する
            var by = FixedTextAttribute.Convert2FixedText<Todofuken>(a);

            var o = (Todofuken)FixedTextAttribute.Convert2Object<Todofuken>(by, by.Length);

            var s = FixedTextAttribute.GetEncoding<Todofuken>().GetString(by);
            Console.WriteLine(s);

            Console.WriteLine("code=" + o.Code + ":Name=" + o.Name + ":Capital=" + o.Capital);

        }
    }

}
