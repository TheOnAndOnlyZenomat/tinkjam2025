using UnityEngine;

public class MatschsturmStatus : Status
{
	public override string statusName { get; } = "Matschsturm";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Matschsturm is applying damage");
		AudioManager.Instance.PlayMatschsturtm();
	}
}
