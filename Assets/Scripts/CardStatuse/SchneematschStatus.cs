using UnityEngine;

public class SchneematschStatus : Status
{
	public override string statusName { get; } = "Schneematsch";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Schneematsch is applying damage");
	}
}
