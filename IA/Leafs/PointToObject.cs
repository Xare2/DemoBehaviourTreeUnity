using UnityEngine;

public class PointToObject : Leaf
{
    public override Status Act(IAData data)
    {
        Vector3 corner = GetCorner(data);

        Point p = new Point(corner, Vector3.Distance(corner, data.self.transform.position) / (data.self.actRange / 2));
        data.self.AddPoint(p);
        
        return Status.Succes;
    }

    private Vector3 GetCorner(IAData data)
    {
        Vector3 colPoint = data.hitInfo.point;
        Collider c = data.hitInfo.collider;

        Vector3 min = c.bounds.min;
        
        Vector3 max = c.bounds.max;

        Vector3[] corners = new Vector3[4];
        corners[0] = new Vector3(min.x, 0, min.z);
        corners[1] = new Vector3(min.x, 0, max.z);
        corners[2] = new Vector3(max.x, 0, max.z);
        corners[3] = new Vector3(max.x, 0, min.z);
        
        Vector3 corner = new Vector3();
        float minDistance = Mathf.Infinity;

        foreach (Vector3 vec in corners)
        {
            float d = Vector3.Distance(vec, colPoint);

            if (d < minDistance)
            {
                minDistance = d;
                corner = vec;
            }
        }

        corner += (corner - c.bounds.center);

        return corner;
    }
}
