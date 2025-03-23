using UnityEngine;

public class FlutStatus : Status
{
	public override string statusName { get; } = "Flut";

	public int damage = 25;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Flut is applying damage");
		AudioManager.Instance.PlayFlut();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
