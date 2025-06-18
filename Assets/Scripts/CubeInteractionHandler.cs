using UnityEngine;

[RequireComponent(typeof(Raycaster))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Exploder))]
public class CubeInteractionHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void Awake()
    {
        _raycaster = GetComponent<Raycaster>();
        _spawner = GetComponent<Spawner>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnEnable()
    {
        _raycaster.Hited += HandleHit;
    }

    private void OnDisable()
    {
        _raycaster.Hited -= HandleHit;
    }

    private void HandleHit(Cube cube)
    {
        Destroy(cube.gameObject);

        _spawner.Spawn(cube);
        _exploder.Explode(cube);
    }
}
