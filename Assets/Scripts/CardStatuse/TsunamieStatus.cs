using UnityEngine;

public class TsunamieStatus : Status
{
	public override string statusName { get; } = "Tsunamie";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Tsunamie is applying damage");
	}
}
