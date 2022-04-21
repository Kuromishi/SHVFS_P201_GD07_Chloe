using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;
using System.Linq;
using System;

public class Evently
{
    //private static eventManagerInstance
    //public static instance => private member
    //Dictionary that maps Types to Delegates
    //public, generic Subscribe method that allows us to subscribe to events
    //public, generic Unsubscribe method that allows us to subscribe to events
    //public, generic Publish method that allows us to subscribe to events

    private static Evently eventManagerInstance;
    //Null coalescing assignment... C# 8.0
    //If it's null, assign it to a new Evently()
    //Otherwise, just return eventManagerInstance (the right side never gets evaluated)
    //just same fancy C# syntax
    public static Evently Instance => eventManagerInstance ??= new Evently();

    private readonly Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>();

    //The signatures for these methods...
    public void Subscribe<T>(Action<T> del)
    {
        if(delegates.ContainsKey(typeof(T)))
        {
            delegates[typeof(T)] = Delegate.Combine(delegates[typeof(T)], del);
        }
        else
        {
            delegates[typeof(T)] = del; //just sign it
        }
    }
    public void Unsubscribe<T>(Action<T> del)
    {
        if (!delegates.ContainsKey(typeof(T))) return;

        var tempDelegate = Delegate.Remove(delegates[typeof(T)], del);
    
        if(tempDelegate == null)
        {
            //Housekeeping, to keep our dictionary clean...
            delegates.Remove(typeof(T));
        }
        else
        {
            delegates[typeof(T)] = tempDelegate; //just sign it
        }
    }

    public void Publish<T>(T e) //publishing the object
    {
        if(e == null)//for safety, if somebody push null...
        {
            Debug.Log($"invalid event arg:{typeof(T)}");
            return;
        }
        if (delegates.ContainsKey(e.GetType()))
        {
            delegates[e.GetType()].DynamicInvoke(e);
        }

    }
}
