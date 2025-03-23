using UnityEngine;

public class SturmStatus : Status
{
	public override string statusName { get; } = "Sturm";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Sturm is applying damage");
		AudioManager.Instance.PlaySturm();

		enemy.GetComponent<EnemyStats>().transform.position -= new Vector3(0, -2, 0);
	}
}
