using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    [SerializeField] private CardData _data;

    public Card(CardData _data)
    {
        this._data = _data;
        Effect = _data.Effects;
    }
    
    public Sprite Sprite { get => _data.Sprite; }
    public string Title { get => _data.name; }
    public List<EffectSO> Effect { get; set; }

    public void PerformEffect()
    {
        Debug.Log(gameObject.name + "'s effect: ");
        foreach (var effect in _data.Effects)
        {
            effect.Perform();
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Mouse press funzt");
        HandManager.Instance.AddActiveCard(gameObject);
    }
}
