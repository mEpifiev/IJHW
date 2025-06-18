using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinCount = 2;
    private const int MaxCount = 6;
    private const int SizeDivider = 2;
    private const float SplitChanceDivider = 2f;

    [SerializeField] private Cube _cubePrefab;

    public void Spawn(Cube cube)
    {
        int count = Random.Range(MinCount, MaxCount + 1);

        Vector3 newScale = cube.transform.localScale / SizeDivider;
        float newSplitChance = cube.CurrentSplitChance / SplitChanceDivider;

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, cube.transform.position, Quaternion.identity);

            newCube.Initialize(newScale, newSplitChance);
        }
    }
}
