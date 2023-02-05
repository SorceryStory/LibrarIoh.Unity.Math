using SorceressSpell.LibrarIoh.Math;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Math
{
    public static class PerlinNoiseOperations
    {
        #region Methods

        public static float OctavePerlin(float x, float y, float z, Vector3[] octaveOffsets, float persistence, float lacunarity)
        {
            return OctavePerlin(x, y, z, -1, octaveOffsets, persistence, lacunarity);
        }

        public static float OctavePerlin(float x, float y, float z, int repeat, Vector3[] octaveOffsets, float persistence, float lacunarity)
        {
            float total = 0;
            float frequency = 1;
            float amplitude = 1;

            // Used for normalizing result to [0.0, 1.0]
            float maxValue = 0;

            for (int i = 0; i < octaveOffsets.Length; i++)
            {
                total += PerlinNoise.Perlin((x * frequency) + octaveOffsets[i].x, (y * frequency) + octaveOffsets[i].y, (z * frequency) + octaveOffsets[i].z, repeat) * amplitude;

                maxValue += amplitude;

                amplitude *= persistence;
                frequency *= lacunarity;
            }

            return total / maxValue;
        }

        public static float OctavePerlin(Vector3 position, Vector3[] octaveOffsets, float persistence, float lacunarity)
        {
            return OctavePerlin(position.x, position.y, position.z, -1, octaveOffsets, persistence, lacunarity);
        }

        public static float OctavePerlin(Vector3 position, int repeat, Vector3[] octaveOffsets, float persistence, float lacunarity)
        {
            return OctavePerlin(position.x, position.y, position.z, repeat, octaveOffsets, persistence, lacunarity);
        }

        #endregion Methods
    }
}
