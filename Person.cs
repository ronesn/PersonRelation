class Person
{
    public Name FullName { get; set; }
    public Address Address { get; set; }
    public Person(string firstName, string lastName, string street, string city)
    {
        FullName = new Name(firstName, lastName);
        Address = new Address(street, city);
    }

    /// nodes are sibling if name or address is equal.
    public bool IsSibling(Person otherPerson)
    {
        if (otherPerson != null)
        {
            return FullName.isEquals(otherPerson.FullName) || Address.isEquals(otherPerson.Address);
        }
        return false;
    }
}

class Name
{
    public Name(string first, string last) => (FirstName, LastName) = (first, last);

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public bool isEquals(Name other)
    {
        return FirstName == other.FirstName && LastName == other.LastName;
    }
}
class Address
{
    public Address(string street, string city) => (Street, City) = (street, city);
    public string Street { get; set; }
    public string City { get; set; }

    public bool isEquals(Address other)
    {
        return Street == other.Street && City == other.City;
    }
}