using UnityEngine;

public class Card : MonoBehaviour
{

    [SerializeField] private CardData _data;

    public void PerformEffect()
    {
        Debug.Log(gameObject.name + "'s effect: ");
        foreach (var effect in _data.Effects)
        {
            effect.Perform();
        }
    }
}
