using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputService : IInputService
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    private const string Button = "Fire";
    public abstract Vector2 Axis { get; }
    
    public bool IsAttackButtonUp() => SimpleInput.GetButtonUp(Button);
    
    protected Vector2 SimpleInputAxis() => new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
}
