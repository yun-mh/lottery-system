using System.Collections.Generic;

namespace LotterySystem
{
    /// <summary>
    /// 等級別の当選者グループの集まりを表すクラス 
    /// </summary>
    public class WinnerGroup : List<Group>
    {
        public List<Group> groupsList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="first">１等グループ</param>
        /// <param name="second">２等グループ</param>
        /// <param name="third">３等グループ</param>
        /// <param name="fourth">４等グループ</param>
        /// <param name="fifth">５等グループ</param>
        public WinnerGroup(Group first, Group second, Group third, Group fourth, Group fifth)
        {
            List<Group> groups = new List<Group>();
            groups.Add(fifth);
            groups.Add(fourth);
            groups.Add(third);
            groups.Add(second);
            groups.Add(first);
            this.groupsList = groups;
        }
    }
}
