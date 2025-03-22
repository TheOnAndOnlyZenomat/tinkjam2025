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

	private class ContainsAllHelper<T> {
		public T elem;
		public bool met;

		public ContainsAllHelper(T elem, bool met) {
			this.elem = elem;
			this.met = met;
		}
	}

	public static bool ContainsAll<T>(T[] first, T[] contains) {
		List<ContainsAllHelper<T>> list = new List<ContainsAllHelper<T>>();
		foreach (T f in first) {
			list.Add(new ContainsAllHelper<T>(f, false));
		}

		foreach(ContainsAllHelper<T> l in list) {
			foreach(T c in contains) {
				if (l.elem.Equals(c)) {
					l.met = true;
				}
			}
		}

		foreach(ContainsAllHelper<T> l in list) {
			if (!l.met) return false;
		}

		return true;
	}
}
