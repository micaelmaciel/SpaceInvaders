using Godot;
using System;
using System.Collections.Generic;

using Game.Enums;

public partial class BulletSpawner : Node2D
{
    public Dictionary<BulletTypes, PackedScene> BulletInstances = new Dictionary<BulletTypes, PackedScene>()
    {
        {BulletTypes.Basic, GD.Load<PackedScene>("res://Scenes/basic_bullet.tscn")}
    };

    [Export] public BulletSpawnPoint[] BulletSpawnPoints;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public void Fire()
    {
        foreach (BulletSpawnPoint point in BulletSpawnPoints) {
            Bullet BulletInstance = (Bullet) BulletInstances[point.Bullet].Instantiate();
            GetTree().Root.AddChild((Node) BulletInstance);
            BulletInstance.SetMotion(point.GlobalPosition, point.Direction, point.Speed);
        }
    }
}
