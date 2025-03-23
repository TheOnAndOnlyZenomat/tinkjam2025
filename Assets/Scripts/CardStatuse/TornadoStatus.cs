using UnityEngine;

public class TornadoStatus : Status
{
	public override string statusName { get; } = "Tornado";

	public int damage = 50;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Tornado is applying damage");
		AudioManager.Instance.PlayTornado();

		enemy.GetComponent<EnemyStats>().transform.position -= new Vector3(0, -2, 0);
		enemy.GetComponent<EnemyStats>().Damage(damage);
	}
}
