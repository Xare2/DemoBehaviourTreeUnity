using UnityEngine;

public class PointToPlayer : Leaf
{
    public override Status Act(IAData data)
    {
        CharacterHandler ch = data.hitInfo.collider.GetComponent<CharacterHandler>();
        if (ch)
        {
            Point p = new Point(ch.transform.position, Mathf.Infinity);
            data.self.AddPoint(p);
            Debug.Log("Point to player");
            return Status.Succes;
        }
        else
        {
            return Status.Failure;
        }
    }
}
