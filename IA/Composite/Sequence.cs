
public class Sequence : Composite
{
    public Sequence(string name, params Node[] nodes) : base(name, nodes)
    {
        
    }

    public override Status Act(IAData data)
    {
        foreach (Node n in children)
        {
            Status s = n.Call(data);

            if (s == Status.Failure) 
            {
                return Status.Failure;
            }
        }
        
        return Status.Succes;
    }
}