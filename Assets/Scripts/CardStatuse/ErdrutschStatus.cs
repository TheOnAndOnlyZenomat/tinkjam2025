using UnityEngine;

public class ErdrutschStatus : Status
{
	public override string statusName { get; } = "Erdrutsch";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Erdrutsch is applying damage");
	}
}
