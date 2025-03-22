using UnityEngine;

public class WindhoseStatus : Status
{
	public override string statusName { get; } = "Windhose";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Windhose is applying damage");
	}
}
