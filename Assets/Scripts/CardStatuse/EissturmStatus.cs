using UnityEngine;

public class EissturmStatus : Status
{
	public override string statusName { get; } = "Eissturm";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	public int oneshotDamage = 25;
	private bool damageDealt = false;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Eissturm is applying damage");
		AudioManager.Instance.PlayEissturm();

		if (!this.damageDealt) {
			enemy.GetComponent<EnemyStats>().Damage(this.oneshotDamage);
			this.damageDealt = true;
		}
		enemy.GetComponent<EnemyStats>().Slow(1f, 0f);
	}
}
