using System;

class Program
{
    static void Main(string[] args)
    {

        Reference reference = new Reference("Proverbios", 3, 5, 6);
        
        string scriptureText = "Confía en Jehová con todo tu corazón, y no te apoyes en tu propia prudencia. Reconócelo en todos tus caminos, y él enderezará tus veredas.";
        
        Scripture scripture = new Scripture(reference, scriptureText);
        
        while (true)
        {

            Console.Clear();
            
            Console.WriteLine(scripture.GetDisplayText());
            
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\n¡Todas las palabras han sido ocultadas! Presiona cualquier tecla para salir.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("\nPresiona Enter para ocultar más palabras o escribe 'quit' para salir.");
            
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); 
        }
    }
}