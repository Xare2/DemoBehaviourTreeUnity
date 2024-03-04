using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAHandler
{
    protected IAData data;
    private Node IA;

    public IAHandler(DoorHandler current, DoorHandler goal)
    {
        data = new IAData(GameObject.FindObjectOfType<MonsterHandler>(),
                          GameObject.FindObjectOfType<CharacterHandler>(),
                          current, goal);

        Selector getPoint = new Selector("GetPoint", 
                new Inverter(new CastRaycast()),
                new PointToPlayer(),
                new PointToObject());
        
        Sequence managePoints = new Sequence("ManagePoints",
                new PointToDoor(),
                new CharacterOnRange(),
                getPoint);
        
        IA = new Selector("TheTree",
                new KillRange(),
                managePoints,
                new DoorRange());
    }

    public void Call()
    {
        IA.Call(data);
    }
}
