using UnityEngine;

public class SchneeStatus : Status
{
	public override string statusName { get; } = "Schnee";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	public int damage = 1;
	private float slowDuration = 1;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Schnee is applying damage");
		AudioManager.Instance.PlaySchnee();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
		enemy.GetComponent<EnemyStats>().Slow(this.slowDuration, 0.5f);
	}
}
