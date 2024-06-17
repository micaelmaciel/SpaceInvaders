using Godot;
using System;

public partial class HurtboxComponent : Area2D
{
    [Signal]
    public delegate void HitTakenEventHandler(float Damage);
    [Signal]
    public delegate void DestroyedEventHandler();

    private float CurrentHealth;
    private bool FlashRed = false;
    private bool FlashWhite = false;

    [Export] Sprite2D VisibleObject;
    [Export] Node2D CollisionReactor;
    [Export] DamageableStats DamageStats = new DamageableStats();
    [ExportGroup("Overrides")]
    [Export] bool HasDamageOverride = false;
    [Export] bool HasDestroyedOverride = false;

    public override void _Ready()
    {
        base._Ready();
        CurrentHealth = DamageStats.StartingHealth;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (VisibleObject != null)
        {
            if (FlashRed) {
                VisibleObject.Modulate = Colors.Red;
                FlashRed = false;
                FlashWhite = true;
            } else if (FlashWhite) {
                VisibleObject.Modulate = Colors.White;
                FlashWhite = false;
            }
        }

    }

    public void TakeDamage(float Damage)
    {
        if (HasDamageOverride) EmitSignal(SignalName.HitTaken, Damage);
        else TakeDamageInternal(Damage);
    }

    public void TakeDamageInternal(float Damage)
    {
        FlashRed = true;
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0){
            if (HasDestroyedOverride) EmitSignal(SignalName.Destroyed);
            else DestroyedInternal();
        }
    }

    public void DestroyedInternal()
    {
        CollisionReactor.QueueFree();
    }
}
