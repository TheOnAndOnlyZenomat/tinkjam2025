using UnityEngine;

public class RegenStatus : Status
{
	public override string statusName { get; } = "Regen";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Regen is applying damage");
	}
}
