using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal class Party<T> : IMeasurable where T : new() {
        private static int _maxPartySize = 4;
        private static int _minPartySize = 1;
        private int _partySize;
        private Random _random = new();
        private T[] _members;

        public int Size() {
            return _partySize;
        }
        internal static void SetPartySizeLimits(int min, int max) {
            _maxPartySize = max;
            _minPartySize = min;
        }
        internal Party() {
            _partySize = _random.Next(_minPartySize, _maxPartySize+1);
            _members = new T[_partySize];
            for(int i = 0; i < _partySize; i++) {
                _members[i] = new T();
            }
        }
    }
}
