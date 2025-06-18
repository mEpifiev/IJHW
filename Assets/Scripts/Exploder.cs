using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplodeView))]
public class Exploder : MonoBehaviour
{
    const float SizeForceMultiplier = 2f; 

    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    [SerializeField] private ExplodeView _view;

    private void Awake()
    {
        _view = GetComponent<ExplodeView>();
    }

    public void Explode(Cube cube)
    {
        foreach(Rigidbody hit in GetExplodableObjects(cube.transform.position))
        {
            float size = Mathf.Max(hit.transform.lossyScale.x, hit.transform.lossyScale.y, hit.transform.lossyScale.z);

            float sizeForceMultiplier = SizeForceMultiplier / size;

            hit.AddExplosionForce(_explosionForce * sizeForceMultiplier, cube.transform.position, _explosionRadius);
        }

        _view.Play(cube.transform.position);
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _explosionRadius);

        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach (Collider hit in hits)
            if(hit.attachedRigidbody != null)
                rigidbodies.Add(hit.attachedRigidbody);

        return rigidbodies;
    }
}
