using UnityEngine;

public class KalterWindStatus : Status
{
	public override string statusName { get; } = "kalter Wind";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("kalter Wind is applying damage");
	}
}
