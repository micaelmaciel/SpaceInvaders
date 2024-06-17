using Godot;
using System;
using System.Linq;

public partial class BasicEnemy : CharacterBody2D
{   
    [Signal]
    public delegate void ReadyToFireEventHandler(BasicEnemy Enemy);

    BulletSpawner Spawner;
    RayCast2D BottomRay;
    float BottomRayCollisionDistance = 30;
    public bool CanFire = false;

    [Export] float Speed = 70;
    [Export] Vector2 Direction = new Vector2(-1, 0);


    public override void _Ready()
    {
        base._Ready();

        BottomRay = GetNode<RayCast2D>("BottomRay");
        Spawner = GetNode<BulletSpawner>("BulletSpawner");
        SetPhysicsProcess(false);
        Tween tween = CreateTween();
        tween.TweenCallback(Callable.From(() => SetPhysicsProcess(true))).SetDelay(.5f);
        Velocity = Direction * Speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        KinematicCollision2D Collision = MoveAndCollide(Velocity * (float) delta); 
        if (Collision != null) ChangeGroupDirection();
    
        if (!BottomRay.IsColliding()) {
            if (!CanFire) {
                CanFire = true;
                EnemyData.ReadyToFireEnemies.Add(this);
            }
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        if (CanFire) {
            EnemyData.ReadyToFireEnemies.Remove(this);
        }
    }

    public void Fire()
    {
        Spawner.Fire();
    }

    public void ChangeDirection()
    {
        Velocity *= -1;
    }

    public void ChangeGroupDirection()
    {
        GetTree().CallGroup("PendularEnemy", "ChangeDirection");
    }
}
