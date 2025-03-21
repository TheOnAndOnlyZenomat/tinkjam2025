using UnityEngine;

[CreateAssetMenu(menuName = "Effect/DrawCard")]
public class DrawCardEffectSO : EffectSO
{
    public override void Perform()
    {
        Debug.Log("Draw 1 Card...");
    }
}
