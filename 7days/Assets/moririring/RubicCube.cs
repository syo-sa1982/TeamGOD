using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Check3D
{
    public class RubicCube
    {
        //------------------------------------------------------------------
        /// <summary>
        /// 多次元配列をListにして返す
        /// </summary>
        /// <param name="rubiccube"></param>
        /// <returns></returns>
        public List<int> GetListFromArray3(int[,,] array3)
        {
            return array3.Cast<int>().ToList();
        }
        public bool ChangeRubicCube(List<int> before, List<int> after)
        {
            for (int i = 0; i < before.Count; i++)
            {
                if (before[i] == 1)
                {
                    after[i] = 2;
                }
                else
                {
                    after[i] = before[i];
                }
            }
            return true;
        }
        public bool ChangeRubicCubePattern(List<int> before, List<int> after, List<int> pattern)
        {
            for (int i = 0; i < before.Count; i++)
            {
                PatternCheckAndReplace(i, before, after, pattern);
            }
            return true;
        }
        //パターンと箱があっているかチェック
        public bool PatternCheckAndReplace(int index, List<int> before, List<int> after, List<int> pattern)
        {
            //パターンチェック
            for (int i = 0; i < pattern.Count; i++)
            {
                if (before[index + i] != pattern[i])
                {
                    return false;
                }
            }
            //置換
            for (int i = 0; i < pattern.Count; i++)
            {
                if (before[index + i] == pattern[i] && pattern[i] > 0)
                {
                    after[index + i] = 2;
                }
            }
            return true;
        }
    }
}
