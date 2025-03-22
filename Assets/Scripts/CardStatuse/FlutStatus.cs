using UnityEngine;

public class FlutStatus : Status
{
	public override string statusName { get; } = "Flut";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Flut is applying damage");
	}
}
