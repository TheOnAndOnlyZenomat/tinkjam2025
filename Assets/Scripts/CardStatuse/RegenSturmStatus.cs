using UnityEngine;

public class RegenSturmStatus : Status
{
	public override string statusName { get; } = "Regensturm";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Regen Sturm is applying damage");
	}
}
