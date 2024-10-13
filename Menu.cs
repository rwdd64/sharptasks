using System;


namespace SharpTasks
{
    class Menu {
        private TaskManager task_mgr;
        private int selected;
        private bool running;

        public Menu(ref TaskManager task_mgr) {
            this.task_mgr = task_mgr;
            selected = 0;
            running = false;
        }

        public void Init() {
            ConsoleKey input;

            running = true;

            while (running) {
                Console.Clear();

                ShowTitle();
                ShowTasks();
                ShowCommands();

                input = Console.ReadKey().Key;
                Console.WriteLine();

                HandleInput(input);
            }
        }

        private void ShowTitle() { Console.WriteLine("sharptasks"); }

        private void ShowCommands() {
            Console.WriteLine("Comandos:");
            Console.WriteLine("a - Adicionar nova tarefa");
            Console.WriteLine("space - Executar ação na tarefa");
            Console.WriteLine("\ueaa0 ou k - Selecionar tarefa superior");
            Console.WriteLine("\uea9d ou j - Selecionar tarefa inferior");
            Console.WriteLine("q - Sair");
        }

        private void ShowTasks() {
            for (int i = 0; i < task_mgr.GetTasks().Count; ++i) {
                //Mudar as cores caso seja a tarefa selecionada
                if (i == selected) {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                task_mgr.GetTasks()[i].Print();

                // Resetar as cores para o normal
                if (i == selected) {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private void HandleInput(ConsoleKey input) {
            switch (input) {
                case ConsoleKey.A:
                    AddTaskDialog();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.K:
                    if (selected-1 >= 0) selected--; // Subir se NÃO ESTIVER fora da lista
                    else selected = task_mgr.GetTasks().Count-1; // Caso esteja, "loopar" para o fim
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.J:
                    if (selected+1 < task_mgr.GetTasks().Count) selected++; // Descer se NÃO ESTIVER fora da lista
                    else selected = 0; // Caso esteja, "loopar" para o início
                    break;
                case ConsoleKey.Spacebar:
                    task_mgr.GetTasks()[selected].Execute(); // Executar a tarefa selecionada
                    break;
                case ConsoleKey.Q:
                    running = false;
                    break;
                default:
                    break;
            }
        }

        private void AddTaskDialog() {
            ConsoleKey input;
            string name;

            Console.WriteLine("Tipos de tarefa:");
            Console.WriteLine("1. Checkbox");
            Console.Write("Escolha o tipo da tarefa...");

            input = Console.ReadKey().Key;
            Console.WriteLine();

            Console.Write("Digite o nome da tarefa...");
            name = Console.ReadLine();

            switch (input) {
                case ConsoleKey.D1:
                    task_mgr.AddTask(new Checkbox(name));
                    break;
                default:
                    break;
            }
        }

    }
}
