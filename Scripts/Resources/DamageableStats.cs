using Godot;
using System;

using MonoCustomResourceRegistry;

[RegisteredType(nameof(DamageableStats), "", nameof(Resource))]
public partial class DamageableStats : Resource
{
    [Export] public float StartingHealth { get; set; }
    [Export] public float Defense { get; set; }

    public DamageableStats() {
        StartingHealth = 100;
        Defense = 0;
    }
}
