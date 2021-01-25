using UnityEngine;

public class EnemyAiColorAngleBased : EnemyAiColor 
{
	[SerializeField] private float DetectionAngle = 25f;
	[SerializeField] private float DetectionDistance = 3f;
	[SerializeField] private Transform RangeDummyStart;
	[SerializeField] private Transform RangeDummyEnd;

	protected override void Start() 
	{
		base.Start();
		RangeDummyStart.localEulerAngles = new Vector3(0, -DetectionAngle, 0);
		RangeDummyEnd.localEulerAngles = new Vector3(0, DetectionAngle, 0);
		RangeDummyStart.localScale = RangeDummyEnd.localScale = new Vector3(1,1,DetectionDistance);

		TransformsHandlersManager.HandleTransform(ThisTransform)
			.IsHaveTargetInAngle(Target, DetectionAngle)
			.IsHaveTargetInRadius(Target, DetectionDistance) 
			.RespondTo(SwitchColorActive);
	}
	
	// Alternative use
//	private void Update()
//  {
//		SwitchColorActive(ThisTransform.GetAngleToTransform(Target, ThisTransform.forward) <= DetectionAngle
//		                  && ThisTransform.DistanceToTransform(Target) <= DetectionDistance);
//	}
}
