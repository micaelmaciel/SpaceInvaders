using Godot;
using System;

public partial class HitboxComponent : Area2D
{
    [Export] float Damage = 10;
    [ExportGroup("Overrides")]
    [Export] bool HasHandleCollisionOverride = false;

    public override void _Ready()
    {
        base._Ready();
        if (!HasHandleCollisionOverride)
            AreaEntered += HandleCollision;
    }

    public void HandleCollision(Area2D Area)
    {
        if (Area is DamageHandler Hurtbox) Hurtbox.TakeDamage(Damage);
    }
}
