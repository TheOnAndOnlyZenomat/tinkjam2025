using UnityEngine;

public class TreibsandStatus : Status
{
	public override string statusName { get; } = "Treibsand";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Treibsand is applying damage");
	}
}
