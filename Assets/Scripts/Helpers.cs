using System.Collections.Generic;
using UnityEngine;

public static class Helpers {
	public static List<T> FindChildObjectsWithTag<T>(this Transform parent, string tag) {
		List<T> taggedGameObjects = new List<T>();

		for (int i = 0; i < parent.childCount; i++)
		{
			Transform child = parent.GetChild(i);
			if (child.tag == tag)
			{
				taggedGameObjects.Add(child.GetComponent<T>());
			}
		}
		return taggedGameObjects;
	}
}
