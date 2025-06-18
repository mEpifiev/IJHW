using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinCount = 2;
    private const int MaxCount = 6;
    private const int SizeDivider = 2;
    private const float SplitChanceDivider = 2f;

    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Cube _cubePrefab;

    private void OnEnable()
    {
        _raycaster.Hited += Spawn;
    }

    private void OnDisable()
    {
        _raycaster.Hited -= Spawn;
    }

    private void Spawn(Cube parent)
    {
        int count = Random.Range(MinCount, MaxCount + 1);

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parent.transform.position, Quaternion.identity);

            Vector3 newScale = parent.transform.localScale / SizeDivider;
            float newSplitChance = parent.CurrentSplitChance / SplitChanceDivider;

            newCube.Initialize(newScale, newSplitChance);
        }
    }
}
