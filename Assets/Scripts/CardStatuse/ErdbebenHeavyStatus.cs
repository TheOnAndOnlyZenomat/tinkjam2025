using UnityEngine;

public class ErdbebenHeavyStatus : Status
{
	public override string statusName { get; } = "Erdbeben Heavy";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Erdbeben Heavy is applying damage");
	}
}
