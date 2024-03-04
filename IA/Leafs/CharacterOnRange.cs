public class CharacterOnRange : Leaf
{
    public override Status Act(IAData data)
    {
        if (data.self.CharacterOnView)
        {
            return Status.Succes;
        }
        else
        {
            return Status.Failure;
        }
    }
}
