class Node
{
    public Person Value { get; set; }
    public List<Node> SiblingNodes { get; set; }
    public int Distance { get; set; }
    public Node(Person value) => (Value, SiblingNodes, Distance) = (value, new List<Node>(), int.MaxValue);

    public bool IsSibling(Node otherNode)
    {
        if (otherNode != null)
        {
            return Value.IsSibling(otherNode.Value);
        }
        return false;
    }
}