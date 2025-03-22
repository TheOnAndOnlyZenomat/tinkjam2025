using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
	public static MapManager Instance { get; private set; }

	private Region[] regions;
	private Region activeRegion = null;

	[SerializeField]
	public List<Status> debugSelected = new List<Status>(2); 

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
			region.AddEnemy(1);
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

	public void OnMousePress() {
		Debug.Log("OnMousePress in MapManager");

		GameObject[] status_objects = GameObject.FindGameObjectsWithTag("status");
		Status[] statuse = new Status[status_objects.Length];
		for (int i = 0; i < statuse.Length; i++) {
			statuse[i] = status_objects[i].GetComponent<Status>();
		}

		/* Status[] activeStatuse = HandManager.Instance._activeCards.ToArray(); */
		Status[] activeStatuse = this.debugSelected.ToArray();

		foreach (Status status in statuse) {
			if (status.IsCreatedBy(activeStatuse)) {
				this.activeRegion.ApplyStatus(status);
			}
		}
	}
}
