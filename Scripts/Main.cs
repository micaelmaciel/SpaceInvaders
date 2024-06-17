using Godot;
using System;

public partial class Main : Node2D
{
    Timer BasicEnemyFireRate;

    public override void _Ready()
    {
        base._Ready();
        BasicEnemyFireRate = GetNode<Timer>("BasicEnemyFireRate");
        BasicEnemyFireRate.Timeout += BasicEnemyFire;
    }

    public void BasicEnemyFire()
    { 
        if (EnemyData.ReadyToFireEnemies.Count > 0)
            EnemyData.ReadyToFireEnemies.PickRandom().Fire();
    }
}
