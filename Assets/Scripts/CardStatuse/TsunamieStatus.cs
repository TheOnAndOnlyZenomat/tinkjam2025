using UnityEngine;

public class TsunamieStatus : Status
{
	public override string statusName { get; } = "Tsunamie";

	public int damage = 75;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Tsunamie is applying damage");
		AudioManager.Instance.PlayTsunamie();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
