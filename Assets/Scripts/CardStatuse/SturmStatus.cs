using UnityEngine;

public class SturmStatus : Status
{
	public override string statusName { get; } = "Sturm";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Sturm is applying damage");
	}
}
