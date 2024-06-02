using Godot;
using System;

#nullable enable
public partial class AutoMove : Node
{   
    public Vector2 Velocity;

    [Export] public PhysicsBody2D? MovingObject;
    [Export] public Area2D? CollisionNotificator;
    [Export] public float Speed = 50;
    [Export] public Vector2 Direction = new Vector2(1, 0);
    [ExportGroup("Overrides")]
    [Export] public bool AutoStart = true;
    [Export] public bool HasPendularMovement = false;

    public override void _Ready()
    {
        base._Ready();
        if (HasPendularMovement)
            if (CollisionNotificator != null)
                CollisionNotificator.AreaEntered += PendularMovementInternal;
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
        MovingObject?.MoveAndCollide(Velocity * delta);
    }

    public void PendularMovementInternal(Area2D Area)
    {
        Direction *= -1;
    }

    public override string[] _GetConfigurationWarnings()
    {
        if (AutoStart && MovingObject == null)
            return new string[] { "AutoStart enabled, but no MovingObject assigned." };
        
        return Array.Empty<string>();
    }

}

#nullable disable
