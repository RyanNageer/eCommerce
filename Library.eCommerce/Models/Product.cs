namespace Spring2025_Samples.Models
{
    public class Product
    {
        

        /*
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        
        
        public string Name { // field keyword
            get { return name;}
            set {name = value;}} 
*/

        public int Id { get; set;}
        public string? Name { get; set;} // string? means the string is nullable and won't cause an error

        public string? Display 
        {
            get { return $"{Id}. {Name}";}
        }

        public Product()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return Display ?? string.Empty ;
        }

    }
}