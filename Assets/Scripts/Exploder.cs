using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnEnable()
    {
        _raycaster.Hited += Explode;
    }

    private void OnDisable()
    {
        _raycaster.Hited -= Explode;
    }

    public void Explode(Cube cube)
    {
        cube.Rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }
}
