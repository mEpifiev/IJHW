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

    public void Explode(Cube parent)
    {
        if (parent.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(_explosionForce, parent.transform.position, _explosionRadius);
    }
}
