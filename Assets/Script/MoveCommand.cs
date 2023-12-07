using System.Collections;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform transform;
    private int distance;


    public MoveCommand(Transform transform, int distance)
    {
        this.transform = transform;
        this.distance = distance;
    }

    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(0.25f);
    }
}
