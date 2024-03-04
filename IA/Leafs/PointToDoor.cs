using UnityEngine;

public class PointToDoor : Leaf
{
    public override Status Act(IAData data)
    {
        if (data.goalDoor == null)
        {
            Debug.Log("Goad door null");
            return Status.Failure;
        }

        float distance = Vector3.Distance(data.self.transform.position, data.goalDoor.transform.position);

        Point p = new Point(data.goalDoor.transform.position, distance / data.self.actRange);

        data.self.AddPoint(p);

        return Status.Succes;
    }
}
