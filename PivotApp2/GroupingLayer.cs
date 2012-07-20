﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Collections.Generic;

namespace PokerTools
{
    public class GroupingLayer<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly IGrouping<TKey, TElement> grouping;

        public GroupingLayer(IGrouping<TKey, TElement> unit)
        {
            grouping = unit;
        }

        public TKey Key
        {
            get
            {
                return grouping.Key;
            }
        }

        public override bool Equals(object obj)
        {
            GroupingLayer<TKey, ItemViewModel> that = obj as GroupingLayer<TKey, ItemViewModel>;
            return (that != null) && (this.Key.Equals(that.Key));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return grouping.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return grouping.GetEnumerator();
        }
    }
}
