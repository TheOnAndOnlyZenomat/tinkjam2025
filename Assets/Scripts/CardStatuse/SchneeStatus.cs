using UnityEngine;

public class SchneeStatus : Status
{
	public override string statusName { get; } = "Schnee";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Schnee is applying damage");
	}
}
