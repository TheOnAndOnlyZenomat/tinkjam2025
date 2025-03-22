using UnityEngine;

public class ErdrutschStatus : Status
{
	public override string statusName { get; } = "Erdrutsch";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Erdrutsch is applying damage");
	}
}
