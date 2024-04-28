using System;

namespace Core.Game
{
    public partial class Main
    {
        private int x, y, z, w; // Position in 4D space

        private void SetCurPos(int x, int y, int z, int w)
        {
            // Check bounds for each dimension
            if (x < 0 || x >= Size || y < 0 || y >= Size || z < 0 || z >= Size || w < 0 || w >= Size)
            {
                return; // Exit the function if new position is out of bounds
            }

            if (level[x, y, z, w] == 1) return;

            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;

            OnCurPosChanged?.Invoke(dimen, x, y, z, w);
        }

        public void MoveForward()
        {
            switch (dimen)
            {
                case Dimen.XYZ:
                    SetCurPos(x, y, z + 1, w);
                    break;
                case Dimen.YZW:
                    SetCurPos(x, y, z, w + 1);
                    break;
                case Dimen.ZWX:
                    SetCurPos(x + 1, y, z, w);
                    break;
                case Dimen.WXY:
                    SetCurPos(x, y + 1, z, w);
                    break;
            }
        }

        public void MoveBack()
        {
            switch (dimen)
            {
                case Dimen.XYZ:
                    SetCurPos(x, y, z - 1, w);
                    break;
                case Dimen.YZW:
                    SetCurPos(x, y, z, w - 1);
                    break;
                case Dimen.ZWX:
                    SetCurPos(x - 1, y, z, w);
                    break;
                case Dimen.WXY:
                    SetCurPos(x, y - 1, z, w);
                    break;
            }
        }

        public void MoveLeft()
        {
            switch (dimen)
            {
                case Dimen.XYZ:
                    SetCurPos(x - 1, y, z, w);
                    break;
                case Dimen.YZW:
                    SetCurPos(x, y - 1, z, w);
                    break;
                case Dimen.ZWX:
                    SetCurPos(x, y, z - 1, w);
                    break;
                case Dimen.WXY:
                    SetCurPos(x, y, z, w - 1);
                    break;
            }
        }

        public void MoveRight()
        {
            switch (dimen)
            {
                case Dimen.XYZ:
                    SetCurPos(x + 1, y, z, w);
                    break;
                case Dimen.YZW:
                    SetCurPos(x, y + 1, z, w);
                    break;
                case Dimen.ZWX:
                    SetCurPos(x, y, z + 1, w);
                    break;
                case Dimen.WXY:
                    SetCurPos(x, y, z, w + 1);
                    break;
            }
        }

        public void MoveUp()
        {
            switch (dimen)
            {
                case Dimen.XYZ:
                    SetCurPos(x, y + 1, z, w);
                    break;
                case Dimen.YZW:
                    SetCurPos(x, y, z + 1, w);
                    break;
                case Dimen.ZWX:
                    SetCurPos(x, y, z, w + 1);
                    break;
                case Dimen.WXY:
                    SetCurPos(x + 1, y, z, w);
                    break;
            }
        }

        public void MoveDown()
        {
            switch (dimen)
            {
                case Dimen.XYZ:
                    SetCurPos(x, y - 1, z, w);
                    break;
                case Dimen.YZW:
                    SetCurPos(x, y, z - 1, w);
                    break;
                case Dimen.ZWX:
                    SetCurPos(x, y, z, w - 1);
                    break;
                case Dimen.WXY:
                    SetCurPos(x - 1, y, z, w);
                    break;
            }
        }

        public void SwitchDimen()
        {
            dimen = dimen switch
            {
                Dimen.XYZ => Dimen.YZW,
                Dimen.YZW => Dimen.ZWX,
                Dimen.ZWX => Dimen.WXY,
                Dimen.WXY => Dimen.XYZ,
                _ => throw new ArgumentOutOfRangeException()
            };

            switch (dimen)
            {
                case Dimen.XYZ:
                    SetCurrentGrids(level.GetSliceByW(w));
                    break;
                case Dimen.YZW:
                    SetCurrentGrids(level.GetSliceByX(x));
                    break;
                case Dimen.ZWX:
                    SetCurrentGrids(level.GetSliceByY(y));
                    break;
                case Dimen.WXY:
                    SetCurrentGrids(level.GetSliceByZ(z));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SetCurPos(x, y, z, w);
        }
    }
}