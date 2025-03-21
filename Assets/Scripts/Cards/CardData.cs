using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] public Sprite Sprite { get; private set; }
    //[SerializeField] public Sprite Sprite { get; private set; }
    public List<EffectSO> Effects;
}
