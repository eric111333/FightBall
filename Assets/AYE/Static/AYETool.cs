using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AYE
{
    /// <summary>AYE系列為阿葉私人提供的綜合工具，最新版本請找阿葉拿。</summary>
    public static class AYETool
    {
        /// <summary>複製到剪貼簿</summary>
        public static void CopyToClipboard(this string str)
        {
            var textEditor = new TextEditor();
            textEditor.text = str;
            textEditor.SelectAll();
            textEditor.Copy();
        }

        /// <summary>轉換成金錢顯示方式</summary>
        public static string ToMoney(this int fr)
        {
            if (fr >= 0)
                return System.String.Format("{0:$#,##0;$#,##0;$0}", fr);
            else
                return "-" + System.String.Format("{0:$#,##0;$#,##0;$0}", fr);
        }
        /// <summary>轉換成金錢顯示方式</summary>
        public static string ToMoney(this float fr)
        {
            if (fr >= 0f)
                return System.String.Format("{0:$#,##0;$#,##0;$0}", fr);
            else
                return "-" + System.String.Format("{0:$#,##0;$#,##0;$0}", fr);
        }

        /// <summary>超·隨機</summary>
        /// <param name="min">最小</param>
        /// <param name="max">最大</param>
        /// <param name="original">迴避</param>
        /// <returns></returns>
        public static int NRandom(int min, int max, params int[] originalList)
        {
            if (min == max)
                return min;
            if (Mathf.Abs(max - min) <= 1)
            {
                return min;
            }
            int an = Random.Range(min, max);

            for (int i = 0; i < originalList.Length; i++)
            {
                if (an == originalList[i])
                {
                    return NRandom(min, max, originalList);
                }
            }
            return an;
        }

        /// <summary>K轉換為KB</summary>
        public static string ToKB (this ulong ul)
        {
            return Mathf.Round(ul / (ulong)1024) + "KB";
        }

        /// <summary>轉換為序列化的Json檔資料</summary>
        public static string ToJson(this List<string> list)
        {
            ListString listString = new ListString();
            listString.list = list;
            return JsonUtility.ToJson(listString);
        }

        /// <summary>轉換為序列化的Json檔資料</summary>
        public static string ToJson(this List<int> list)
        {
            ListInt listString = new ListInt();
            listString.list = list;
            return JsonUtility.ToJson(listString);
        }

        /// <summary>轉換為序列化的Json檔資料</summary>
        public static string ToJson(this List<float> list)
        {
            ListFloat listString = new ListFloat();
            listString.list = list;
            return JsonUtility.ToJson(listString);
        }

        /// <summary>將Json檔轉換為string List</summary>
        public static List<string> ToStringList(this string listData)
        {
            ListString ls = JsonUtility.FromJson<ListString>(listData);
            return ls.list;
        }

        /// <summary>將Json檔轉換為int List</summary>
        public static List<int> ToIntList(this string listData)
        {
            ListInt ls = JsonUtility.FromJson<ListInt>(listData);
            return ls.list;
        }

        /// <summary>將Json檔轉換為float List</summary>
        public static List<float> ToFloatList(this string listData)
        {
            ListFloat ls = JsonUtility.FromJson<ListFloat>(listData);
            return ls.list;
        }

        /// <summary>
        /// 數值彈簧
        /// </summary>
        /// <param name="x">值(輸入/輸出)</param>
        /// <param name="v">值(輸入/輸出)</param>
        /// <param name="xt">目標(輸入)</param>
        /// <param name="zeta">阻尼(輸入)</param>
        /// <param name="omega">頻率(輸入)</param>
        /// <param name="h">時間(輸入)</param>
        public static void Spring(ref float x, ref float v, float xt, float zeta, float omega, float h)
        {
            float f = 1.0f + 2.0f * h * zeta * omega;
            float oo = omega * omega;
            float hoo = h * oo;
            float hhoo = h * hoo;
            float detInv = 1.0f / (f + hhoo);
            float detX = f * x + h * v + hhoo * xt;
            float detV = v + hoo * (xt - x);
            x = detX * detInv;
            v = detV * detInv;
        }
        /* 源自 : https://github.com/TheAllenChou/numeric-springing */

        /// <summary>
        /// 文字轉時間 yyyy-MM-ddTHH:mm:ss.fff 格式
        /// </summary>
        public static System.DateTime GetTimeByString(string v)
        {
            return System.DateTime.ParseExact(v, "yyyy-MM-ddTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// 時間轉文字 yyyy-MM-ddTHH:mm:ss.fff 格式
        /// </summary>
        public static string GetStringByDateTime(System.DateTime v)
        {
            return v.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }
    }

    [System.Serializable]
    public struct ListString
    {
        public List<string> list;
    }

    [System.Serializable]
    public struct ListInt
    {
        public List<int> list;
    }

    [System.Serializable]
    public struct ListFloat
    {
        public List<float> list;
    }
}

// 2020 by 阿葉