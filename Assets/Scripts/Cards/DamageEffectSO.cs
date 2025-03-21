using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Damage")]
public class DamageEffectSO : EffectSO
{
    public int amount;
    public override void Perform()
    {
        Debug.Log("Do " + amount + " Damage");
    }
}
