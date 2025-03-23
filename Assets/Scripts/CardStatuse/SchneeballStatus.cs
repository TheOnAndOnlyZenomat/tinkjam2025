using UnityEngine;

public class SchneeballStatus : Status
{
	public override string statusName { get; } = "Schneeball";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	public int oneshotDamage = 10;
	private bool damageDealt = false;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Schneeball is applying damage");
		AudioManager.Instance.PlaySchneebaelleVomSchuhlhof();

		if (!this.damageDealt) {
			enemy.GetComponent<EnemyStats>().Damage(this.oneshotDamage);
			this.damageDealt = true;
		}

		enemy.GetComponent<EnemyStats>().Slow(1f, 0.5f);
	}
}
