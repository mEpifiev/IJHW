using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        Change();
    }

    private void Change()
    {
        if (_renderer != null)
            _renderer.material.color = Random.ColorHSV();
    }
}
