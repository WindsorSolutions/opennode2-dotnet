namespace Windsor.Node2008.WNOSPlugin.WQXProcessingReport
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum LogType
    {

        /// <remarks/>
        Warning,

        /// <remarks/>
        Error,

        /// <remarks/>
        Message,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum Status
    {

        /// <remarks/>
        Failed,

        /// <remarks/>
        Completed,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Result
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActionType Action;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public int Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ActionType
    {

        /// <remarks/>
        Delete,

        /// <remarks/>
        Insert,

        /// <remarks/>
        Update,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Project
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActionType Action;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public int Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ProcessingSoftware
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Counts
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public int Error;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public int Warning;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Project", Order = 2)]
        public Project[] Project;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoringLocation", Order = 3)]
        public MonitoringLocation[] MonitoringLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiologicalHabitatIndex", Order = 4)]
        public BiologicalHabitatIndex[] BiologicalHabitatIndex;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Activity", Order = 5)]
        public Activity[] Activity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityGroup", Order = 6)]
        public ActivityGroup[] ActivityGroup;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Result", Order = 7)]
        public Result[] Result;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class MonitoringLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActionType Action;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public int Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Activity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActionType Action;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public int Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ActivityGroup
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActionType Action;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public int Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class BiologicalHabitatIndex
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActionType Action;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public int Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class LogDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public LogType Type;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string Context;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ProcessingFailures
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectIdentifier", Order = 0)]
        public string[] ProjectIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoringLocationIdentifier", Order = 1)]
        public string[] MonitoringLocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndexIdentifier", Order = 2)]
        public string[] IndexIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityIdentifier", Order = 3)]
        public string[] ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityGroupIdentifier", Order = 4)]
        public string[] ActivityGroupIdentifier;

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Log
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LogDetail", Order = 0)]
        public LogDetail[] LogDetail;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ProcessingReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string TransactionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public Status Status;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProcessingSoftware", Order = 2)]
        public ProcessingSoftware[] ProcessingSoftware;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public Counts Counts;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("LogDetail", IsNullable = false)]
        public LogDetail[] Log;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public ProcessingFailures ProcessingFailures;
    }
}
