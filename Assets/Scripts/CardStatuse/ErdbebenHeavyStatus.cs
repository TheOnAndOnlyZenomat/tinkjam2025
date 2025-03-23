using UnityEngine;

public class ErdbebenHeavyStatus : Status
{
	public override string statusName { get; } = "Erdbeben Heavy";

	public override bool globalStatus { get; } = true;

	public int damage = 50;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Erdbeben Heavy is applying damage");
		AudioManager.Instance.PlayErdbebenMitDerStaerke10(); 

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
