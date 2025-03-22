using UnityEngine;

public class RegenSturmStatus : Status
{
	public override string statusName { get; } = "Regensturm";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Regen Sturm is applying damage");
	}
}
