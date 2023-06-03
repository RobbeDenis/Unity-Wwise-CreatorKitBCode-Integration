using UnityEngine;

public enum Surface
{
    None,
    Sand,
    Stone
}

public class SurfaceId : MonoBehaviour
{
    [SerializeField] private Surface _surface;

    public Surface Id
    {
        get { return _surface; }
    }
}
