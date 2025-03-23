using UnityEngine;

public class MonsunStatus : Status
{
	public override string statusName { get; } = "Monsun";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	public int oneshotDamage = 5;
	private bool damageDealt = false;

	public int poisonDamage = 3;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Monsun is applying damage");
		AudioManager.Instance.PlayMonsun();

		if (!this.damageDealt) {
			enemy.GetComponent<EnemyStats>().Damage(this.oneshotDamage);
			this.damageDealt = true;
		}

		enemy.GetComponent<EnemyStats>().Damage(poisonDamage);
	}
}
