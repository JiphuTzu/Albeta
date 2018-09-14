using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tzu.Utils
{
    public sealed class Layer
    {
        //built-in layers
        public static readonly int Default = 0;
        public static readonly int TransparentFX = 1;
        public static readonly int IgnoreRaycast = 2;
        public static readonly int Water = 4;
        public static readonly int UI = 5;
        //custom layers
        //用于角色检测地面站立
        public static readonly int Ground = LayerMask.NameToLayer("Ground");
        public static int GetMask(params int[] layers)
        {
            int mask = 0;
            int i = layers.Length;
            while (--i >= 0)
            {
                mask |= 1 << layers[i];
            }
            return mask;
        }
        public static bool IsInMask(int layer, int mask)
        {
            return (mask & (1 << layer)) != 0;
        }
    }
}
