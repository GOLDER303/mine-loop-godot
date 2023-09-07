using Godot;
using System;
using System.Collections.Generic;

public partial class TunnelManager : Node
{
    [Export]
    private Mesh[] rockMeshes;

    private Godot.Collections.Array<Node> rocks = new();
    private readonly HashSet<int> populatedRocks = new();
    private readonly Random random = new();

    public override void _Ready()
    {
        rocks = GetTree().GetNodesInGroup("rocks");
    }

    public void PopulateTunnel(List<Mesh> requestedResources)
    {
        populatedRocks.Clear();

        foreach (Mesh requestedResource in requestedResources)
        {
            int index = random.Next(0, rocks.Count);
            while (populatedRocks.Contains(index))
            {
                index = random.Next(0, rocks.Count);
            }

            rocks[index].GetChild<MeshInstance3D>(0).Mesh = requestedResource;

            populatedRocks.Add(index);
        }

        for (int i = 0; i < rocks.Count; i++)
        {
            if (populatedRocks.Contains(i))
            {
                continue;
            }

            int rockMeshIndex = random.Next(0, rockMeshes.GetLength(0));

            GD.Print(rockMeshIndex);

            rocks[i].GetChild<MeshInstance3D>(0).Mesh = rockMeshes[rockMeshIndex];
        }
    }
}
