using Godot;
using System;

public partial class AutoMove : Node
{   
    public Vector2 Velocity;

    [Export] public float Speed = 50;
    [Export] public Vector2 Direction = new Vector2(1, 0);
    [Export] public PhysicsBody2D MovingObject;
    [ExportGroup("Overrides")]
    [Export] public bool AutoStart = true;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (AutoStart)
            AutoStartInternal((float) delta);
    }

    public void AutoStartInternal(float delta)
    {
        Velocity = Direction * Speed;
        MovingObject.MoveAndCollide(Velocity * delta);
    }

}
