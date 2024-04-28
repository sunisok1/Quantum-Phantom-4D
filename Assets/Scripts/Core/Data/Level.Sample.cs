﻿namespace Core.Data
{
    public partial class Level
    {
        public static Level SampleLevel()
        {
            return new()
            {
                sizeX = 4,
                sizeY = 4,
                sizeZ = 4,
                sizeW = 4,
                matrix = new[,,,]
                {
                    {
                        { { 0, 1, 1, 0 }, { 0, 0, 0, 1 }, { 0, 1, 0, 1 }, { 1, 0, 0, 0 } },
                        { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } },
                        { { 0, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } },
                        { { 0, 0, 1, 1 }, { 1, 1, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 1, 0 } }
                    },

                    {
                        { { 0, 0, 0, 1 }, { 0, 1, 1, 0 }, { 0, 1, 1, 1 }, { 1, 0, 0, 0 } },
                        { { 1, 0, 0, 0 }, { 0, 0, 1, 0 }, { 1, 0, 0, 1 }, { 1, 0, 1, 0 } },
                        { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 0, 0, 1 }, { 0, 0, 0, 0 } },
                        { { 1, 1, 0, 1 }, { 1, 0, 1, 0 }, { 1, 1, 0, 0 }, { 0, 0, 1, 1 } }
                    },

                    {
                        { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 1, 0, 1 }, { 1, 0, 0, 0 } },
                        { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 1, 0, 1 } },
                        { { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                        { { 0, 0, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } }
                    },

                    {
                        { { 1, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } },
                        { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 1, 0, 1 }, { 0, 0, 0, 0 } },
                        { { 0, 0, 1, 0 }, { 1, 0, 1, 0 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } },
                        { { 1, 1, 1, 0 }, { 0, 1, 0, 1 }, { 1, 1, 0, 0 }, { 1, 0, 0, 0 } }
                    }
                }
            };
        }
    }
}