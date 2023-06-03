using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TerrainSurfaceCaster : MonoBehaviour
{
    [SerializeField]
    private TerrainSoundMap m_SoundMap;

    public string GetSurface()
    {
        Vector3 pos = transform.position;
        Ray ray = new Ray(pos, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100))
        {
            TerrainCollider terrain = hitInfo.collider.GetComponentInParent<TerrainCollider>();

            if (terrain != null)
            {
                TerrainData data = terrain.terrainData;

                Vector3 terrainPosition = pos - terrain.transform.position;
                Vector3 mapPosition = new Vector3(terrainPosition.x / data.size.x, 0, terrainPosition.z / data.size.z);
                int x = (int)(mapPosition.x * data.alphamapWidth);
                int z = (int)(mapPosition.z * data.alphamapHeight);

                float[,,] map = data.GetAlphamaps(x, z, 1, 1);
                float highestWeight = float.MinValue;
                TerrainLayer layer = null;

                for (int i = 0; i < data.alphamapLayers; ++i)
                {
                    float weight = map[0, 0, i];
                    if (weight > highestWeight)
                    {
                        highestWeight = weight;
                        layer = data.terrainLayers[i];
                    }
                }

                return m_SoundMap.GetSurface(layer);
            }
        }

        return "Empty";
    }
}
