using UnityEngine;
[CreateAssetMenu(fileName = "Inverted", menuName = "Modifiers/Inverted")]
public class InvertedModifier : InputModifierCommand
{
    public override void Modify(ref Vector2 _targetMouseDelta)
    {
        _targetMouseDelta *= -1;
    }
}
