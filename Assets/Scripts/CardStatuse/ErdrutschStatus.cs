using UnityEngine;

public class ErdrutschStatus : Status
{
	public override string statusName { get; } = "Erdrutsch";

	public int damage = 25;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Erdrutsch is applying damage");
		AudioManager.Instance.PlayErdrutsch();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
