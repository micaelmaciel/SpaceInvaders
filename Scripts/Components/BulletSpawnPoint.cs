using Godot;
using System;
using System.Collections.Generic;

using Game.Enums;

public partial class BulletSpawnPoint : Marker2D
{   
    [Export] public BulletTypes Bullet = BulletTypes.Basic;
    [Export] public Vector2 Direction { get; set; }
    [Export] public float Speed { get; set; }

    public override void _Ready()
    {
        base._Ready();
    }
}
