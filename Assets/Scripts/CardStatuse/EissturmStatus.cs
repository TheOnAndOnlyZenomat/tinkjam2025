using UnityEngine;

public class EissturmStatus : Status
{
	public override string statusName { get; } = "Eissturm";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Eissturm is applying damage");
	}
}
