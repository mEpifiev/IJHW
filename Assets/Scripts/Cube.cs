using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    private float _maxSplitChance = 1f;
    private float _currentSplitChance;

    public float CurrentSplitChance => _currentSplitChance;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _currentSplitChance = _maxSplitChance;
    }

    public void Initialize(Vector3 scale, float splitChance)
    {
        transform.localScale = scale;
        _currentSplitChance = Mathf.Clamp(splitChance, 0f, _maxSplitChance);
    }
}
