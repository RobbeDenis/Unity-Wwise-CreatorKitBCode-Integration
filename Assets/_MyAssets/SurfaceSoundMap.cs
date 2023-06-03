using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSSoundMap",menuName = "Audio/SSound Map")]
public class SurfaceSoundMap : ScriptableObject
{
    [SerializeField] private List<SurfaceLayer> _surfaceMaps = new List<SurfaceLayer>();

    public Surface GetSurface(TerrainLayer layer)
    {
        foreach (SurfaceLayer p in _surfaceMaps)
        {
            if (p.layer == layer)
                return p.surface;
        }

        return 0;
    }
}

[Serializable]
public struct SurfaceLayer
{
    public TerrainLayer layer;
    public Surface surface;
}
