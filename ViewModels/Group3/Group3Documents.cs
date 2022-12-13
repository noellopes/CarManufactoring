using CarManufactoring.ViewModels.Group1;

namespace CarManufactoring.ViewModels.Group3


{
    public class Group3Documents
    {
        public readonly static List<Documents> G3Documents = new List<Documents>()
        {
            new Documents { Name = "Still in Work Final Report", DocPath = "/documents/Group3/GroupDocumentation/RelatorioFinal_ES2.pdf"},
            new Documents {Name = "States Diagram", DocPath = "/documents/Group3/GroupDocumentation/StateDiagram.png" },
            new Documents {Name = "Classes Diagram", DocPath = "/documents/Group3/GroupDocumentation/ClassesDiagram.png"},
            new Documents {Name = "Use Case Diagram", DocPath= "/documents/Group3/GroupDocumentation/UseCaseDiagram.png"},
        };

        public readonly static List<Documents> LuisDocuments = new List<Documents>()
        {
            new Documents {Name = "User Stories", DocPath= "/documents/Group3/LuisBarros/UserStories.pdf"},
            new Documents {Name = "Order Class Semantics Diagram Updated", DocPath= "/documents/Group3/LuisBarros/SemanticaClasseAtualizada.pdf"},
            new Documents {Name = "Components Diagram", DocPath= "/documents/Group3/LuisBarros/DiagramaComponentes.png"},
            new Documents {Name = "Use Case Description Table", DocPath= "/documents/Group3/LuisBarros/DescricaoTabelaCasoDeUso.pdf"},
            new Documents {Name = "Use Cases Diagram ", DocPath= "/documents/Group3/LuisBarros/DiagramaCasoUSo.drawio.pdf"},
            new Documents {Name = "Sequence Diagram", DocPath= "/documents/Group3/LuisBarros/DiagramaDeSequenciaProjeto.png"},
            new Documents {Name = "Sequence Diagram for Acessories Use Case Only ", DocPath= "/documents/Group3/LuisBarros/DiagramaDeSequenciaProjetoAcessorios.drawio.pdf"},
            new Documents {Name = "Order Class Semantics Diagram", DocPath= "/documents/Group3/LuisBarros/SemanticaClasse.pdf"},
            

        };

        public readonly static List<Documents> GuiDocuments = new List<Documents>()
        {
          
            new Documents {Name = "Use Cases Diagram ", DocPath= "/documents/Group3/GuilhermeAlves/Projeto_ES2/DiagramaCasoUsoProjeto/DiagramaCasoUsosProjeto.drawio.png"},
            new Documents {Name = "Sequence Diagram", DocPath= "/documents/Group3/GuilhermeAlves/Projeto_ES2/DiagramaSequenciaProjeto/DiagramaSequenciaProjeto.drawio.png"},
          
        };

        public readonly static List<Documents> RodrigoDocuments = new List<Documents>()
        {

        };


    }
}
