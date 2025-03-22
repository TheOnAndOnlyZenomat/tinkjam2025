using UnityEngine;

public class MonsunStatus : Status
{
	public override string statusName { get; } = "Monsun";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Monsun is applying damage");
	}
}
