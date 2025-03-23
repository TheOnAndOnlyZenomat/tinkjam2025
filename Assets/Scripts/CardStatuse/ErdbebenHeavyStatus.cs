using UnityEngine;

public class ErdbebenHeavyStatus : Status
{
	public override string statusName { get; } = "Erdbeben Heavy";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Erdbeben Heavy is applying damage");
		AudioManager.Instance.PlayErdbebenMitDerStaerke10(); 
	}
}
