using UnityEngine;

public class ResetStatus : Status
{
	public override string statusName { get; } = "Reset";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Reset is applying damage");
	}
}
