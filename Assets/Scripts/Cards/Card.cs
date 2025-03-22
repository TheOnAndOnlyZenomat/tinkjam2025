using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite Sprite { get; }
    public string Title { get; }

	public Status status;

    public Card()
    {}

	public void Awake() {
		this.status = transform.Find("Status").GetComponent<Status>();
	}

    public void OnMouseDown()
    {
        Debug.Log("Mouse press funzt");
        HandManager.Instance.AddActiveCard(this.status);
    }
}
