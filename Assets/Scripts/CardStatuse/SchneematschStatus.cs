using UnityEngine;

public class SchneematschStatus : Status
{
	public override string statusName { get; } = "Schneematsch";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 2;
	public override int periode {get; set; } = 1;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Schneematsch is applying damage");
		AudioManager.Instance.PlaySchneematsch();

		enemy.GetComponent<EnemyStats>().Slow(1f, 0f);
	}
}
