﻿using System.Collections.ObjectModel;

namespace TOPSIS;

internal static class ObservableCollectionExtensions
{
    public static void AddRange<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            observableCollection.Add(item);
        }
    }
}