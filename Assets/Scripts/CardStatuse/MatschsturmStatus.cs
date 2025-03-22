using UnityEngine;

public class MatschsturmStatus : Status
{
	public override string statusName { get; } = "Matschsturm";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Matschsturm is applying damage");
	}
}
