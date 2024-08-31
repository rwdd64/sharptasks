using System;


namespace SharpTasks
{
    enum TaskType : uint {
        CHECK = 0, // Checkbox | Indica se foi finalizada (marcada) ou não
    };

    struct Task {
        public TaskType type;
        public string name;

        public Task(TaskType _type, string _name)
        {
            type = _type;
            name = _name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Índice do último item 'válido' do vetor (não necessariamente o item que se encontra em 'tamanho-1')
            // Inicia -1 pois não existe nenhum item em 'tasks'
            int last_index = -1;

            Task[] tasks = {};

            /*
             * TESTES
             *

            Task task = new Task(TaskType.CHECK, "AAAAAA");

            AddTask(task);
            PrintTasks();
            AddTask(task);
            PrintTasks();
            AddTask(task);
            PrintTasks();
            */

            void AddTask(Task task)
            {
                // Redimensionar (dobrar) o array caso não haja mais espaço
                if (last_index+1 >= tasks.Length)
                {
                    int new_size = (tasks.Length==0 ? 1 : tasks.Length)*2;
                    Array.Resize(ref tasks, new_size);
                }

                last_index++;
                tasks[last_index] = task;
            }

            void PrintTasks()
            {
                for (int i = 0; i < tasks.Length; ++i)
                {
                    Console.WriteLine("Type: {0}", tasks[i].type);
                    Console.WriteLine("Name: {0}", tasks[i].name);
                    Console.WriteLine();
                }
            }
        }
    }
}
