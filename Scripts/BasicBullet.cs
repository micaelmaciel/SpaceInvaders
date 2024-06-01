using Godot;
using System;

public partial class BasicBullet : AnimatableBody2D, Bullet
{
    AutoMove AutoMoveComponent;
    DamageHandler DamageHandlerComponent;
    public float Speed { get; set; } = 10;

    public override void _Ready()
    {
        base._Ready();
        AutoMoveComponent = GetNode<AutoMove>("AutoMove");
        DamageHandlerComponent = GetNode<DamageHandler>("DamageHandler");

        DamageHandlerComponent.HitTaken += (float Damage) => QueueFree();
    }

    public void SetMotion(Vector2 Position, Vector2 Direction, float Speed)
    {
        GlobalPosition = Position;
        AutoMoveComponent.Direction = Direction;
        AutoMoveComponent.Speed = Speed;
    }
}
