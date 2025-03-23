using UnityEngine;

public class MatschStatus : Status
{
	public override string statusName { get; } = "Matsch";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Matsch is applying damage");
		AudioManager.Instance.PlayMatsch();
	}
}
