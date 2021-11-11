using System;

namespace Atividades
{
    public class Program
    {
        
        static int[] binarioParaDecimal(String[] binarios){
            
            int[] decimais = new int[binarios.Length];
            
            for(int i = 0; i < binarios.Length; i++)
            {
                decimais[i] = Convert.ToInt32(binarios[i], 2);
            }

            return decimais;

        }

        static String[] decimalParaBinario(int[] inteiros){
            
            String[] binarios = new String[inteiros.Length];
            
            for(int i = 0; i < binarios.Length; i++)
            {
                binarios[i] = Convert.ToString(inteiros[i], 2).PadLeft(11,'0');
            }

            return binarios;             

        }
        static Double[] calcularFitness(int[] inteiros){

            Double[] fitness = new Double[inteiros.Length];
            
            for(int i = 0; i < inteiros.Length; i++)
            {
                fitness[i] = 421 - Math.Abs(inteiros[i] * Math.Sin(Math.Sqrt(Math.Abs(inteiros[i]))));
            }

            return fitness;

        }

        static String[] gerarFilhos(String[] binarios, Double[] fitness, int mutacao){

            String[] filhos = new string[binarios.Length];

            for(int i = 0; i < filhos.Length; i++){

                int divisor = new Random().Next(1,10);

                int Random1 = new Random().Next(0,99);
                int Random2 = new Random().Next(0,99);

                String pai1 = (fitness[Random1] < fitness[Random2] ? binarios[Random1] : binarios[Random2]);

                Random1 = new Random().Next(0,99);
                Random2 = new Random().Next(0,99);

                String pai2 = (fitness[Random1] < fitness[Random2] ? binarios[Random1] : binarios[Random2]);

                String filho = string.Concat(pai1.Substring(0, divisor), pai2.Substring(divisor));

                if(new Random().Next(1,100) <= mutacao){
                    
                    int posicao = new Random().Next(0,10);
                    char[] filhoArray = filho.ToCharArray();

                    switch(filho[posicao]){
                        case '0':
                            filhoArray[posicao] = '1';
                            break;
                        case '1':
                            filhoArray[posicao] = '0';
                            break;
                    }

                    filho = new string(filhoArray);
                    filhos[i] = filho;

                }         

            }
            
            return filhos;

        }

        static void Main(string[] args)
        {
            
            Console.Write("Tamanho da população: ");
            int tamanho = 12;

            Console.Write("Taxa de mutação(0 a 100): ");
            int mutacao = int.Parse("15");

            Console.Write("Quantidade de Gerações: ");
            int geracoes = int.Parse("3");

            int[] inteiros = new int[tamanho];
            String[] binarios = new String[tamanho];
            Double[] fitness = new double[tamanho];
            String[] filhos = new String[tamanho];

            for(int i = 0; i < inteiros.Length; i++)
            {
                inteiros[i] = new Random().Next(1024);
            }

            binarios = decimalParaBinario(inteiros);
            fitness = calcularFitness(inteiros);

            for(int j = 0; j < geracoes; j++){

                filhos = gerarFilhos(binarios, fitness, mutacao);

                binarios = filhos;
                inteiros = binarioParaDecimal(binarios);
                fitness = calcularFitness(inteiros);

            }

            foreach(String item in filhos){
                Console.WriteLine(item);
            }

        }
        
    }

}
