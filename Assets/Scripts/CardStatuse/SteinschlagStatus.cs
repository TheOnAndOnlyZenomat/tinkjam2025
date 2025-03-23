using UnityEngine;

public class SteinschlagStatus : Status
{
	public override string statusName { get; } = "Steinschlag";

	public int damage = 10;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Steinschlag is applying damage");
		AudioManager.Instance.PlaySteinschlag();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
