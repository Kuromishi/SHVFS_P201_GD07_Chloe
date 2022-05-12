using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;
using System.Linq;
using System;

public class DelegateExample : MonoBehaviour
{
    //A CLASS BUT CAN TREAT LIKE A METHOD!!!!!!!!!!!!!!!
    //The compiler converts this into a class...
    //class MeDelegate()
    //And since it's a class, we can create a NEW object from it...
    //sort of like methods, work with methods like objects
    public delegate void MeDelegate();
    public delegate bool MeDelegateInt(int n); //Take int, return bool
    public delegate int MeDelegateReturnInt();
    public delegate T MeDelegateGeneric<T>();  //signature: [take xx, return xxx]
    //take no argument, return T

    public void OnEnable()
    {
        //We're NOT invoking Foo, we're just passing it!
        //MeDelegate meDelegate = new MeDelegate(Foo);
        /*This is a reference to a class...but it's also treated like a method...
        The compiler is helping us here.We can call/invoke it with...
        */

        //meDelegate.Invoke();
        ////We can also invoke it like this... the compiler gives us this syntatic sugar
        ////if we write it like this, the compiler will turn it into meDelegate.Invoke();
        //meDelegate();

        ////meDelegate references Foo, so it's a reference to an object, and a method....
        ////This is some more syntactic suagr...a shorter way,but gets turned into the full bit in line 18
        //MeDelegate meDelegate2 = Goo;
        //meDelegate2();

        //we're treating methods like first class objects
        ////wrap your heads around this...
        //InvokeTheDelegate(new MeDelegate(Goo));
        //InvokeTheDelegate(Goo);

        //Delegates are references to objects AND methods
        //Debug.Log($"Target:{meDelegate.Target}|Methods:{meDelegate.Method}");
        //Debug.Log($"Target:{meDelegate2.Target}|Methods:{meDelegate2.Method}");

        //Debug.Log(Square(43553));

        //The same reason we parameterize this Square, is why we want to parameterize our code,or references to code(methods)

        //var result = GetAllNumberslessThanFive(new List<int>()
        //{ 3,4,6,7734,3,5,43,35,354,2,23,4,234,1,234,0,53,34});

        //foreach(var number in result)
        //{
        //    Debug.Log(number);
        //}

        //How can we use Delegates to parameterize our GetAllNumbersLessThanXYZ???
        var numbers = new List<int>() { 11, 4, 15, 7, 9, 0, 12, 64 };

        ////Here we'll just change the number...
        //var result = GetAllNumbersGreaterThanThirteen(numbers);

        //foreach (var number in result)
        //{
        //    Debug.Log(number);
        //}

        //before the difference was just the number..but now we've changed the expression...we've changed the CODE

        //var resultLessThanFive = RunNumbersThroughTheGauntlet(numbers,LessThanFive);
        //resultLessThanFive.ForEach(result => Debug.Log($"Less than 5:{result}"));

        //var resultLessThanTen = RunNumbersThroughTheGauntlet(numbers, LessThanTen);
        //resultLessThanTen.ForEach(result => Debug.Log($"LessThanTen:{result}"));

        //var resultGreaterThanThirteen = RunNumbersThroughTheGauntlet(numbers, GreaterThanThirteen);
        //resultGreaterThanThirteen.ForEach(result => Debug.Log($"GreaterThanThirteen:{result}"));

        //This is kind of neat...but...there's a problems,and the problem is...
        //we still have to deal with making these methods:LessThanFive, LessThanTen, etc...
        //There's a ton of junk!
        //Let's go back to Lambas...we're passing in methods...so...why can't we just PASTE the method itself...

        //var resultLessThanFive = RunNumbersThroughTheGauntlet(numbers, static bool GreaterThanThirteen(int n) { return n > 13; });
        //Simplify ↓
        //后面那个 n<5 是一个类型为bool的值，所以他知道你的返回值是bool，n<5，他就知道你的n是int的值了
        //var resultLessThanFive = RunNumbersThroughTheGauntlet(numbers, n=> n < 5); //Take int, return bool
        //resultLessThanFive.ForEach(result => Debug.Log($"Less than 5:{result}"));

        //var resultLessThanTen = RunNumbersThroughTheGauntlet(numbers, n => n < 10);
        //var resultGreaterThanThirteen = RunNumbersThroughTheGauntlet(numbers, n => n > 13);

        //Delegate chaining
        //We can add and remove delegates...
        //These are immuntable! Can't change them!
        //MeDelegate meDelegate = Moo;
        //meDelegate = (MeDelegate)Delegate.Combine(meDelegate, (MeDelegate)Boo); //cast as a MeDelegate
        //meDelegate = meDelegate + Sue;
        //meDelegate += Moo;
        //meDelegate -= Moo;

        //meDelegate.Invoke(); //Debug出MooBooSue

        //foreach(var d in meDelegate.GetInvocationList())
        //{
        //    Debug.Log($"Target:{d.Target}|Method:{d.Method}");
        //}

        //MeDelegateReturnInt meDelegate = ReturnFive;
        //meDelegate += ReturnTen; //The last one
        //var value = meDelegate;
        //Debug.Log(value);

        //foreach(var d in meDelegate.GetInvocationList())
        //{
        //    Debug.Log(d.DynamicInvoke());
        //}

        //MeDelegateGeneric<int> meDelegate = ReturnFive;
        //meDelegate += ReturnTen;

        //foreach(var value in GetAllReturnValues(meDelegate))
        //{
        //    Debug.Log(value);
        //}

        //In reality...you will almost NEVER have to make your own delegates...
        //Microsoft has already made a delegated that we can use for almost every purpose...
        //Funcs and Actions
        //Funcs have a return!

        //Func<int> meDelegate = ReturnFive; //take no argument,return int

        //meDelegate += ReturnTen;

        //foreach (var value in GetAllReturnValuesFunc(meDelegate))
        //{
        //    Debug.Log(value);
        //}

        // The last one(string↓) of Func is their return type
        //// Func<int, string> meDelegate = SquareMessage;
        // Func<int, int,string> meDelegate = MultiplyAndReturnMessage;
        // Debug.Log(meDelegate(5, 20));

        //Actions
        //All Actions return void
        //Action<int> meDelegate = TakeAnIntAndReturnVoid;
        //meDelegate(234);

        //Return smth: Use Func.
        //Return nothing: Use Action.

        //Difference between delegate and events...
        //An event is a delegate with two restrictions: you can't assign to it directly, and you can't invoke it directly
        //Action myAction = ATrainsAComin;
        //myAction += ATrainsAComin;
        //myAction = null;
        //myAction();

        var trainsSignal = new TrainsSignal();
        trainsSignal.TrainsAComing += ATrainsAComin;
        //trainsSignal.TrainsAComing = null;  //can't sign directly
        //trainsSignal.TrainsAComing.Invoke(); //can't invoke directly
    }

