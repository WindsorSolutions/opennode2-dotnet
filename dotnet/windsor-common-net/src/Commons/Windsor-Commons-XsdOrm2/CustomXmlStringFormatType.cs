using System.Xml.Serialization;
using System.Data;
using System;
using Windsor.Commons.XsdOrm2;
using Windsor.Commons.Core;

namespace Windsor.Commons.XsdOrm2
{
    [Serializable]
    public abstract class CustomXmlStringFormatTypeBase
    {
        public abstract TypeCode GetTypeCode();
        public abstract void SetValue(object value);
    }

    [Serializable]
    public abstract class CustomXmlStringFormatType<T> : CustomXmlStringFormatTypeBase, IXmlSerializable, IEquatable<T>, IComparable<T>, IConvertible 
        where T : struct, IEquatable<T>, IComparable<T>, IConvertible
    {
        public T Value;

        public CustomXmlStringFormatType()
        {
        }
        public CustomXmlStringFormatType(T value)
        {
            Value = value;
        }
        public abstract string GetXmlString();

        public override string ToString()
        {
            return GetXmlString();
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            string s = reader.ReadElementString();
            Value = (T) Convert.ChangeType(s, typeof(T));
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(GetXmlString());
        }
        public bool Equals(T other)
        {
            return Value.Equals(other);
        }
        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
        public override TypeCode GetTypeCode()
        {
            return ((IConvertible)Value).GetTypeCode();
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToBoolean(provider);
        }
        public byte ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToByte(provider);
        }
        public char ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToChar(provider);
        }
        public DateTime ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDateTime(provider);
        }
        public decimal ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDecimal(provider);
        }
        public double ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDouble(provider);
        }
        public short ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt16(provider);
        }
        public int ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt32(provider);
        }
        public long ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt64(provider);
        }
        public sbyte ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSByte(provider);
        }
        public float ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSingle(provider);
        }
        public string ToString(IFormatProvider provider)
        {
            return this.ToString();
        }
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)Value).ToType(conversionType, provider);
        }
        public ushort ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt16(provider);
        }
        public uint ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt32(provider);
        }
        public ulong ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt64(provider);
        }
        public override void SetValue(object value)
        {
            try
            {
                Value = (T)value;
            }
            catch (Exception)
            {
                DebugUtils.CheckDebuggerBreak();
                throw;
            }
        }
    }
    [Serializable]
    public class CustomXmlStringFormatInt32 : CustomXmlStringFormatType<int>
    {
        public CustomXmlStringFormatInt32()
        {
        }
        public CustomXmlStringFormatInt32(int value)
            : base(value)
        {
        }
        public override string GetXmlString()
        {
            return Value.ToString();
        }
    }
    [Serializable]
    public class SingleLeadingZeroInt32 : CustomXmlStringFormatInt32
    {
        public SingleLeadingZeroInt32()
        {
        }
        public SingleLeadingZeroInt32(int value)
            : base(value)
        {
        }
        public override string GetXmlString()
        {
            return Value.ToString("D2");
        }
    }
    [Serializable]
    public class CustomXmlStringFormatDateTime : CustomXmlStringFormatType<DateTime>
    {
        public CustomXmlStringFormatDateTime()
        {
        }
        public CustomXmlStringFormatDateTime(DateTime value)
            : base(value)
        {
        }
        public override string GetXmlString()
        {
            return Value.ToString();
        }
    }
    [Serializable]
    public class CustomXmlStringFormatDate : CustomXmlStringFormatDateTime
    {
        public CustomXmlStringFormatDate()
        {
        }
        public CustomXmlStringFormatDate(DateTime value)
            : base(value)
        {
        }
        public override string GetXmlString()
        {
            return Value.ToString("yyyy-MM-dd");
        }
    }
}
