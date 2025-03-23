using UnityEngine;

public class ErdbebenStatus : Status
{
	public override string statusName { get; } = "Erdbeben";

	public override bool globalStatus { get; } = true;

	public int damage = 10;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Erdbeben is applying damage");
		AudioManager.Instance.PlayErdbeben();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
