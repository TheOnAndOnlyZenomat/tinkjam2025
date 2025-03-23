using UnityEngine;

public class RegenStatus : Status
{
	public override string statusName { get; } = "Regen";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		AudioManager.Instance.PlayRegen();
		Debug.Log("Regen is applying damage");

		enemy.GetComponent<EnemyStats>().isWetDuration = 1f;
	}
}
