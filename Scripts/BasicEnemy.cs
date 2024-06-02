using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
    DamageHandler CollisionComponent;

    public override void _Ready()
    {
        base._Ready();
        Velocity = new Vector2(-1, 0);

        CollisionComponent = GetNode<DamageHandler>("DamageHandler");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

    }
}
