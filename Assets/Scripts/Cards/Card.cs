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
        HandManager.CardAddStatus status = HandManager.Instance.AddActiveCard(this.status);
		switch (status) {
			case HandManager.CardAddStatus.Added:
				transform.localScale += new Vector3(2, 2, 0);
				break;
			case HandManager.CardAddStatus.Removed:
				transform.localScale -= new Vector3(2, 2, 0);
				break;
			case HandManager.CardAddStatus.Failed:
				Debug.Log("My adding failed");
				break;
		}
    }
}
