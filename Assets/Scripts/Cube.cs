using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    private float _maxSplitChance = 1f;
    private float _currentSplitChance;

    public float CurrentSplitChance => _currentSplitChance;

    private void Awake()
    {
        _currentSplitChance = _maxSplitChance;
    }

    public void SetSplitChance(float splitChance)
    {
        _currentSplitChance = Mathf.Clamp(splitChance, 0f, _maxSplitChance);
    }
}
