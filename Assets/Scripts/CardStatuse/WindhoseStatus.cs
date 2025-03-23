using UnityEngine;

public class WindhoseStatus : Status
{
	public override string statusName { get; } = "Windhose";

	public int damage = 10;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Windhose is applying damage");
		AudioManager.Instance.PlayWindhose();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
		enemy.GetComponent<EnemyStats>().transform.position -= new Vector3(0, -2, 0);
	}
}
