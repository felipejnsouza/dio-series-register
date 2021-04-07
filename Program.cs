using System;

namespace series_register
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "L":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentException("Essa não é uma opção válida!");
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Legal, obrigado por utilizar nossos serviços! ;)");
            Console.WriteLine();            
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var seriesList = repository.List();

            if(seriesList.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach(var serie in seriesList){
                
                var deletedSerie = serie.GetDeleted();

                if(!deletedSerie)
                {
                     Console.WriteLine("#ID {0}: - {1}", serie.GetId(), serie.GetTitle());
                } else {
                     Console.WriteLine("#ID {0}: - {1} - série excluída", serie.GetId(), serie.GetTitle());
                }
                
               
            }
        }

        private static void InsertSerie()
        {
            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int genderCodeEntry = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string serieTitleEntry = Console.ReadLine();

            Console.WriteLine("Digite o Ano de início da série: ");
            int serieYarEntry = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string serieDescriptionEntry = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextID(),
                                        gender: (Gender)genderCodeEntry,
                                        title: serieTitleEntry,
                                        year: serieYarEntry,
                                        description: serieDescriptionEntry);
            
            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            foreach( int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genderCodeEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string serieTitleEntry = Console.ReadLine();

            Console.WriteLine("Digite o Ano de início da série: ");
            int serieYarEntry = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string serieDescriptionEntry = Console.ReadLine();

             Serie updateSerie = new Serie(id: serieIndex,
                                        gender: (Gender)genderCodeEntry,
                                        title: serieTitleEntry,
                                        year: serieYarEntry,
                                        description: serieDescriptionEntry);
            
            repository.Update(serieIndex ,updateSerie);
        }

        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            repository.Delete(serieIndex);
        }

        private static void ViewSerie(){
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            var serie = repository.GetById(serieIndex);

            Console.WriteLine(serie);

        }

         private static string GetUserOption()
            {
                Console.WriteLine();
                Console.WriteLine("Bem vindo ao DIO Series! Estamos felizes por ter você! =D");
                Console.WriteLine();

                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1- Listar séries");
                Console.WriteLine("2- Inserir nova série");
                Console.WriteLine("3- Atualizar série");
                Console.WriteLine("4- Excluir série");
                Console.WriteLine("5- Visualizar série");
                Console.WriteLine("L- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string userOption = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return userOption;
            }
    }
}
