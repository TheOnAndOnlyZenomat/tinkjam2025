using UnityEngine;

public class SchneesturmStatus : Status
{
	public override string statusName { get; } = "Schneesturm";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	public int oneshotDamage = 5;
	private bool damageDealt = false;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Schneesturm is applying damage");
		AudioManager.Instance.PlaySchneesturm();

		if (!this.damageDealt) {
			enemy.GetComponent<EnemyStats>().Damage(this.oneshotDamage);
			this.damageDealt = true;
		}
		enemy.GetComponent<EnemyStats>().Slow(1f, 0);
	}
}
