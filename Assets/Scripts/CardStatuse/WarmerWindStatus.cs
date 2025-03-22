using UnityEngine;

public class WarmerWindStatus : Status
{
	public override string statusName { get; } = "warmer Wind";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("warmer Wind is applying damage");
	}
}
