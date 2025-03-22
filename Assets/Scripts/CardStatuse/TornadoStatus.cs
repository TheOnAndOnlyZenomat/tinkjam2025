using UnityEngine;

public class TornadoStatus : Status
{
	public override string statusName { get; } = "Tornado";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Tornado is applying damage");
	}
}
