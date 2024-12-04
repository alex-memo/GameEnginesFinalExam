using UnityEngine;

public class InputManager : InstanceFactory<InputManager>
{
	//public Vector2 TargetMouseDelta { get; private set; }
	public InputModifierCommand[] Commands;
	private InputModifierCommand currentCommand;
	private int currentCommandIndex;
	public OnMouseClick OnMouseClick;
	public OnMouseDelta OnMouseDelta;
	protected override void Awake()
	{
		base.Awake();
		if (Commands == null) { return; }
		for (int i = 0; i < Commands.Length; i++)
		{
			Commands[i] = Commands[i].Create(Commands[i]);//we create instances of the commands
		}
		currentCommand = Commands[0];
		currentCommandIndex = 0;
	}
	private void Start()
	{
		GameManager.Instance.OnDuckKilled += cycleCommands;
	}
	protected override void OnDestroy()
	{
		base.OnDestroy();
		OnMouseClick = null;
		OnMouseDelta = null;
	}
	private void Update()
	{
		mouseDeltaInput();
		mouseClickInput();
	}
	private void mouseClickInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			OnMouseClick?.Invoke();
		}
	}
	private void mouseDeltaInput()
	{
		Vector2 _targetMouseDelta = new(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		if (currentCommand == null)
		{
			OnMouseDelta?.Invoke(_targetMouseDelta);
			return;
		}
		currentCommand.Modify(ref _targetMouseDelta);
		OnMouseDelta?.Invoke(_targetMouseDelta);
	}
	private void cycleCommands()
	{
		currentCommandIndex = (1 + currentCommandIndex) % Commands.Length;
		currentCommand = Commands[currentCommandIndex];
	}
}
public delegate void OnMouseClick();
public delegate void OnMouseDelta(Vector2 _delta);