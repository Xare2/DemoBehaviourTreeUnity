using System.Collections;

public class Selector : Composite
{
    public Selector(string name, params Node[] nodes) : base(name, nodes)
    {
        
    }

    public override Status Act(IAData data)
    {
        foreach (Node n in children)
        {
            Status s = n.Call(data);

            if (s == Status.Succes) 
            {
                return Status.Succes;
            }
        }
        
        return Status.Failure;
    }
}
