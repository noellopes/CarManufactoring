using CarManufactoring.ViewModels.Group1;

namespace CarManufactoring.ViewModels.Group3


{
    public class Group3Documents
    {
        public readonly static List<Documents> G3Documents = new List<Documents>()
        {
            new Documents { Name = "Final Report (PDF)", DocPath = "/documents/Group3/GroupDocumentation/RelatorioFinal_ES2.pdf"},
            new Documents { Name = "Final Report (Word)", DocPath = "/documents/Group3/GroupDocumentation/RelatorioFinal_ES2.docx"},
             new Documents { Name = "Presentation", DocPath = "/documents/Group3/GroupDocumentation/CarManufacturing.pptx"},

        };

        public readonly static List<Documents> LuisDocuments = new List<Documents>()
        {
            new Documents {Name = "Traceability's matrix", DocPath="/documents/Group3/LuisBarros/MatrizRastreabilidade.pdf"},
            new Documents {Name = "Look alike applications", DocPath="/documents/Group3/LuisBarros/Aplicacoes.pdf"},
            new Documents {Name ="Tests Table", DocPath = "/documents/Group3/LuisBarros/TabelaTestes.pdf"},
            new Documents {Name = "User Stories", DocPath= "/documents/Group3/LuisBarros/UserStories.pdf"},
            new Documents {Name = "Order Class Semantics Diagram", DocPath= "/documents/Group3/LuisBarros/SemanticaClasseAtualizada.pdf"},
            new Documents {Name = "Components Diagram", DocPath= "/documents/Group3/LuisBarros/DiagramaComponentes.pdf"},
            new Documents {Name = "Use Case Description Table", DocPath= "/documents/Group3/LuisBarros/DescricaoTabelaCasoDeUso.pdf"},
            new Documents {Name = "Sequence Diagram", DocPath= "/documents/Group3/LuisBarros/DiagramaSequencia.pdf"},
            

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
