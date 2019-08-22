namespace DataMigrationTool
{
    public class Table
    {
        public string Name { get; set; }
        public string SQLName {
            get {
                return "[" + Name + "]";
            }
        }
        public string Schema { get; set; } = "dbo";
        public bool Target { get; set; } = false;
        public string FullName
        {
            get
            {
                if(Target == false)
                    return Schema + ".[#" + Name + "]";
                else
                    return Schema + ".[" + Name + "]";
            }
        }

    }
}
