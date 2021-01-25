using UnityEngine;

public class EnemyAiColor : EnemyAi
{
    private Color _activeColor;
    private Color _disabledColor;

    private Renderer[] _renderers;

    protected override void Start()
    {
        base.Start();
        _renderers = GetComponentsInChildren<Renderer>();
        _activeColor = _renderers[0].material.color;
        _disabledColor = _activeColor.DesaturatedAt(70);
    }

    protected void SwitchColorActive(bool isActive)
    {
        foreach (var rend in _renderers)
        {
            rend.material.color = isActive ? _activeColor : _disabledColor;
        }
    }
}
