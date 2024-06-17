using Godot;
using System;

public partial interface Bullet
{
    public float Speed { get; set; }

    public void SetMotion(Vector2 Position, Vector2 Direction, float Speed){}

    public void SetRotation(float rad){}
}
