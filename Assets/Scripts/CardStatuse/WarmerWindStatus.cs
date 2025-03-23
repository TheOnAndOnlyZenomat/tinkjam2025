using UnityEngine;

public class WarmerWindStatus : Status
{
	public override string statusName { get; } = "warmer Wind";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("warmer Wind is applying damage");
		AudioManager.Instance.PlaywarmerWind();
	}
}
