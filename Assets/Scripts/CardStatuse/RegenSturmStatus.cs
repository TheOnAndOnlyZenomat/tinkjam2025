using UnityEngine;

public class RegenSturmStatus : Status
{
	public override string statusName { get; } = "Regensturm";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	public int damage {get; set; } = 3;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Regen Sturm is applying damage");
		AudioManager.Instance.PlayRegensturm();

		enemy.GetComponent<EnemyStats>().isWetDuration = 1f;
		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
