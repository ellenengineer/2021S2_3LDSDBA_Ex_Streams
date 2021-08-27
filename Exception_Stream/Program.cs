using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Exception_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 - Exceção
           TratamentoExcecao();

            //2 - CriarArquivo
           // CriarArquivo();

            //3 - Cria e le arquivo
            //LerArquivo();

            //4 - Gerencia Diretorio
            //GerenciaDiretorio();

            Console.ReadLine();

        }

        /// <summary>
        /// 2 - Criar Arquivo
        /// </summary>
        static void CriarArquivo()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Fapen\teste.txt"))
                {
                    writer.WriteLine("Primeira linha ");
                    writer.WriteLine("Segunda Linha");
                    writer.WriteLine("Terceira linha do arquivo");
                    writer.Write(" Quarta linha!");
                    writer.WriteLine("mantem na mesma linha!");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "  " + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finalizou a execução");
            }


        }

        /// <summary>
        /// 3 - Gerencia Diretorio
        /// </summary>
        static void GerenciaDiretorio()
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\Dir1");
            try
            {
                if (di.Exists)
                {
                    Console.WriteLine("Diretório já existente.");

                    di.Delete();
                    Console.WriteLine("Diretório Excluído com sucesso!.");

                }
                else
                {
                    di.Create();
                    Console.WriteLine("Diretório Criado com sucesso!.");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao excluir diretório: {0}", e.ToString());
            }
            finally
            {
                Console.WriteLine("Procedimento finalizado!");
            }
        }

        /// <summary>
        /// 3 - Cria e le arquivo
        /// </summary>
        static void LerArquivo()
        {
            string arquivo = @"C:\fapen\teste.txt";
            StringBuilder sb = new StringBuilder();
            if (File.Exists(arquivo))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(arquivo))
                    {
                        String linha;
                        // Lê linha por linha até o final do arquivo
                        while ((linha = sr.ReadLine()) != null)
                        {
                            sb.AppendLine(linha);
                        }
                        Console.WriteLine(sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Operação finalizada!");
                }
            }
            else
            {
                Console.WriteLine(" O arquivo " + arquivo + " não foi localizado !");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 1 - Exceção
        /// </summary>
        static void TratamentoExcecao()
        {
            try
            {
                Console.WriteLine("Digite um número para o numerador!");
                int numerador = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite um número para o denomidador!");
                int denominador = Convert.ToInt32(Console.ReadLine());
                int resultado = 0;

                resultado = numerador / denominador;
            }
            catch (DivideByZeroException)
            {

                Console.WriteLine("Impossível dividir por zero!");
            }
            catch(ArithmeticException ex)
            {
                Console.WriteLine("Erro ao converter dado inserido por número: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Fim de código!");
            }

        }
    }
}
