using UnityEngine;

public class SteinschlagStatus : Status
{
	public override string statusName { get; } = "Steinschlag";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Steinschlag is applying damage");
		AudioManager.Instance.PlaySteinschlag();
	}
}
