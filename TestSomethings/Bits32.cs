using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TestSomethings
{
    public class Bits32<T> where T : Enum
    {
        protected uint m_value;

        public uint Value { get => m_value; set => m_value = value & Max; }

        public uint Max { get; protected set; }

        public Bits32(uint initial = 0)
        {
            Max = CalculateMax();
            m_value = initial & Max;
        }

        public Bits32(params T[] set)
        {
            Max = CalculateMax();
            m_value = CreateMask(set) & Max;

        }

        public List<T> ValueAsSet { get => GetSet(); }

        public bool this[T bit]
        {
            get => TestBit(bit);
            set => SetBit(bit, value);
        }

        protected static uint CalculateMax()
        {
            int count = Enum.GetNames(typeof(T)).Length;
            uint result = 0;
            for (int shift = 0; shift < count; shift++) result |= (uint)(1 << shift);
            return result;
        }

        protected List<T> GetSet()
        {
            List<T> result = new List<T>();
            foreach(T item in Enum.GetValues(typeof(T)))
            {
                if (this[item]) result.Add(item);
            }
            return result;
        }

        protected uint CreateMask(T[] set)
        {
            uint mask = 0;
            foreach (T item in set)
            {
                int shift = Array.IndexOf(Enum.GetValues(item.GetType()), item);
                mask |= (uint)(1 << shift);
            }
            return mask;
        }

        protected bool TestBit(T bit)
        {
            int shift = Array.IndexOf(Enum.GetValues(bit.GetType()), bit);
            return (uint)(Value & (1 << shift)) > 0;
        }

        protected void SetBit(T bit, bool value)
        {
            uint mask = CreateMask(new T[] { bit });
            if (value) Value |= mask; else Value &= ~mask;
        }
       
        public void SetBits(bool setTo, params T[] bits)
        {
            foreach (T bit in bits) SetBit(bit, setTo);
        }

        public void ResetToBits(params T[] bits)
        {
            Value = CreateMask(bits);
        }
    }

}
