using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//Enums in eigenes .cs file 
public enum Typ
{
    cook, 
    friday,
    dog,
}

public enum ActionType
{
    unknown,
    build,
    collect,
    explore,
}

public enum Name
{
    cook1,
    cook2,
    friday,
    dog
}

public class Action
{ 
    public GameObject ActionTest;

    public static event EventHandler ActionCreated;
    //Hätte ich in den Character-Klassen gespeichert
    private float numberOfMovesCook;
    private float numberOfMovesFriday;
    private float numberOfMovesDog;
    private List<Position> positions;

    public Action()
    {
        numberOfMovesCook = 2;
        numberOfMovesFriday = 1;
        numberOfMovesDog = 1;

        positions = new List<Position>();

        positions.Add(new Position(Name.cook1, ActionType.unknown, 0));
        positions.Add(new Position(Name.cook2, ActionType.unknown, 0));
        positions.Add(new Position(Name.friday, ActionType.unknown, 0));
        positions.Add(new Position(Name.dog, ActionType.unknown, 0));

        Action.ActionCreated?.Invoke(this, new EventArgs());
    }

    public float getNumberOfMoves(Typ typ)
    {
        if (typ == Typ.cook) return numberOfMovesCook;
        else if (typ == Typ.friday) return numberOfMovesFriday;
        else if (typ == Typ.dog) return numberOfMovesDog;
        else return 0;
        
    }

    public void increaseNumberOfMovesBy(Typ typ, float amount)
    {
        if (typ == Typ.cook) numberOfMovesCook += amount;
        else if (typ == Typ.friday) numberOfMovesFriday += amount;
        else if (typ == Typ.dog) numberOfMovesDog += amount;
    }

    public void decreaseNumberOfMovesBy(Typ typ, float amount)
    {
        if (typ == Typ.cook) numberOfMovesCook -= amount;
        else if (typ == Typ.friday) numberOfMovesFriday -= amount;
        else if (typ == Typ.dog) numberOfMovesDog -= amount;
    }

    public List<Position> GetPositions()
    {
        return positions;
    }
}

//Neues .cs file
public class Position
{

    public Name name { get; set; }
    public ActionType actionType { get; set; }
    public float value { get; set; }

    public Position(Name name, ActionType actionType, float value)
    {
        this.name = name;
        this.actionType = actionType;
        this.value = value;
    }
}