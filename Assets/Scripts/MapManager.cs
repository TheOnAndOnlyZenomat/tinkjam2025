using UnityEngine;

public class MapManager : MonoBehaviour
{
	public static MapManager Instance { get; private set; }

	private Region[] regions;
	private Region activeRegion = null;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.Log("MapManager instance was not me, destroying");
			Destroy(this.gameObject);
		} else {
			Instance = this;
		}
	}

	void Start()
	{
		Debug.Log("Initializing MapManager");

		var regions = Helpers.FindChildObjectsWithTag<Region>(transform, "region");

		this.regions = new Region[regions.Count];
		for (int i = 0; i < this.regions.Length; i++) {
			this.regions[i] = regions[i];
			this.regions[i].init();
		}

		Debug.Log("regions:");

		foreach(Region region in this.regions) {
			Debug.Log(region.ToString());
		}
	}

	void Update()
	{
		float delta = Time.deltaTime;
		foreach (Region region in this.regions) {
			region.Tick(delta);
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

	public void SetActiveRegion(Region region) {
		if (region is null) {
			this.activeRegion.Highlight(false);
			this.activeRegion = region;

			return;
		}

		this.activeRegion = region;
		this.activeRegion.Highlight(true);
	}
}
