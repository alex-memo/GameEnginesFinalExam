using UnityEngine;

public abstract class InputModifierCommand: ScriptableObject, IInputModifier
{
	public T Create<T>(T _original) where T : InputModifierCommand
	{
		T _temp = Instantiate(_original);
		return _temp;
	}
	public abstract void Modify(ref Vector2 _targetMouseDelta);
}
public interface IInputModifier
{
	void Modify(ref Vector2 _targetMouseDelta);
}