//using static Humanizer.In;
using System.Text;
using System;

namespace CarManufactoring.ViewModels {
    public class GroupsStudents {
        public readonly static List<Student> Students = new List<Student>() {
            new Student { Name="Filipe Santos", Number = "1702072", Group = 2},
            new Student { Name="Bruno Martins", Number = "1704756", Group = 2},
            new Student { Name="Rodrigo Luís Santos Lourenço", Number = "1700254", Group = 3},
            new Student { Name="Ricardo Dias Andrade", Number = "1705258", Group = 2},
            new Student { Name="Ana Raquel Neves Vidal", Number = "1705182", Group = 6},
            new Student { Name="João Saraiva Aleixo", Number = "1704473", Group = 6},
            new Student { Name="Luis Antonio Pinto de Barros", Number = "1700331", Group = 3},
            new Student { Name="Tomás de Sousa Esteves", Number = "1704696", Group = 1},
            new Student { Name="Paulo Jorge Mendes Proença", Number = "1704890", Group = 1},
            new Student { Name="Diogo Videira Neto", Number = "1704479", Group = 1},
            new Student { Name="Guilherme Alves", Number = "1701480", Group = 3},
            new Student { Name="Mustafa Bukhari", Number = "1707864", Group = 6},
            new Student { Name="Ricardo Sousa", Number = "1705109", Group = 5},
            new Student { Name="Rui Condesso", Number = "1701429", Group = 5},
            new Student { Name="Pedro Matos", Number = "1700789", Group = 5},
            new Student { Name="Telmo Morais", Number = "1704003", Group = 9},
            new Student { Name="Fabio Abreu", Number = "1704154", Group = 9},
            new Student { Name="Kevin Alves", Number="1704033", Group=7},
            new Student { Name="Francisco Pereira", Number="1704082", Group=7},
            new Student { Name="Leonardo Marques", Number="1704008", Group=7},
            new Student { Name="Juan de Almeida Silva", Number = "1707787", Group = 4},
            new Student { Name="Jucimar Cabral da Costa", Number = "1012639", Group = 4},
            new Student { Name="Rafaela Lopes", Number = "1012659", Group = 4},
            new Student { Name="Propaulo De Sousa Martins Ferreira", Number = "1012646", Group = 8},
            new Student { Name="Fabio Junior Viegas Marques", Number = "1012469", Group = 8},
            new Student {Name ="Mahmut Aran", Number="1707820", Group = 10},
            new Student {Name ="Osman Can Ofraz", Number="1707785", Group = 10},
        };

        public readonly static List<Group> Groups = new List<Group>() {
            new Group{Number=1, Work="Gestão de máquinas/recursos para a produção"},
            new Group{Number=2, Work="Compras ao Fornecedor (peças ou matérias-primas) e critérios de compra de peças"},
            new Group{Number=3, Work="Client's Sales"},
            new Group{Number=4, Work="Feasility analysis of equipment acquisition (machinery/resources for production)"},
            new Group{Number=5, Work="Planear produção com base nas encomendas"},
            new Group{Number=6, Work="Gestão de Turnos da Produção"},
            new Group{Number=7, Work="Gestão de produtos semi-acabados"},
            new Group{Number=8, Work="Encomenda dos Clientes"},
            new Group{Number=9, Work="Inspeção e testes de semi-acabados"},
            new Group{Number=10,Work="scheduling people for the production line of a car factory"},
        };
    }

    
}
