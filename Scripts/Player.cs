using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [Export]
    private PathFollow3D railsFollowPath;
    [Export]
    private float speed = 10f;

    private float currentProgressRation = 0f;

    public override void _Process(double delta)
    {
        railsFollowPath.ProgressRatio += speed / 100 * (float)delta;

        if (railsFollowPath.Position != Position)
        {
            LookAt(railsFollowPath.Position, Vector3.Up);
        }

        Position = railsFollowPath.Position;
    }
}
