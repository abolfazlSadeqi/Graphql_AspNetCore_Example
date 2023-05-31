namespace TestCurd.Model
{
    public class data_All
    {
        public IEnumerable<Person> persons { get; set; }
    }


    public class Person
    {
        public string lastName { set; get; }
    }
}
