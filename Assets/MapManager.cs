using System.Collections.Generic;
using UnityEngine;

class Region {
	public int index { get; }
	List<Status> statuse { get; set; }
	List<int> enemies { get; set; }

	public Region(int index, Status[] statuse = null, int[] enemies = null) {
		this.index = index;
		if (statuse is null) {
			this.statuse = new List<Status>();
		} else {
			this.statuse = new List<Status>(statuse);
		}

		if (enemies is null) {
			this.enemies = new List<int>();
		} else {
			this.enemies = new List<int>(enemies);
		}
	}

	public void Update(float delta) {
		List<int> to_remove = new List<int>();
		for (int i = 0; i < this.statuse.Count; i++) {
			var status = this.statuse[i];
			bool remove = status.ApplyToEnemies(delta, this.enemies.ToArray());
			if (remove) {
				to_remove.Add(i);
			}
		}

		foreach(int index in to_remove) {
			this.statuse.RemoveAt(index);
		}
	}

	public override string ToString() {
		string out_str = "{ ";

		out_str += $"index = {this.index}; ";
		out_str += "statuse = [";
		for (int i = 0; i < this.statuse.Count; i++) {
			out_str += statuse[i].ToString();
			if (i != (this.statuse.Count - 1)) out_str += ", ";
		}
		out_str += "]; ";
		out_str += "enemies = [";
		for (int i = 0; i < this.enemies.Count; i++) {
			out_str += enemies[i];
			if (i != (this.enemies.Count - 1)) out_str += ", ";
		}
		out_str += "]; ";

		out_str += "}";

		return out_str;
	}

	public void ApplyStatus(Status status) {
		if (!status.oneshot) {
			this.statuse.Add(status);
		} else {
			status.ApplyToEnemies(this.enemies.ToArray());
		}
	}

	public void AddEnemy(int enemy) {
		this.enemies.Add(enemy);
	}
}

public class MapManager : MonoBehaviour
{

	public int regionCount = 6;
	private Region[] regions;

	void Start()
	{
		Debug.Log("Initializing MapManager");

		Region[] regions = new Region[this.regionCount];

		for (int i = 0; i < this.regionCount; i++) {
			regions[i] = new Region(i);
		}

		this.regions = regions;

		Debug.Log("regions:");

		foreach(Region region in this.regions) {
			Debug.Log(region.ToString());
		}

		this.regions[0].ApplyStatus(new Status("test_status"));

		Debug.Log(this.regions[0].ToString());

		InitDebug();
	}

	void Update()
	{
		float delta = Time.deltaTime;

		foreach (Region region in this.regions) {
			region.Update(delta);
		}
	}

	private void InitDebug() {
		foreach (Region region in this.regions) {
			region.AddEnemy(0);
			region.ApplyStatus(new Status("test_status", false, 2, 2));
		}
	}

	public void ApplyStatus(int index, Status status) {
		this.regions[index].ApplyStatus(status);
	}
}
