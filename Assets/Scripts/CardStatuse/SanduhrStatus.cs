using UnityEngine;

public class SanduhrStatus : Status
{
	public override string statusName { get; } = "Sanduhr";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Sanduhr is applying damage");
	}
}
