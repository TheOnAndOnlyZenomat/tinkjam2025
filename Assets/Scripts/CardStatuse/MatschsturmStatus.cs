using UnityEngine;

public class MatschsturmStatus : Status
{
	public override string statusName { get; } = "Matschsturm";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 1;
	public override int periode {get; set; } = 1;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Matschsturm is applying damage");
		AudioManager.Instance.PlayMatschsturtm();

		enemy.GetComponent<EnemyStats>().Slow(1f, 0f);
	}
}
