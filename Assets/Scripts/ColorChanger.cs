using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
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
