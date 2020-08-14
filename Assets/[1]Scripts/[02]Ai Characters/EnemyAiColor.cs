using UnityEngine;

public class EnemyAiColor : EnemyAi
{
    private Color ActiveColor;
    private Color DisabledColor;

    private Renderer[] _renderers;

    protected override void Start()
    {
        _renderers = GetComponentsInChildren<Renderer>();
        ActiveColor = _renderers[0].material.color;
        DisabledColor = ActiveColor.DesaturatedAt(70);
    }

    protected void SwitchColorActive(bool isActive) 
    {
        for (var index = 0; index < _renderers.Length; index++) {
            _renderers[index].material.color = isActive ? ActiveColor : DisabledColor;
        }
    }
}
