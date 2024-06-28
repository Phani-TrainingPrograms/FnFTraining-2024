using System;

//A Class is closed for modification. 
class BaseClass{
    public virtual void TestFunc(){
        System.Console.WriteLine("Test Func from base");
    }
    public void NonOverridableFunc(){
        System.Console.WriteLine("This func is from Base only");
    }
}
//If U want to modify a method of the class, then U should go for inheritance. The Base class method must be virtual if U want to override(change) the method.

class DerivedClass : BaseClass{
    public override void TestFunc()
    {
        System.Console.WriteLine("Test Func from Derived");
    }
    //this is more like a new function which is sliced to the base type.
    public void NonOverridableFunc(){
        System.Console.WriteLine("This func is from Derived whoch hides the base version");
    }
    
    public void SecondTestFunc(){
        System.Console.WriteLine("Sec Test Func from Derived");
    }
}

class ClassFactory{
    public static BaseClass CreateObject(string choice){
        if(choice == "Base") return new BaseClass();
        else if(choice== "Derived") return new DerivedClass();
        else throw new Exception("Invalid Choice of class");
    }
}

class MainClass{

    static void firstExample()
    {
        //The derived version will be called only when the method is overriden.
        System.Console.WriteLine("Enter the type U want to create: Base or Derived");
        var obj = ClassFactory.CreateObject(Console.ReadLine());
        obj.TestFunc();
    }
    static void Main(string[] args)
    {
        //firstExample();

        BaseClass cls = new DerivedClass();
        //Do this when U want to access the new members of the derived class that is not defined in the base
        if(cls is DerivedClass){
            //var temp = cls as DerivedClass;
            DerivedClass temp = (DerivedClass)cls;
            temp.SecondTestFunc();
            temp.NonOverridableFunc();
        }
        cls.TestFunc();
        cls.NonOverridableFunc();//call the base version..
        //cls.SecondTestFunc();
    }
}