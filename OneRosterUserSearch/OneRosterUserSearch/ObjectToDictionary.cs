using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OneRosterUserSearch
{
    public static class ObjectToDictionary
    {
        public static IDictionary<string, object> toDictionary(this object source)
        {
            return source.toDictionary<object>();
        }

        public static IDictionary<string, T> toDictionary<T>(this object source)
        {
            if (source == null)
                throwExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
                addPropertyToDictionary<T>(property, source, dictionary);

            return dictionary;
        }

        private static void addPropertyToDictionary<T>(PropertyDescriptor property, object source, IDictionary<string, T> dictionary)
        {
            object value = property.GetValue(source);
            if (!isOfType<T>(value)) return;
            if (!(property.Name == "demographicsObject" || property.Name == "metadataObject" || property.Name == "orgsObject"))
            {
                dictionary.Add(property.Name, (T)value);
            }
        }

        private static bool isOfType<T>(object value)
        {
            return value is T;
        }

        private static void throwExceptionWhenSourceArgumentIsNull()
        {
            throw new ArgumentNullException($"source", @"Unable to convert object to a dictionary. The source object is null.");
        }
    }
}