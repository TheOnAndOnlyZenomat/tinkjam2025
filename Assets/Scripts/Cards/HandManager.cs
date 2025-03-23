using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

public class HandManager : MonoBehaviour
{
    [SerializeField] private int _maxHandsize;
    [SerializeField] private SplineContainer _splineContainer;
    [SerializeField] private Transform _spawnPoint;
	[SerializeField] private List<Card> spawnPool;
	[SerializeField] private int drawDelay = 5;
    private List<GameObject> _handcards = new();
    private bool _canDraw = true;
    [SerializeField] public List<Status> _activeCards { get; private set; } = new List<Status>(2);
    public static HandManager Instance { get; private set; }

	private Dictionary<string, int> cardCounter = new Dictionary<string, int>();
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("HandManager instance was not me, destroying");
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_handcards.Count < _maxHandsize && _canDraw)
        {
            StartCoroutine(DrawCardDelay());
        }
    }

    private IEnumerator DrawCardDelay()
    {
        _canDraw = false;
        DrawCard();
        yield return new WaitForSeconds(this.drawDelay);
        _canDraw = true;
    }

    private void DrawCard()
    {
        if (_handcards.Count >= _maxHandsize) return;
		System.Random rng = new System.Random();
		int choice = rng.Next(0, this.spawnPool.Count);
		Card toSpawn = this.spawnPool[choice];
        GameObject g = Instantiate(toSpawn.gameObject, _spawnPoint.position, _spawnPoint.rotation);
		g.SetActive(true);
        g.transform.parent = gameObject.transform;
        _handcards.Add(g);
        UpdateCardPosition();
    }

    private void UpdateCardPosition()
    {
        if (_handcards.Count == 0) return;
        float cardSpacing = 1f / _maxHandsize;
        float _firstCardPosition = 0.5f - (_handcards.Count -1) * cardSpacing /2 ;
        Spline spline = _splineContainer.Spline;
        for (int i = 0; i < _handcards.Count; i++)
        {
            float p = _firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            splinePosition.z = -2;
            Vector3 forward = spline.EvaluateTangent(p);
            forward.z = 0;
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up,Vector3.Cross(up, forward).normalized);
            _handcards[i].transform.DOMove(splinePosition, 0.5f);
            _handcards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }

    }

	public enum CardAddStatus {
		Added,
		Removed,
		Failed,
	}

    public CardAddStatus AddActiveCard(Status status)
    {
		if (this._activeCards.Contains(status)) {
			this._activeCards.Remove(status);
			return CardAddStatus.Removed;
		}

        if (this._activeCards.Count >= this._activeCards.Capacity)
        {
			return CardAddStatus.Failed;
        }
        this._activeCards.Add(status);
		return CardAddStatus.Added;
    }

	public void PlayActiveCards() {
		foreach (Status status in this._activeCards) {
			GameObject parent = status.transform.parent.gameObject;
			this._handcards.Remove(status.transform.parent.gameObject);
			Destroy(parent);
		}
		this._activeCards.Clear();
	}

	public void UpdateCardCounter(Status status) {
		int count;
		if (!this.cardCounter.TryGetValue(status.statusName, out count)) {
			this.cardCounter.Add(status.statusName, 0);
		}

		this.cardCounter[status.statusName] += 1;

		if (this.cardCounter[status.statusName] >= status.unlockCount) {
			GameObject card = Instantiate(status.transform.parent.gameObject, new Vector3(0, 0, -2), Quaternion.identity);
			bool card_exists = false;
			foreach (Card alreadyThere in this.spawnPool) {
				if (alreadyThere.transform.Find("Status").GetComponent<Status>().statusName == status.statusName) {
					card_exists = true;
					break;
				}
			}
			if (!card_exists) {
				this.spawnPool.Add(card.GetComponent<Card>());
			}
		}
	}
}
