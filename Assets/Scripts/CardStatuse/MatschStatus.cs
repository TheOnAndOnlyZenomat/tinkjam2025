using UnityEngine;

public class MatschStatus : Status
{
	public override string statusName { get; } = "Matsch";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Matsch is applying damage");
	}
}
