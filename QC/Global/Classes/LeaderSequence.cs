using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    class LeaderSequence
    {
        private static readonly Keys[] KonamiCode = { Keys.B, Keys.O, Keys.S, Keys.S};

        private readonly Queue<Keys> _inputKeys = new Queue<Keys>();

        public bool IsCompletedBy(Keys inputKey)
        {
            _inputKeys.Enqueue(inputKey);

            while (_inputKeys.Count > KonamiCode.Length)
                _inputKeys.Dequeue();

            return _inputKeys.SequenceEqual(KonamiCode);
        }
    }
}