    private void ATrainsAComin()
    {
        Debug.Log("Here comes the train!");
    }


    public void TakeAnIntAndReturnVoid(int obj)
    {
        Debug.Log($"Invoking our Action:{obj}");
    }

    private static IEnumerable<T1> GetAllReturnValuesFunc<T1>(Func<T1> d)
    {
        foreach (Func<T1> del in d.GetInvocationList())
        {
            yield return del();
        }
    }

    private static IEnumerable<T1> GetAllReturnValues<T1>(MeDelegateGeneric<T1> d)
    {
        foreach(MeDelegateGeneric<T1> del in d.GetInvocationList())
        {
            yield return del();
        }
    }



    private int ReturnTen() { return 10; }
    private int ReturnFive() { return 5; }

    //static bool GreaterThanThirteen(int n) {return n > 13;}
    //static bool LessThanTen(int n) {return n < 10;}
    //static bool LessThanFive(int n) {return n < 5;}


    private List<int> RunNumbersThroughTheGauntlet(List<int> numbers,MeDelegateInt gauntlet)
    {
        return numbers.Where(number => gauntlet(number)).ToList();
    }


    private static List<int> GetAllNumbersGreaterThanThirteen(List<int> numbers)
    {
        return numbers.Where(number => number > 13).ToList();
    }

    private static List<int> GetAllNumberslessThanFive(List<int>numbers)
    {
        return numbers.Where(number => number < 5).ToList();
    }

    public void InvokeTheDelegate(MeDelegate del)
    {
        del();
    }

    public void Foo()
    {
        Debug.Log("Foo");
    }

    public void Goo()
    {
        Debug.Log("Goo");
    }

    public int Square(int x)
    {
        return x * x;
    }
    public void Moo()
    {
        Debug.Log("Moo");
    }

    public void Boo()
    {
        Debug.Log("Boo");
    }
    public void Sue()
    {
        Debug.Log("Hi,i'm Sue!");
    }

    public string SquareMessage(int x)
    {
        return (x * x).ToString();
    }

    public string MultiplyAndReturnMessage(int x, int y )
    {
        return (x * y).ToString();
    }


    public class TrainsSignal
    {
        public event Action TrainsAComing;
        public void HereComesATrain()
        {
            //if (TrainsAComing != null)
                TrainsAComing?.Invoke();
            //如果问号前面的是null，则该表达式直接返回null. 如果不为空，则继续进行下一步，通过点语法糖获取属性。

        }
    }
}
