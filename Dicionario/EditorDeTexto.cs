using System;
using System.Collections.Generic;

namespace Dicionario
{
    internal class EditorDeTexto
    {
        private List<string> Dicionario { get; set; }
        private List<string> Palavras { get; set; }
        private string Texto { get; set; }
        private ConsoleKeyInfo Letra { get; set; }

        public EditorDeTexto()
        {
            Dicionario = new List<string>();
            Palavras = new List<string>();
            Texto = "";
        }

        private void carregarDicionario()
        {
            Dicionario = Database.loadJson();
        }

        private void salvarDicionario()
        {
            // Juntar novas palavras digitadas ao novo dicionario, e ordenar o mesmo antes de salvar.
        }

        private void digitar()
        {
            foreach (string palavra in Palavras)
            {
                if (palavra == " " || palavra == "\n")
                {
                    Colors.reset();
                    Console.Write(palavra);
                }
                else if (!Dicionario.Contains(palavra.ToLower()))
                {
                    Colors.red();
                    Console.Write(palavra);
                }
                else
                {
                    Colors.reset();
                    Console.Write(palavra);
                }
            }
        }

        private void writeConsole()
        {
            Console.Clear();
            if (Texto != "")
            {
                digitar();
                Console.Write(Texto);
            }
            else
            {
                digitar();
            }
        }

        private string pop()
        {
            int index = Palavras.Count - 1;
            string remove = Palavras[index];
            Palavras.RemoveAt(index);
            return remove;
        }

        private void addEspecialKeys(string key)
        {
            Palavras.Add(Texto);
            Palavras.Add(key);
            Texto = "";
        }

        private void eventReadKeys()
        {
            do
            {
                Letra = Console.ReadKey(true);
                if (Letra.Key == ConsoleKey.Enter)
                {
                    addEspecialKeys("\n");
                }
                else if (Letra.Key == ConsoleKey.Spacebar)
                {
                    addEspecialKeys(" ");
                }
                else if (Letra.Key == ConsoleKey.Backspace)
                {
                    if (Texto.Length == 0 && Palavras.Count != 0)
                        Texto = pop();
                    if (Texto.Length != 0)
                        Texto = Texto.Substring(0, Texto.Length - 1);
                }
                else
                {
                    Texto += Letra.KeyChar;
                }

                writeConsole();

            } while (Letra.Key != ConsoleKey.Escape);
        }

        public void run()
        {
            eventReadKeys();
        }

    }
}
