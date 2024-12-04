using UnityEngine;
[CreateAssetMenu(fileName = "Neutral", menuName = "Modifiers/Neutral")]
public class NeutralModifier : InputModifierCommand
{
    public override void Modify(ref Vector2 _targetMouseDelta)
    {
       //we do nothing
    }
}