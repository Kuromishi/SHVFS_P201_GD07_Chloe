using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;
using System.Linq;

public class GenericExample : MonoBehaviour
{
    public void OnEnable()
    {
        //GetComponent is a generic method...
        //We can have generic methods AND generic classes
        //var animator = gameObject.GetComponent<Animator>();

        //var pairIntInt = new PairIntInt() { First = 5, Second = 65 };
        //Debug.Log($"Type:{pairIntInt.GetType().Name}|First:{pairIntInt.First}|Second:{pairIntInt.Second}");


        //var pair = new PairIntFloat() { First = 5, Second = 65.3452f };
        //Debug.Log($"Type:{pair.GetType().Name}|First:{pair.First}|Second:{pair.Second}");


        //var pair = new PairStringString() { First = "Bob", Second = "Billy" };
        //Debug.Log($"Type:{pair.GetType().Name}|First:{pair.First}|Second:{pair.Second}");

        var pair = new Pair<string, float> { First = "Bob", Second = 64.111f };
        Debug.Log($"Type:{pair.GetType().Name}|First:{pair.First}|Second:{pair.Second}"); //����ʾPair'2,������������

        //var pair2 = new Pair<int, IntVector2> { First = 2, Second = IntVector2.down };
        //Debug.Log($"Type:{pair.GetType().Name}|First:{pair.First}|Second:{pair.Second}");

        //Debug.Log($"TYPES EQUAL ?|{pair.GetType() == pair2.GetType()}"); //The two are different type, return FALSE

        //MyClass.value = 10;
        //MyClass.value = 23;
        //MyClass.value = 68;

        //Debug.Log(MyClass.value);
        //Debug.Log(MyClass.value);
        //Debug.Log(MyClass.value);
        //��������68

        //MyClass<string>.value = 10;
        //MyClass<int>.value = 23;
        ////The static constructor is NOT run here, the second time it's accessed
        //MyClass<string>.value = 20; //ֻ�ܸ��ǣ����ܴ�������ͬ��stringֵ��debug����20������10��
        //MyClass<float>.value = 68;

        //Debug.Log(MyClass<string>.value);
        //Debug.Log(MyClass<int>.value);
        //Debug.Log(MyClass<string>.value);
        //Debug.Log(MyClass<float>.value);
        // ������ͬ�����ֵ
        //MyClass'1 �ǵ�һ������ֵ

        //With Generic methods, the compiler is SMART enough to know the type
        //var numbers = new List<int>() { 123, 45, 6, 2, 7, 88 };
        ////PrintTheNumbers(numbers);
        ////PrintTheThings(numbers);
        ////var returnedNumbers = PrintTheThingsReturnSome<int>(numbers, 3);
        //var returnedNumbers = PrintTheThingsReturnSome(numbers, 3); //����д���ͣ���֪����ʲô

        //foreach (var number in returnedNumbers)
        //{
        //    Debug.Log($"RETURNED NUMBER:{number}");
        //}


        //var names = new List<string>() { "Bob", "Billy", "Sarah" };

        ////PrintTheThings(names);
        //var returnedNames = PrintTheThingsReturnSome(names, 2);

        //foreach(var returnedName in returnedNumbers)
        //{
        //    Debug.Log($"RETURNED NUMBER:{returnedNumbers}");
        //}

        //var ClassOne = Produce<ClassOne>();
        //var ClassTwo = Produce<ClassTwo>();
        //Classone.Setup

    }

    // We can have generic classes, and we can also have generic METHODS
    private void PrintTheNumbers(List<int> numbers)
    {
        foreach(var number in numbers)
        {
            Debug.Log($"NUMBER:{number}");
        }
    }
    private void PrintTheThings<T>(List<T> things)
    {
        foreach (var thing in things)
        {
            Debug.Log($"THING:{thing}");
        }
    }

    private List<T> PrintTheThingsReturnSome<T>(List<T> things,int returnCount)
    {
        foreach (var thing in things)
        {
            Debug.Log($"THING:{thing}");
        }

        return things.Take(returnCount).ToList();
    }

    //Constraints are useful, and sometimes necessary, but the more you are...the less your generic method, is a generic method...
    //û���÷��͵������ˣ�ֱ�ӿ��԰� T ���� ClassOne
    private T Produce<T>() where T : ClassOne ,new()
    {
        T returnValue = new T();
        returnValue.Setup(); //T�����ClassOneȥ����setup
        return returnValue;
    }

    private ClassOne Produce()
    {
        ClassOne returnValue = new ClassOne();
        returnValue.Setup(); //T�����ClassOneȥ����setup
        return returnValue;
    }
}

public class PairIntInt
{
    public int First;
    public int Second;
}

public class PairIntFloat
{
    public int First;
    public float Second;
}
public class PairStringString
{
    public string First;
    public string Second;
}

//̫���ظ��� �����Ҷ�����ͬһ����
public class Pair<T1,T2> //���ֲ�ͬ�����ͣ����������κ�Type������һ�������˾Ͳ��ܸ��ģ�ʹ��ʱ��
{
    public T1 First;
    public T2 Second;
}

public class Pair2<T>  //T can be any type but first only one T, so the unknown type can only be one
{
    public T First;
    public T Second;
}

//This is not EXACTLY what happens... The compiler in reality has RESERVED CHARACTERS it uses to create unique,compiler generated class names
//public class PairSPECIALCHARACTER1
//{
//    public string First;
//    public float Second;
//}

//public class PairSPECIALCHARACTER2
//{
//    public int First;
//    public IntVector2 Second;
//}

//public class MyClass
//{
//    public static int value;   //generic class,static field
//    static MyClass() //static constructor
//    {
//        Debug.Log(typeof(MyClass));
//    }
//}

public class MyClass<T>
{
    public static int value;   //generic class,static field
    static MyClass() //static constructor
    {
        Debug.Log(typeof(MyClass<T>));
    }
}

//We can put constraints on our generic type arguments...
public class ClassOne
{
    public void Setup()
    {
        Debug.Log("fufufufufufu");
    }
}
