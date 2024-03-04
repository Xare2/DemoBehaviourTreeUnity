using UnityEngine;

public class KillRange : Leaf
{
    public override Status Act(IAData data)
    {
        float distance = Vector3.Distance(data.self.transform.position, data.character.transform.position);

        if (distance < data.self.actRange)
        {
            data.character.Die();

            return Status.Succes;
        }
        else
        {
            return Status.Failure;
        }
    }
}
