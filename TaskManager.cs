using System;
using System.Collections.Generic;


namespace SharpTasks
{
    class TaskManager {
        private List<Task> m_tasks;

        public TaskManager() {
            m_tasks = new List<Task>();
        }

        public void AddTask(Task task) {
            m_tasks.Add(task);
        }

        public void RemoveTask(int index) {
            m_tasks.RemoveAt(index);
        }

        public void PrintTasks() {
            foreach (Task t in m_tasks) {
                t.Print();
                Console.WriteLine();
            }
        }

        public ref readonly List<Task> GetTasks() { return ref this.m_tasks; }
    }
}
