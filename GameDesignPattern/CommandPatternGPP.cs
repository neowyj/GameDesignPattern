using System;
using System.Collections.Generic;

namespace GameDesignPattern
{
    public interface Command
    {
        void execute(GameActor actor);
    }

    class JumpCommand : Command
    {
        public void execute(GameActor actor)  //接口方法默认Public，实现接口必须实现与之对应的函数。
        {
            actor.Jump();
        }
    }

    class FireCommand : Command
    {
        public void execute(GameActor actor)
        {
            actor.Fire();
        }
    }

    class SwapCommand : Command
    {
        public void execute(GameActor actor)
        {
            actor.Swap();
        }
    }

    class LurchCommand : Command
    {
        public void execute(GameActor actor)
        {
            actor.Lurch();
        }
    }

    public class GameActor
    {
        public void Jump()
        {
            Console.WriteLine("Jump");
        }

        public void Fire()
        {
            Console.WriteLine("Fire");
        }

        public void Swap()
        {
            Console.WriteLine("Swap");
        }

        public void Lurch()
        {
            Console.WriteLine("Lurch");
        }
    }

    public class InputHandler
    {
        private List<Command> commandList = new List<Command>();

        public void TakeCommand(Command command)
        {
            commandList.Add(command);
        }

        public void ExecuteCommand(GameActor actor)
        {
            foreach (var command in commandList)
            {
                command.execute(actor);
            }

            commandList.Clear();
        }
    }

    class CommandPatternGPPDemo
    {
        public static void Main2(string[] args)
        {
            GameActor actor = new GameActor();

            JumpCommand jump = new JumpCommand();
            FireCommand fire = new FireCommand();
            SwapCommand swap = new SwapCommand();
            LurchCommand lurch = new LurchCommand();

            InputHandler handler = new InputHandler();
            handler.TakeCommand(jump);
            handler.TakeCommand(fire);
            handler.TakeCommand(swap);
            handler.TakeCommand(lurch);

            handler.ExecuteCommand(actor);
        }
    }
}
