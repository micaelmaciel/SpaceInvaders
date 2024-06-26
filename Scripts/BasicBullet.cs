using Godot;
using System;

public partial class BasicBullet : AnimatableBody2D, Bullet
{
    AutoMove AutoMoveComponent;
    HitboxComponent HurtboxComponentComponent;
    public float Speed { get; set; } = 10;

    public override void _Ready()
    {
        base._Ready();
        AutoMoveComponent = GetNode<AutoMove>("AutoMove");
        HurtboxComponentComponent = GetNode<HitboxComponent>("HitboxComponent");

        HurtboxComponentComponent.AreaEntered += (Area2D Area) => QueueFree();
    }

    public void SetMotion(Vector2 Position, Vector2 Direction, float Speed)
    {
        GlobalPosition = Position;
        AutoMoveComponent.Direction = Direction;
        AutoMoveComponent.Speed = Speed;
    }

    public void SetRotation(float rad)
    {
        Rotation = rad;
    }
}
