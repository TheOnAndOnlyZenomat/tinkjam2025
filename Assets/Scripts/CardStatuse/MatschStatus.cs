using UnityEngine;

public class MatschStatus : Status
{
	public override string statusName { get; } = "Matsch";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 1;
	public override int periode {get; set; } = 1;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Matsch is applying damage");
		AudioManager.Instance.PlayMatsch();

		enemy.GetComponent<EnemyStats>().Slow(1f, 0f);
	}
}
