using UnityEngine;

public class SurfaceCaster : MonoBehaviour
{
    public Surface CastForSurface(Vector3 pos, float distance = 3f)
    {
        Surface id = Surface.None;
        Ray ray = new Ray(pos, Vector3.down);
        int layerMask = LayerMask.GetMask(new string[] { "Ground" });

        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance, layerMask))
        {
            id = hitInfo.collider.GetComponent<SurfaceId>().Id;
        }

        return id;
    }
}
