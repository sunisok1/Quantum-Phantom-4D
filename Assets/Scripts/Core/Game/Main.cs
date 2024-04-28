using System;
using Core.Data;
using UnityEngine;

namespace Core.Game
{
    public enum Dimen
    {
        XYZ,
        YZW,
        ZWX,
        WXY
    }

    public partial class Main : MonoBehaviour
    {
        public event Action<int[,,]> OnSetGrids;
        public event Action<Dimen, int, int, int, int> OnCurPosChanged;

        private Dimen dimen = Dimen.XYZ;

        private Level level = Level.SampleLevel();
        public int Size = 4;

        private void SetCurrentGrids(int[,,] value)
        {
            OnSetGrids?.Invoke(value);
        }

        private void Awake()
        {
            Size = 4;
        }

        private void Start()
        {
            SetCurrentGrids(level.GetSliceByW(0));
            SetCurPos(0, 0, 0, 0);
        }
    }
}