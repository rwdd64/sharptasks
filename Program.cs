using System;


namespace SharpTasks
{
    class Program {
        static void Main(string[] args) {
            TaskManager task_mgr = new TaskManager();

            Testes(ref task_mgr);

            Menu menu = new Menu(ref task_mgr);
            menu.Init();
        }

        static void Testes(ref readonly TaskManager task_mgr) {
            Task[] tasks = new Task[4];

            tasks[0] = new Checkbox("Batatao");
            tasks[1] = new Checkbox("Lavar a casa");
            tasks[2] = new Checkbox("Zazazaz");
            tasks[3] = new Checkbox("AAAAAAAAAAAA");

            foreach (Task t in tasks) {
                task_mgr.AddTask(t);
            }

            task_mgr.GetTasks()[0].Execute();

            task_mgr.RemoveTask(2);
        }
    }
}
