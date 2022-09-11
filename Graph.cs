class Graph
{
    public List<Node> NodeList { get; set; }

    public Graph()
    {
        NodeList = new List<Node>();
    }

    public void Init(Person[] PersonArray)
    {
        //convert personArray to List
        foreach (Person person in PersonArray)
        {
            NodeList.Add(new Node(person));
        }

        //foreach node set siblings 
        foreach (Node currentNode in NodeList)
        {
            foreach (Node tempNode in NodeList)
            {
                if (tempNode != currentNode && tempNode.IsSibling(currentNode))
                {
                    currentNode.SiblingNodes.Add(tempNode);
                }
            }
        }
    }

    //calculate the minimum distance between 2 nodes
    //Returns the minimal level of relation between nodes. If they are not related, return -1.
    public int FindMinRelationLevel(int srcNodeIndex, int dstNodeIndex)
    {
        //TODO: validate index inputs are in range
        ResetGraphDistances(srcNodeIndex);
        SetNodeDistance(NodeList[srcNodeIndex], NodeList[dstNodeIndex]);
        int distance = NodeList[dstNodeIndex].Distance;
        return distance != int.MaxValue ? distance : -1;
    }


    //set all nodes distance to infinity excluding surce node
    private void ResetGraphDistances(int srcNodeIndex)
    {
        NodeList.ForEach(node => node.Distance = int.MaxValue);
        NodeList[srcNodeIndex].Distance = 0;
    }

    //loop each node and set the minimum distance from the source node
    private void SetNodeDistance(Node srcNode, Node dstNode)
    {
        foreach (Node tmpNode in srcNode.SiblingNodes)
        {
            if (srcNode.Distance + 1 < tmpNode.Distance)
            {
                tmpNode.Distance = srcNode.Distance + 1;
                if (tmpNode == dstNode)
                {
                    return;
                }
                SetNodeDistance(tmpNode, dstNode);
            }
        }
    }
}