using Spine.Unity;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;
    public Vector3 Project(Vector3 forward)
    {
        return forward - Vector3.Dot(forward, _normal) * _normal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }
}
