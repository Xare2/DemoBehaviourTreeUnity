using System.Collections.Generic;

public class IAData 
{
    public MonsterHandler self; // A reference to python, hope you like it (well kinda a bad reference buy I mean, don't expect much from me)
    public CharacterHandler character;
    public DoorHandler entranceDoor;
    public DoorHandler goalDoor;
    public UnityEngine.RaycastHit hitInfo;

    public IAData(MonsterHandler m, CharacterHandler c, DoorHandler d, DoorHandler g)
    {
        this.self = m;
        this.character = c;
        this.entranceDoor = d;
        this.goalDoor = g;
        this.hitInfo = new UnityEngine.RaycastHit();
    }
}

public class Point
{
    public float x ;
    public float y;
    public float z;
    public float probability;

    public Point()
    {
        this.x = this.y = this.z = this.probability = 0;
    }

    /// <summary>Constructor for point</summary>
    public Point(float x, float y, float z, float p)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.probability = p;
    }

    public Point(UnityEngine.Vector3 v, float p)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
        this.probability = p;
    }

    public static Point operator- (Point p1, Point p2)
    {
        Point point = new Point();

        point.x = p1.x - p2.x;
        point.y = p1.y - p2.y;
        point.z = p1.z - p2.z;
        point.probability = float.Epsilon;

        return point;
    }

    public static Point operator* (Point p, float f)
    {   
        Point point = new Point(p.x *= f,
                                p.y *= f,
                                p.z *= f,
                                p.probability = f);

        return point;
    }

    public static Point Interpolate(Point p1, Point p2)
    {
        float prob = p1.probability / (p1.probability + p2.probability);
        
        Point point = (p2 - p1);
        point = point * prob;

        return point;
    }
}

public enum Status
{
    Succes,
    Failure,
    Running
}

public abstract class Node
{
    public virtual Status Call(IAData data)
    {
        Status s = Act(data);

        return s;
    }

    public abstract Status Act(IAData data);
}

public abstract class Composite : Node
{
    protected string name;

    protected List<Node> children;

    /// <summary>
    /// Se crea primero los diferentes composite hijos, y se van añadiendo esos hacia arriba :)
    /// Rollo, creas un composite con varios nodos, y luego pones ese composite con otros hijos a otro composite
    /// Se me entiende
    /// </summary>
    public Composite(string name, params Node[] nodes)
    {
        children = new List<Node>();
        children.AddRange(nodes);
    }

}

public abstract class Decorator : Node
{
    protected Node child;

    public Decorator(Node node) 
    {
        child = node;
    }
}

public abstract class Leaf : Node
{

}