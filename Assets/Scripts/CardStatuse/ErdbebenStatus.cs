using UnityEngine;

public class ErdbebenStatus : Status
{
	public override string statusName { get; } = "Erdbeben";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Erdbeben is applying damage");
	}
}
