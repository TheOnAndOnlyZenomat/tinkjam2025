using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private SpriteRenderer cardImage;
    [SerializeField] private TMP_Text title;
    //[SerializeField] private TMP_Text ;

    private Card _card;

    public void Setup(Card _card)
    {
        this._card = _card;
        cardImage.sprite = _card.Sprite;
        title.text = _card.Title;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _card.PerformEffect();
        Destroy(gameObject);
    }
}
