using UnityEngine;

public class CastRaycast : Leaf
{
    public override Status Act(IAData data)
    {
        RaycastHit rH;
        bool hit = Physics.Raycast(data.self.transform.position, data.character.transform.position - data.self.transform.position, out rH);
        Debug.DrawLine(data.self.transform.position, data.character.transform.position, new Color(1, 0, 0, 1), 1);
        if (hit)
        {
            data.hitInfo = rH;
            return Status.Succes;
        }
        else
        {
            return Status.Failure;
        }

    }
}
