using UnityEngine;

public class RegenStatus : Status
{
	public override string statusName { get; } = "Regen";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		AudioManager.Instance.PlayRegen();
		Debug.Log("Regen is applying damage");
	}
}
