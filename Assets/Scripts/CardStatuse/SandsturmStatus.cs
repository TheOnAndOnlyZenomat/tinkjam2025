using UnityEngine;

public class SandsturmStatus : Status
{
	public override string statusName { get; } = "Sandsturm";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Sandsturm is applying damage");
	}
}
