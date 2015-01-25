using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets;
using UnityEngine;

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
        public List<GameObject> GetListFromArray3(GameObject[, ,] array3)
        {
            return array3.Cast<GameObject>().ToList();
        }
        public bool ChangeRubicCubePattern(List<GameObject> before, int bx, int by, int bz, List<Gui.AfterData> after, PatternData pattern)
        {
            for (int i = 0; i < before.Count; i++)
            {
                PatternCheckAndReplace(i, before, bx, by, bz, after, pattern);
            }
            return true;
        }
        //パターンと箱があっているかチェック
        private bool PatternCheckAndReplace(int idx, List<GameObject> before, int bx, int by, int bz, List<Gui.AfterData> after, PatternData pattern)
        {
            //パターンチェック
            if (!PatternCheck(0, idx, before, bx, by, bz, after, pattern)) return false;
            PatternCheck(1, idx, before, bx, by, bz, after, pattern);
            return true;
        }

        private static bool PatternCheck(int type, int idx, List<GameObject> before, int bx, int by, int bz, List<Gui.AfterData> after, PatternData pattern)
        {
            for (int j = 0; j < pattern.y; j++)
            {
                for (int k = 0; k < pattern.z; k++)
                {
                    for (int i = 0; i < pattern.x; i++)
                    {
                        var bidx = idx + i + k*bx + j*bx*bz;
                        if (pattern.PaternArray[i, j, k] != "")
                        {
                            if (before[bidx] == null) return false;
                            if (!before[bidx].name.Contains(pattern.PaternArray[i, j, k])) return false;
                            if (type == 1)
                            {
                                //名前にcloneがはいってしまう
                                after[bidx].name = before[bidx].name;
                                after[bidx].position = before[bidx].transform.position;
                                if (pattern.OneCheck) return true;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
