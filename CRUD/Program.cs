﻿namespace CRUD
{
    using System.Collections;
    internal class Program
    {
            static ArrayList equipamentosLista = new ArrayList();
            static ArrayList chamadosLista = new ArrayList();

            static void Main(string[] args)
            {
                bool continuar = true;
                string[] opcoes = { "0-Sair", "1-Opções Equipamentos", "2-Opções Chamados" };
                while (continuar)
                {
                    MostrarMenu(opcoes);
                    int opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 0:
                            continuar = false;
                            break;
                        case 1:
                            OpcoesEquipamentos();
                            break;
                        case 2:
                            OpcoesChamados();
                            break;
                    }
                }
            }

            static void MostrarMenu(string[] menu)
            {
                Console.Clear();
                foreach (string opcao in menu)
                {
                    Console.WriteLine(opcao);
                }
                Console.Write("Digite a opção desejada: ");
            }

            static void OpcoesEquipamentos()
            {
                int id = 0;
                string[] opcoes = { "0-Sair", "1-Cadastrar Equipamento", "2-Mostrar Equipamentos", "3-Atualizar Equipamentos", "4-Remover Equipamento" };
                while (true)
                {
                    MostrarMenu(opcoes);
                    int opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 0:
                            return;
                        case 1:
                            equipamentosLista.Add(cadastrarEquipamento(ref id));
                            break;
                        case 2:
                            MostrarEquipamentos();
                            break;
                        case 3:
                            AtualizarEquipamento();
                            break;
                         case 4:
                            RemoverEquipamento();
                            break;
                }
                Console.WriteLine("Operação finalizada!");
                Console.ReadLine();
                }
            }

            static string[] cadastrarEquipamento(ref int id)
            {
                string[] equipamento;
                while (true)
                {
                    equipamento = new string[6];
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    if (nome.Length < 6)
                    {
                        Console.WriteLine("Digite um nome com no mínimo 6 caracteres!");
                        Console.ReadLine();
                        continue;
                    }

                    equipamento[1] = nome;
                    Console.Write("Digite o preço de aquisição: ");
                    equipamento[2] = Console.ReadLine();
                    Console.Write("Digite o número de série: ");
                    equipamento[3] = Console.ReadLine();
                    Console.Write("Digite a data de fabricação: ");
                    equipamento[4] = Console.ReadLine();
                    Console.Write("Digite o número de série: ");
                    equipamento[5] = Console.ReadLine();
                    id++;
                    equipamento[0] = "" + id;
                    break;
                }

                return equipamento;
            }

            static void AtualizarEquipamento()
            {
                while (true)
                {
                    Console.Write("Digite o id do equipamento desejado: ");
                    int indice = Convert.ToInt32(Console.ReadLine());
                    int valido = procurarEquipamento(indice + "");
                    if (valido == -1)
                    {
                        Console.WriteLine("O id não existe!");
                        Console.ReadLine();
                        MostrarEquipamentos();
                        continue;
                    }

                    string[] equipamento = (string[])equipamentosLista[valido];
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    if (nome.Length < 6)
                    {
                        Console.WriteLine("Digite um nome com no mínimo 6 caracteres!");
                        Console.ReadLine();
                        continue;
                    }

                    equipamento[1] = nome;
                    Console.Write("Digite o preço de aquisição: ");
                    equipamento[2] = Console.ReadLine();
                    Console.Write("Digite o número de série: ");
                    equipamento[3] = Console.ReadLine();
                    Console.Write("Digite a data de fabricação: ");
                    equipamento[4] = Console.ReadLine();
                    Console.Write("Digite o número de série: ");
                    equipamento[5] = Console.ReadLine();
                    break;
                }
            }

            static int procurarEquipamento(string indice)
            {
                for (int i = 0; i < equipamentosLista.Count; i++)
                {
                    String[] equipamento = (string[])equipamentosLista[i];
                    if (equipamento[0] == indice)
                    {
                        return i;
                    }
                }

                return -1;
            }

            static void RemoverEquipamento()
            {
                Console.Write("Digite o id do equipamento desejado: ");
                int indice = Convert.ToInt32(Console.ReadLine());
                int valido = procurarEquipamento(indice + "");
                if (valido == -1)
                {
                    Console.WriteLine("O id não existe!");
                    Console.ReadLine();
                    return;
                }
                equipamentosLista.RemoveAt(valido);
            }

            static void MostrarEquipamentos()
            {
                Console.Clear();
                Console.Write("Id: ".PadRight(20));
                Console.Write("Nome: ".PadRight(20));
                Console.Write("Preço: ".PadRight(20));
                Console.Write("Número de Série: ".PadRight(20));
                Console.Write("Data de Fabricação: ".PadRight(20));
                Console.WriteLine("Fabricante: ".PadRight(20));
                foreach (String[] equipamento in equipamentosLista)
                {
                    Console.Write(equipamento[0].PadRight(20));
                    Console.Write(equipamento[1].PadRight(20));
                    Console.Write(equipamento[2].PadRight(20));
                    Console.Write(equipamento[3].PadRight(20));
                    Console.Write(equipamento[4].PadRight(20));
                    Console.WriteLine(equipamento[5].PadRight(20));
                }
            }

            static void OpcoesChamados()
            {
                int id = 0;
                string[] opcoes = { "0-Sair", "1-Cadastrar Chamado", "2-Mostrar Chamados", "3-Atualizar Chamados", "4-Remover Chamado" };
                while (true)
                {
                    MostrarMenu(opcoes);
                    int opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 0:
                            return;
                        case 1:
                            if (equipamentosLista.Count > 0)
                            {
                                chamadosLista.Add(cadastrarChamado(ref id));
                            }
                            else
                            {
                                Console.WriteLine("Não existe equipamentos cadastrados!");
                            }
                            break;
                        case 2:
                            MostrarChamados();
                            break;
                        case 3:
                            AtualizarChamado();
                            break;
                        case 4:
                            RemoverChamado();
                            break;
                    }
                    Console.WriteLine("Operação finalizada!");
                    Console.ReadLine();
                }
            }

            static string[] cadastrarChamado(ref int id)
            {
                string[] chamado;
                while (true)
                {
                    chamado = new string[6];
                    Console.Write("Digite o id do equipamento: ");
                    int indice = Convert.ToInt32(Console.ReadLine());
                    int valido = procurarEquipamento(indice + "");
                    if (valido == -1)
                    {
                        Console.WriteLine("O id não existe!");
                        Console.ReadLine();
                        MostrarEquipamentos();
                        continue;
                    }
                    chamado[1] = ((string[])equipamentosLista[valido])[1];
                    Console.Write("Digite o título: ");
                    chamado[2] = Console.ReadLine();
                    Console.Write("Digite a descricão: ");
                    chamado[3] = Console.ReadLine();
                    Console.Write("Digite a data de abertura(dd/mm/yyyy): ");
                    chamado[4] = Console.ReadLine();
                    DateTime data = DateTime.ParseExact(chamado[4], "dd/MM/yyyy", null);
                    TimeSpan dias = DateTime.Now - data;
                    chamado[5] = dias.Days + "";
                    id++;
                    chamado[0] = "" + id;
                    break;
                }

                return chamado;
            }

            static void AtualizarChamado()
            {
                while (true)
                {
                    Console.Write("Digite o id do chamado desejado: ");
                    int indice = Convert.ToInt32(Console.ReadLine());
                    int valido = procurarChamado(indice + "");
                    if (valido == -1)
                    {
                        Console.WriteLine("O id não existe!");
                        Console.ReadLine();
                        MostrarChamados();
                        continue;
                    }

                    string[] chamado = (string[])chamadosLista[valido];
                    Console.Write("Digite o id do equipamento: ");
                    indice = Convert.ToInt32(Console.ReadLine());
                    valido = procurarEquipamento(indice + "");
                    if (valido == -1)
                    {
                        Console.WriteLine("O id não existe!");
                        Console.ReadLine();
                        MostrarEquipamentos();
                        continue;
                    }
                    chamado[1] = ((string[])equipamentosLista[valido])[1];
                    Console.Write("Digite o título: ");
                    chamado[2] = Console.ReadLine();
                    Console.Write("Digite a descricão: ");
                    chamado[3] = Console.ReadLine();
                    Console.Write("Digite a data de abertura(dd/mm/yyyy): ");
                    chamado[4] = Console.ReadLine();
                    DateTime data = DateTime.ParseExact(chamado[4], "dd/MM/yyyy", null);
                    TimeSpan dias = DateTime.Now - data;
                    chamado[5] = dias.Days + "";
                    break;
                }
            }

            static int procurarChamado(string indice)
            {
                for (int i = 0; i < chamadosLista.Count; i++)
                {
                    String[] chamado = (string[])chamadosLista[i];
                    if (chamado[0] == indice)
                    {
                        return i;
                    }
                }

                return -1;
            }

            static void RemoverChamado()
            {
                Console.Write("Digite o id do chamado desejado: ");
                int indice = Convert.ToInt32(Console.ReadLine());
                int valido = procurarChamado(indice + "");
                if (valido == -1)
                {
                    Console.WriteLine("O id não existe!");
                    Console.ReadLine();
                    return;
                }
                chamadosLista.RemoveAt(valido);
            }

            static void MostrarChamados()
            {
                Console.Clear();
                Console.Write("Id: ".PadRight(20));
                Console.Write("Equipamento: ".PadRight(20));
                Console.Write("Título: ".PadRight(20));
                Console.Write("Descrição: ".PadRight(20));
                Console.Write("Data de Abertura: ".PadRight(20));
                Console.WriteLine("Dias em Abertura: ".PadRight(20));
                foreach (String[] chamado in chamadosLista)
                {
                    Console.Write(chamado[0].PadRight(20));
                    Console.Write(chamado[1].PadRight(20));
                    Console.Write(chamado[2].PadRight(20));
                    Console.Write(chamado[3].PadRight(20));
                    Console.Write(chamado[4].PadRight(20));
                    Console.WriteLine(chamado[5].PadRight(20));
                }
            }
        }
    }