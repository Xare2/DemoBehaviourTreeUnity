public class Inverter : Decorator
{
    public Inverter(Node child) : base(child)
    {

    }

    public override Status Call(IAData data)
    {
        switch(child.Act(data))
        {
            case Status.Running:
                return Status.Running;

            case Status.Succes:
                return Status.Failure;

            case Status.Failure:
                return Status.Succes;
        }

        return Status.Failure;
    }

    public override Status Act(IAData data) { return Status.Failure; }
}