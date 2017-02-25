using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc {

    internal class Hierarchy<T> {

        readonly Dictionary<string, Entry> _entries;

        public Hierarchy() {
            _entries = new Dictionary<string, Entry>();
        }

        public IReadOnlyDictionary<string, Entry> Entries => _entries;

        public void Add(string name, T value, string parentName, IEnumerable<string> nestedEntriesNames) {
            var prop = GetProp(name);
            prop.Value = value;

            if(!String.IsNullOrEmpty(parentName)) {
                var parentProp = GetProp(parentName);
                parentProp.NestedEntries.Add(prop);
            }

            if(nestedEntriesNames != null && nestedEntriesNames.Any()) {
                foreach(var nestedEntryName in nestedEntriesNames)
                    prop.NestedEntries.Add(GetProp(nestedEntryName));
            }
        }

        Entry GetProp(string name) {
            if(!_entries.ContainsKey(name))
                _entries[name] = new Entry(name);

            return _entries[name];
        }

        public class Entry {
            public readonly string Name;
            public T Value;
            public ICollection<Entry> NestedEntries;

            public Entry(string name) {
                Name = name;
                NestedEntries = new List<Entry>();
            }
        }
    }

}
