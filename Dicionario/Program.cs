using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Dicionario
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            // EditorDeTexto editor = new EditorDeTexto();
            // editor.run();


            List<string> dados = new List<string>()
            {
                "abac",
                "aaac",
                "aaa",
                "aab"
            };
            
            
            int inicio = 0;
            int final = dados.Count - 1;

            while (true)
            {
                bool trocou = false;
                for (int i = final; i > inicio; i--)
                {
                    string v2 = dados[i].ToLower();
                    string v1 = dados[i - 1].ToLower();
                    int compara = string.Compare(v1, v2);
                    if (compara == 1)
                    {
                        dados[i] = v1;
                        dados[i - 1] = v2;
                        trocou = true;
                    }
                }
                inicio++;
                for (int i = inicio; i < final; i++)
                {
                    string v2 = dados[i + 1].ToLower();
                    string v1 = dados[i].ToLower();
                    int compara = string.Compare(v1, v2);
                    if (compara == 1)
                    {
                        dados[i] = v2;
                        dados[i + 1] = v1;
                        trocou = true;
                    }
                }
                final--;
                if (!trocou) break;
            }

            foreach (var item in dados) 
            {
                Console.Write(item + " ");
            }

        }
    }
}
