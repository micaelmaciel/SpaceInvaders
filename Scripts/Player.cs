using Godot;
using System;

public partial class Player : CharacterBody2D
{
    float Speed = 100;

    BulletSpawner FireComponent;

    private void HandleMovement() 
    {
        float Direction = Input.GetAxis("GoLeft", "GoRight");
        Velocity = new Vector2(Speed * Direction, 0);
    }

    public override void _Ready()
    {
        base._Ready();
        FireComponent = (BulletSpawner) GetNode<Node2D>("BulletSpawner");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (Input.IsActionJustPressed("Fire")) FireComponent.Fire();

        HandleMovement();
        MoveAndSlide();
    }
}
