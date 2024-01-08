
public interface NestedInteger
{

    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList();
}

public class NestedIterator
{
    IEnumerator<int> List;

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        List = Flatten(nestedList).GetEnumerator();
    }

    public bool HasNext()
    {
        return List.MoveNext();
    }

    public int Next()
    {
        return List.Current;
    }

    public IEnumerable<int> Flatten(IList<NestedInteger> nestedList)
    {
        if (nestedList.Count == 0 || nestedList == null) yield break;

        foreach (var item in nestedList)
        {
            if (item.IsInteger())
            {
                yield return item.GetInteger();
            }
            else
            {
                foreach (var i in Flatten(item.GetList()))
                {
                    yield return i;
                }
            }
        }
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */