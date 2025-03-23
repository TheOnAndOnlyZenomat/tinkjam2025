using UnityEngine;

public class SandsturmStatus : Status
{
	public override string statusName { get; } = "Sandsturm";
	public double vanishChance = 0.05f;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Sandsturm is applying damage");
		AudioManager.Instance.PlaySandsturm();

		System.Random rng = new System.Random();
		double pick = rng.NextDouble();

		if (pick < this.vanishChance) {
			Destroy(enemy);
		}
	}
}
