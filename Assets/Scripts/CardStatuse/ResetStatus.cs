using UnityEngine;

public class ResetStatus : Status
{
	public override string statusName { get; } = "Reset";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Reset is applying damage");
	}
}
