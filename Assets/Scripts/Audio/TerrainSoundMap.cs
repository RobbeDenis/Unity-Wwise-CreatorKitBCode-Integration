using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SurfaceLayer
{
    public AK.Wwise.Switch surface;
    public List<TerrainLayer> layers;
}

[CreateAssetMenu(fileName = "NewSoundMap",menuName = "Audio/Terrain Sound Map")]
public class TerrainSoundMap : ScriptableObject
{
    [SerializeField] private List<SurfaceLayer> m_SurfaceMap = new List<SurfaceLayer>();

    public AK.Wwise.Switch GetSurface(TerrainLayer layer)
    {
        foreach (SurfaceLayer surface in m_SurfaceMap)
            foreach(TerrainLayer terrain in surface.layers)
                if (terrain == layer)
                return surface.surface;

        return null;
    }
}