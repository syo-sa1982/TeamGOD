using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        //public bool ChangeRubicCube(List<GameObject> before, List<string> after)
        //{
        //    for (int i = 0; i < before.Count; i++)
        //    {
        //        if (before[i].tag.Contains("block") )
        //        {
        //            after[i].tag = "Palm_small";
        //        }
        //    }
        //    return true;
        //}
        public bool ChangeRubicCubePattern(List<GameObject> before, int bx, int by, int bz, List<Gui.AfterData> after, int ax, int ay, int az, Gui.PatternData pattern)
        {
            for (int i = 0; i < before.Count; i++)
            {
                PatternCheckAndReplace(i, before, bx, by, bz, after, ax, ay, az, pattern);
            }
            return true;
        }
        //パターンと箱があっているかチェック
        private bool PatternCheckAndReplace(int idx, List<GameObject> before, int bx, int by, int bz, List<Gui.AfterData> after, int ax, int ay, int az, Gui.PatternData pattern)
        {
            //パターンチェック
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

                        }

                    }
                }
            }
            //生成
            for (int j = 0; j < pattern.y; j++)
            {
                for (int k = 0; k < pattern.z; k++)
                {
                    for (int i = 0; i < pattern.x; i++)
                    {
                        var bidx = idx + i + k * bx + j * bx * bz;
                        if (before[bidx] != null && before[bidx].name.Contains(pattern.PaternArray[i, j, k]))
                        {
                            //cloneがはいってしまう
                            after[bidx].name = before[bidx].name;
                            after[bidx].position = before[bidx].transform.position;

                            if (pattern.OneCheck) goto Jump;
                        }
                    }
                }
            }
Jump:
            return true;
        }
    }
}
