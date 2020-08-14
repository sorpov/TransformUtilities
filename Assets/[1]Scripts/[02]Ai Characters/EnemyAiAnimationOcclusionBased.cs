using UnityEngine;

public class EnemyAiAnimationOcclusionBased : EnemyAi 
{
    [SerializeField] private float OcclusionOffset = 0.05f;
    private Animator _animator;

    protected override void Start() 
    {
        base.Start();
        _animator = GetComponent<Animator>();
        
        TransformsHandler.CheckTransform(ThisTransform)
            .IsInsideCameraBorders(MainCamera, OcclusionOffset)
            .RespondTo(isInside => _animator.enabled = isInside);
    }
    
    // Alternative use
//    private void Update()
//    {
//        _animator.enabled = ThisTransform.IsInsideCameraView(MainCamera, OcclusionOffset);
//    }
}
