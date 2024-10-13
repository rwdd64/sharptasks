using System;


namespace SharpTasks
{
    abstract class Task {
        public string name;

        public Task(string name) { this.name = name; }

        abstract public void Execute();

        virtual public void Print() {
            Console.WriteLine("Name: {0}", this.name);
        }
    }

    class Checkbox : Task {
        private bool check;

        public Checkbox(string name) : base(name) {
            this.check = false;
        }

        override public void Execute() {
            this.check = !this.check;
        }

        override public void Print() {
            Console.WriteLine("[{0}] {1}", this.check ? "\ue63f" : "\ue640", this.name);
        }
    }
}
