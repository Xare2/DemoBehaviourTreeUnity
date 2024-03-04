using UnityEngine;

public class DoorRange : Leaf
{
    public override Status Act(IAData data)
    {
        float distance = Vector3.Distance(data.self.transform.position, data.entranceDoor.transform.position);

        if (distance < data.self.actRange)
        {
            return Status.Succes;
        }
        else
        {
            return Status.Failure;
        }
    }
}
