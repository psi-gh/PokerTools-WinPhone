namespace PokerTools
{
    using System.Collections.Generic;
    using System.Linq;

    public class GroupingLayer<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly IGrouping<TKey, TElement> grouping;

        public GroupingLayer(IGrouping<TKey, TElement> unit)
        {
            this.grouping = unit;
        }

        public TKey Key
        {
            get
            {
                return this.grouping.Key;
            }
        }

        public override bool Equals(object obj)
        {
            var that = obj as GroupingLayer<TKey, ItemViewModel>;
            return (that != null) && this.Key.Equals(that.Key);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return this.grouping.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.grouping.GetEnumerator();
        }
    }
}
