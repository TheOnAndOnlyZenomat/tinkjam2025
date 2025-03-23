using UnityEngine;

public class KieselStatus : Status
{
	public override string statusName { get; } = "Kiesel";

	[SerializeField] private int damage = 5;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		AudioManager.Instance.PlayKieseln();
		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
