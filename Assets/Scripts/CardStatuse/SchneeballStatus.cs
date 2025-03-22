using UnityEngine;

public class SchneeballStatus : Status
{
	public override string statusName { get; } = "Schneeball";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Schneeball is applying damage");
	}
}
