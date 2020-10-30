using System;

namespace LotterySystem
{
    /// <summary>
    /// 個別の応募者を表すクラス
    /// </summary>
    public class Applicant : IComparable<Applicant>
    {
        // 応募者番号
        public string number { get; set; }

        // 応募者名
        public string name { get; set; }

        // 応募者を応募者番号の昇順で整列するためのメソッド
        public int CompareTo(Applicant counterpart)
        {
            return this.number.CompareTo(counterpart.number);
        }
    }
}
