namespace CarManufactoring.ViewModels {
    public class Group {
        public int Number { get; set; }
        public string Work { get; set; }

        public IEnumerable<Student> Students => 
           GroupsStudents.Students.Where(s => s.Group == Number).OrderBy(s => s.Name);
        
    }
}
