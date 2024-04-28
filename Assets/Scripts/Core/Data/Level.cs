using UnityEngine;

namespace Core.Data
{
    public partial class Level
    {
        private int[,,,] matrix;

        // 维度大小
        public int sizeX;
        public int sizeY;
        public int sizeZ;
        public int sizeW;

        public int this[int x, int y, int z, int w] => matrix[x, y, z, w];

        // 获取固定w的三维切片，返回xyz维度顺序
        public int[,,] GetSliceByW(int fixedW)
        {
            int[,,] slice = new int[sizeX, sizeY, sizeZ];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        slice[x, y, z] = matrix[x, y, z, fixedW];
                    }
                }
            }

            return slice;
        }

        // 获取固定x的三维切片，返回yzw维度顺序
        public int[,,] GetSliceByX(int fixedX)
        {
            int[,,] slice = new int[sizeY, sizeZ, sizeW];
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    for (int w = 0; w < sizeW; w++)
                    {
                        slice[y, z, w] = matrix[fixedX, y, z, w];
                    }
                }
            }

            return slice;
        }

        // 获取固定y的三维切片，返回zwx维度顺序
        public int[,,] GetSliceByY(int fixedY)
        {
            int[,,] slice = new int[sizeZ, sizeW, sizeX];
            for (int z = 0; z < sizeZ; z++)
            {
                for (int w = 0; w < sizeW; w++)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        slice[z, w, x] = matrix[x, fixedY, z, w];
                    }
                }
            }

            return slice;
        }

        // 获取固定z的三维切片，返回wxy维度顺序
        public int[,,] GetSliceByZ(int fixedZ)
        {
            int[,,] slice = new int[sizeW, sizeX, sizeY];
            for (int w = 0; w < sizeW; w++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        slice[w, x, y] = matrix[x, y, fixedZ, w];
                    }
                }
            }

            return slice;
        }
    }
}