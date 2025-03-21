using UnityEngine;

public class Status {
	public string name = "";
	public bool oneshot { get; } = true;

	public int ticks {get; set; } = 5;
	float current_periode {get; set; } = 0;
	public int periode {get; set; } = 0;

	public void ApplyToEnemies(int[] enemies) {
		foreach (int enemy in enemies) {
			Debug.Log($"Oneshot applying effect \"{this.name}\" to enemy with id {enemy}");
		}
	}

	/// returns whether or not to remove the status from the region
	public bool ApplyToEnemies(float delta, int[] enemies) {
		this.current_periode += delta;
		if (this.current_periode >= this.periode) {
			foreach (int enemy in enemies) {
				Debug.Log($"Applying effect \"{this.name}\" to enemy with id {enemy}, last execution was {delta} ago");
			}

			this.ticks--;
			this.current_periode = 0;

			Debug.Log(this.ToString());

			if (this.ticks <= 0) {
				return true;
			}
		}

		return false;
	}

	public Status(string name) {
		this.name = name;
	}

	public Status(string name, bool oneshot, int ticks, int periode) {
		this.name = name;
		this.oneshot = oneshot;
		this.ticks = ticks;
		this.periode = periode;
	}

	public override string ToString() {
		return $"{{ {this.name}; oneshot = {this.oneshot}; ticks = {this.ticks}; periode = {this.periode}; current_periode = {this.current_periode}; }}";
	}
}
