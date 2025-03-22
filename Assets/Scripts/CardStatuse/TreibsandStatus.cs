using UnityEngine;

public class TreibsandStatus : Status
{
	public override string statusName { get; } = "Treibsand";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Treibsand is applying damage");
	}
}
