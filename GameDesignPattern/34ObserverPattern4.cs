using System;

public class StatePatternClient
{
    public static void Main1(string[] args)
    {
        Context context = new Context(); //创建环境
        State a = new ConcreteStateA();
        a.Handle(context);
        context.Handle(); //处理请求
    }
}

//环境类
class Context
{
    //定义环境类的初始状态
    private State state;
    
    public Context()
    {
        this.state = new ConcreteStateA();
    }
    //设置新状态
    public void setState(State state)
    {
        this.state = state;
    }
    //读取状态
    public State getState()
    {
        return (state);
    }
    //对请求做处理
    public void Handle()
    {
        state.Handle(this);
    }
}

//抽象状态类
abstract class State
{
    public abstract void Handle(Context context);
}

//具体状态A类
class ConcreteStateA: State
{
    public override void Handle(Context context)
    {
        Console.WriteLine("当前状态是 A.");
        context.setState(new ConcreteStateB());
    }
}

//具体状态B类
class ConcreteStateB: State
{
    public override void Handle(Context context)
    {
        Console.WriteLine("当前状态是 B.");
        context.setState(new ConcreteStateA());
    }
}