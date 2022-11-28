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
             new Documents {Name = "Diagrama Semântica \"Trabalho Manutenção\"  ", DocPath="/documents/grupo1/tomas_esteves/diagramas/Semântica de Classe_Tomás_Esteves_1704696.pdf"},
             new Documents {Name = "História Utilizador \"Responsável\"", DocPath="/documents/grupo1/tomas_esteves/diagramas/historia_utilizador_tomas_esteves_1704696.pdf"},
        };

        public readonly static List<Documents> DiogoDocuments = new List<Documents>() {
             new Documents {Name = "Diagrama de Classes ", DocPath="/documents/grupo1/Diogo_Neto/Diagrama de Classes - Projeto.drawio-2.pdf"},
             new Documents {Name = "Diagrama de Estados  ", DocPath="/documents/grupo1/Diogo_Neto/Diagrama de Estados_V2.pdf"},
             new Documents {Name = "Máquina - Semântica de Classes  ", DocPath="/documents/grupo1/Diogo_Neto/Máquina - Semântica de Classe.pdf"},
            
        };
    }
}
