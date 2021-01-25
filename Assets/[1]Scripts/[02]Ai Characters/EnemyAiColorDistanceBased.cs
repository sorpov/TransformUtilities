using UnityEngine;

public class EnemyAiColorDistanceBased : EnemyAiColor 
{
	[SerializeField] private float ActiveDistance = 5f;

	protected override void Start() {
		base.Start();
		
		TransformsHandlersManager.HandleTransform(ThisTransform)
			.IsHaveTargetInRadius(Target, ActiveDistance)
			.RespondTo(SwitchColorActive);
	} 
	
	// Alternative use
//	private void Update()
//  {
//		SwitchColorActive(ThisTransform.DistanceToTransform(Target) <= ActiveDistance);
//	}
}