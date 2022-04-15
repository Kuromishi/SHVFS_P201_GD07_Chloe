using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQExample : MonoBehaviour
{
    //language
    //Integrated
    //Query

    public void OnEnable()
    {
        var names = new[] { "Gary", "Chloe", "Claire", "Rebecca", "EZ", "Ben", "Kevin", "Giselle" };

        //Query Syntax
        var namesWithAQuery = from name in names           //from variable in a List //Query syntax is similar to SQL/database lamguage
                              where name.Contains("C")
                              select name;

        //Method Syntax                                    //Similar to regular methods we see in C#
        var namesWithAMethod = names.Where(name=>name.Contains('C'));

        foreach (var name in namesWithAQuery)
        {
            Debug.Log($"QUERY:{name}");
        }
        foreach(var name in namesWithAMethod)
        {
            Debug.Log($"METHOD:{name}");
        }

        //Method syntax has MORE operators and methods, the compiler converts query syntax anyway...
        //It doesn't really matter which one you use,but keep this in mind..

        var enemies = new List<Enemy>()
        {
            new Enemy(){Name = "Gary",HP=9000, Age=47},
            new Enemy(){Name = "Chris",HP=0, Age=5},
            new Enemy(){Name = "Ben",HP=90, Age=23},
            new Enemy(){Name = "Claire",HP=9000, Age=23},
            new Enemy(){Name = "Chloe",HP=2, Age=23},
            new Enemy(){Name = "Rebecca",HP=10, Age=82},
            new Enemy(){Name = "Giselle",HP=34, Age=47},
            new Enemy(){Name = "Kevin",HP=45, Age=102},
            new Enemy(){Name = "EZ",HP=50, Age=71},
        };

        //Filitering operators:filter a sequence based on some argument or criteria

        //var groupedEnemiesByAge = enemies.GroupBy(enemy => enemy.Age);

        //foreach(var group in groupedEnemiesByAge)
        //{
        //    foreach(var enemy in group)
        //    {
        //        Debug.Log($"Group:{group.Key}|Name:{enemy.Name}|Age:{enemy.Age}");
        //    }
        //}


        //var ages = enemies.Select(enemy => enemy.Age);
        //Debug.Log($"TOTAL AGE:");

        //var isEveryoneNotSuperOld = enemies.All(enemy => enemy.Age < 100);//�����˶�С��100��
        ////var isEveryoneNotSuperOld = enemies.Any(enemy => enemy.Age > 100); //����boolֵ����û���˴���100
        //Debug.Log($"{isEveryoneNotSuperOld}");

        //var youngestEnemy = enemies.OrderBy(enemy => enemy.Age).FirstOrDefault(); //��ȡ���������� ��һ�� Ԫ��

        //if(youngestEnemy != null)
        //{
        //    Debug.Log($"youngestEnemy.Name");
        //}


        //var ages = enemies.Select(enemy => enemy.Age).OrderByDescending(age=>age).Skip(3); //�Ƚ����ţ�������ǰ3��
        //var ages = enemies.Select(enemy => enemy.Age).SkipWhile(age=>age>22); //skip xxx ֱ��������������ϡ�skip��ǰ�����з��������ģ��ӵ�һ�������ϵĿ�ʼѡȡʣ���Ԫ�ء�
        //var ages = enemies.Select(enemy => enemy.Age).Where(age => age < 22);//���Ҫֻ��С�Ļ���������where
        //Take is the opposite of where
        var ages = enemies.Select(enemy => enemy.Age).TakeWhile(age => age > 22); //get ���������ģ�ֱ����һ�γ������������ϾͶ���Ҫ��

        var distinctAges = ages.Distinct();
        foreach(var age in ages)
        {
            Debug.Log($"AGE:{age}");
        }
        foreach(var age in distinctAges)
        {
            Debug.Log($"DISTINCT AGE:{age}");
        }
        //--------------------------select���ص�����ѡ���Ǹ����͡� select age�ͷ���int����
        //--------------------------where��ѡ��age�����صĶ���enemies


        //Lambda... => "goes to"
        //var deadEnemies = enemies.Where(enemy => enemy.HP <= 0);

        ////we could instead...
        //var deadEnemiesBORING = new List<Enemy>();

        //foreach(var enemy in deadEnemies)
        //{
        //    if(enemy.HP <= 0)
        //    {
        //        deadEnemiesBORING.Add(enemy);
        //    }

        //}
        //foreach(var enemy in deadEnemies)
        //{
        //    Debug.Log($"Dead enemy:{enemy.Name}");
        //}

        //Sorting operator���������� :arrange elements in a collection {Orderby,OrderByDescending, ThenBy(Used AFTER OrderBy),ThenByDescending, Reverse}
        //var strongestEnemyFirst = enemies.OrderByDescending(enemy => enemy.HP).ToList();
        //strongestEnemyFirst.ForEach(enemy => Debug.Log($"Name:{enemy.Name}|HP:{enemy.HP}"));

        //Grouping Operators: Creates groups of elements, where each group has a key and inner collection(GroupBy, ToLookup)
        //Joining Operators: joins sequences(Join, GroupJoin )
        //Projection Operators: projects and returns collections / sequences based on a transformation(Select, SelectMany (flattens collections that contain lists of lists)
        //Quantifier Operators: evaluates elements and returns a bool(ALL, Any, Contains)
        //Aggregation Operators: math operations(Aggregate, Average, Count, LongCount, Max, Min, Sum)
        //Element Operators: returns a particular element in the sequence(ElementAt, ElementAtOrDefault, First, First0rDefault, Last, LastOrDefault, Single, Single0rDefault)
        //Equality Operators: checks number, type, value and order are equal(SequenceEqual)
        //Concatenation Operator: appends two sequences(Concat)
        //Generation Operators: returns a new collection with a default value if empty(DefaultIfEmpty, Empty, Range, Repeat)
        //Set Operators: returns new sequences, depending on the operator (Distinct, Except, Intersect, Union)
        //Partitioning Operators: split sequences and return one of the parts(Skip, SkipWhile, Take, TakeWhile)
        //Conversion Operators: convert the type of elements in a sequence(AsEnumerable, AsQueryable, Cast, OfType, ToArray, ToDictionary, ToList, ToLookup)

    }


}
public class Enemy
{
    public string Name;
    public int HP;
    public int Age;
}
