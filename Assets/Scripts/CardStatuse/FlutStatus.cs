using UnityEngine;

public class FlutStatus : Status
{
	public override string statusName { get; } = "Flut";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Flut is applying damage");
	}
}
