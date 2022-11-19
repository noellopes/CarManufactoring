namespace CarManufactoring.ViewModels.Group1
{
    public class Group1Documents
    {
        public readonly static List<Documents> GroupDocuments = new List<Documents>() {
            new Documents {Name = "Diagrama de Estados ", DocPath="/documents/grupo1/Diagramas/Diagrama_de _Estados.pdf"},
            new Documents {Name = "Diagrama de Classes ", DocPath="/documents/grupo1/Diagramas//Diagrama_Classes_Projeto_Grupo.pdf"},
            new Documents {Name = "Diagrama de Casos de Uso ", DocPath="/documents/grupo1/Diagramas/Diagrama_de_casos_de_uso.pdf"},

        };

        public readonly static List<Documents> TomasDocuments = new List<Documents>() {
             new Documents {Name = "Descrição Caso Uso Finalizar Trabalho  ", DocPath="/documents/grupo1/tomas_esteves/diagramas/descricao_caso_finalizar_trabalho_Tomás_Esteves_1704696.pdf"},
             new Documents {Name = "Diagrama Sequência Criar Tarefa  ", DocPath="/documents/grupo1/tomas_esteves/diagramas/diagrama_sequênica_classe_Tomás_Esteves_1704696V2.drawio.pdf"},
        };
    }
}
