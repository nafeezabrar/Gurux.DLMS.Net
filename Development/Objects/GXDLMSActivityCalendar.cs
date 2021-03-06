//
// --------------------------------------------------------------------------
//  Gurux Ltd
//
//
//
// Filename:        $HeadURL$
//
// Version:         $Revision$,
//                  $Date$
//                  $Author$
//
// Copyright (c) Gurux Ltd
//
//---------------------------------------------------------------------------
//
//  DESCRIPTION
//
// This file is a part of Gurux Device Framework.
//
// Gurux Device Framework is Open Source software; you can redistribute it
// and/or modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; version 2 of the License.
// Gurux Device Framework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// More information of Gurux products: http://www.gurux.org
//
// This code is licensed under the GNU General Public License v2.
// Full text may be retrieved at http://www.gnu.org/licenses/gpl-2.0.txt
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Gurux.DLMS.Internal;
using Gurux.DLMS.Enums;
using System.Globalization;

namespace Gurux.DLMS.Objects
{
    /// <summary>
    /// Online help:
    /// http://www.gurux.fi/Gurux.DLMS.Objects.GXDLMSActivityCalendar
    /// </summary>
    public class GXDLMSActivityCalendar : GXDLMSObject, IGXDLMSBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GXDLMSActivityCalendar()
        : this("0.0.13.0.0.255", 0)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ln">Logical Name of the object.</param>
        public GXDLMSActivityCalendar(string ln)
        : this(ln, 0)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ln">Logical Name of the object.</param>
        /// <param name="sn">Short Name of the object.</param>
        public GXDLMSActivityCalendar(string ln, ushort sn)
        : base(ObjectType.ActivityCalendar, ln, sn)
        {
        }

        [XmlIgnore()]
        public string CalendarNameActive
        {
            get;
            set;
        }

        [XmlIgnore()]
        public GXDLMSSeasonProfile[] SeasonProfileActive
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlIgnore()]
        public GXDLMSWeekProfile[] WeekProfileTableActive
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlIgnore()]
        public GXDLMSDayProfile[] DayProfileTableActive
        {
            get;
            set;
        }
        [XmlIgnore()]
        public string CalendarNamePassive
        {
            get;
            set;
        }
        [XmlIgnore()]
        public GXDLMSSeasonProfile[] SeasonProfilePassive
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlIgnore()]
        public GXDLMSWeekProfile[] WeekProfileTablePassive
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlIgnore()]
        public GXDLMSDayProfile[] DayProfileTablePassive
        {
            get;
            set;
        }

        [XmlIgnore()]
        public GXDateTime Time
        {
            get;
            set;
        }

        /// <inheritdoc cref="GXDLMSObject.GetValues"/>
        public override object[] GetValues()
        {
            return new object[] { LogicalName, CalendarNameActive, SeasonProfileActive,
                              WeekProfileTableActive, DayProfileTableActive, CalendarNamePassive,
                              SeasonProfilePassive, WeekProfileTablePassive, DayProfileTablePassive, Time
                            };
        }

        #region IGXDLMSBase Members

        int[] IGXDLMSBase.GetAttributeIndexToRead(bool all)
        {
            List<int> attributes = new List<int>();
            //LN is static and read only once.
            if (all || string.IsNullOrEmpty(LogicalName))
            {
                attributes.Add(1);
            }
            //CalendarNameActive
            if (all || CanRead(2))
            {
                attributes.Add(2);
            }
            //SeasonProfileActive
            if (all || CanRead(3))
            {
                attributes.Add(3);
            }

            //WeekProfileTableActive
            if (all || CanRead(4))
            {
                attributes.Add(4);
            }
            //DayProfileTableActive
            if (all || CanRead(5))
            {
                attributes.Add(5);
            }
            //CalendarNamePassive
            if (all || CanRead(6))
            {
                attributes.Add(6);
            }
            //SeasonProfilePassive
            if (all || CanRead(7))
            {
                attributes.Add(7);
            }
            //WeekProfileTablePassive
            if (all || CanRead(8))
            {
                attributes.Add(8);
            }
            //DayProfileTablePassive
            if (all || CanRead(9))
            {
                attributes.Add(9);
            }
            //Time.
            if (all || CanRead(10))
            {
                attributes.Add(10);
            }
            return attributes.ToArray();
        }

        /// <inheritdoc cref="IGXDLMSBase.GetNames"/>
        string[] IGXDLMSBase.GetNames()
        {
            return new string[] {Internal.GXCommon.GetLogicalNameString(), "Active Calendar Name ", "Active Season Profile", "Active Week Profile Table",
                             "Active Day Profile Table", "Passive Calendar Name", "Passive Season Profile", "Passive Week Profile Table", "Passive Day Profile Table", "Time"
                            };

        }

        int IGXDLMSBase.GetAttributeCount()
        {
            return 10;
        }

        int IGXDLMSBase.GetMethodCount()
        {
            return 1;
        }

        /// <inheritdoc cref="IGXDLMSBase.GetDataType"/>
        public override DataType GetDataType(int index)
        {
            if (index == 1)
            {
                return DataType.OctetString;
            }
            if (index == 2)
            {
                return DataType.OctetString;
            }
            if (index == 3)
            {
                return DataType.Array;
            }
            if (index == 4)
            {
                return DataType.Array;
            }
            if (index == 5)
            {
                return DataType.Array;
            }
            if (index == 6)
            {
                return DataType.OctetString;
            }
            //
            if (index == 7)
            {
                return DataType.Array;
            }
            if (index == 8)
            {
                return DataType.Array;
            }
            if (index == 9)
            {
                return DataType.Array;
            }
            if (index == 10)
            {
                return DataType.OctetString;
            }
            throw new ArgumentException("GetDataType failed. Invalid attribute index.");
        }

        static Object GetSeasonProfile(GXDLMSSettings settings, GXDLMSSeasonProfile[] target)
        {
            GXByteBuffer data = new GXByteBuffer();
            data.SetUInt8((byte)DataType.Array);
            if (target == null)
            {
                //Add count
                GXCommon.SetObjectCount(0, data);
            }
            else
            {
                int cnt = target.Length;
                //Add count
                GXCommon.SetObjectCount(cnt, data);
                foreach (GXDLMSSeasonProfile it in target)
                {
                    data.SetUInt8((byte)DataType.Structure);
                    data.SetUInt8(3);
                    GXCommon.SetData(settings, data, DataType.OctetString, it.Name);
                    GXCommon.SetData(settings, data, DataType.OctetString, it.Start);
                    GXCommon.SetData(settings, data, DataType.OctetString, it.WeekName);
                }
            }
            return data.Array();
        }

        static byte[] GetWeekProfileTable(GXDLMSSettings settings, GXDLMSWeekProfile[] target)
        {
            GXByteBuffer data = new GXByteBuffer();
            data.SetUInt8((byte)DataType.Array);
            if (target == null)
            {
                //Add count
                GXCommon.SetObjectCount(0, data);
            }
            else
            {
                int cnt = target.Length;
                //Add count
                GXCommon.SetObjectCount(cnt, data);
                foreach (GXDLMSWeekProfile it in target)
                {
                    data.SetUInt8((byte)DataType.Structure);
                    data.SetUInt8(8);
                    GXCommon.SetData(settings, data, DataType.OctetString, it.Name);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.Monday);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.Tuesday);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.Wednesday);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.Thursday);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.Friday);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.Saturday);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.Sunday);
                }
            }
            return data.Array();
        }

        static Object GetDayProfileTable(GXDLMSSettings settings, GXDLMSDayProfile[] target)
        {
            GXByteBuffer data = new GXByteBuffer();
            data.SetUInt8((byte)DataType.Array);
            if (target == null)
            {
                //Add count
                GXCommon.SetObjectCount(0, data);
            }
            else
            {
                int cnt = target.Length;
                //Add count
                GXCommon.SetObjectCount(cnt, data);
                foreach (GXDLMSDayProfile it in target)
                {
                    data.SetUInt8((byte)DataType.Structure);
                    data.SetUInt8(2);
                    GXCommon.SetData(settings, data, DataType.UInt8, it.DayId);
                    data.SetUInt8((byte)DataType.Array);
                    //Add count
                    GXCommon.SetObjectCount(it.DaySchedules.Length, data);
                    foreach (GXDLMSDayProfileAction action in it.DaySchedules)
                    {
                        data.SetUInt8((byte)DataType.Structure);
                        data.SetUInt8(3);
                        GXCommon.SetData(settings, data, DataType.OctetString, action.StartTime);
                        GXCommon.SetData(settings, data, DataType.OctetString, GXCommon.LogicalNameToBytes(action.ScriptLogicalName));
                        GXCommon.SetData(settings, data, DataType.UInt16, action.ScriptSelector);
                    }
                }
            }
            return data.Array();

        }

        object IGXDLMSBase.GetValue(GXDLMSSettings settings, ValueEventArgs e)
        {
            if (e.Index == 1)
            {
                return GXCommon.LogicalNameToBytes(LogicalName);
            }
            if (e.Index == 2)
            {
                if (CalendarNameActive == null)
                {
                    return null;
                }
                return ASCIIEncoding.ASCII.GetBytes(CalendarNameActive);
            }
            if (e.Index == 3)
            {
                e.ByteArray = true;
                return GetSeasonProfile(settings, SeasonProfileActive);
            }
            if (e.Index == 4)
            {
                e.ByteArray = true;
                return GetWeekProfileTable(settings, WeekProfileTableActive);
            }
            if (e.Index == 5)
            {
                e.ByteArray = true;
                return GetDayProfileTable(settings, DayProfileTableActive);
            }
            if (e.Index == 6)
            {
                if (CalendarNamePassive == null)
                {
                    return null;
                }
                return ASCIIEncoding.ASCII.GetBytes(CalendarNamePassive);
            }
            //
            if (e.Index == 7)
            {
                e.ByteArray = true;
                return GetSeasonProfile(settings, SeasonProfilePassive);
            }
            if (e.Index == 8)
            {
                e.ByteArray = true;
                return GetWeekProfileTable(settings, WeekProfileTablePassive);
            }
            if (e.Index == 9)
            {
                e.ByteArray = true;
                return GetDayProfileTable(settings, DayProfileTablePassive);
            }
            if (e.Index == 10)
            {
                return Time;
            }
            e.Error = ErrorCode.ReadWriteDenied;
            return null;
        }

        static GXDLMSSeasonProfile[] SetSeasonProfile(GXDLMSSettings settings, Object value)
        {
            if (value != null)
            {
                List<GXDLMSSeasonProfile> items = new List<GXDLMSSeasonProfile>();
                foreach (object[] item in (object[])value)
                {
                    GXDLMSSeasonProfile it = new GXDLMSSeasonProfile();
                    it.Name = (byte[])item[0];
                    it.Start = (GXDateTime)GXDLMSClient.ChangeType((byte[])item[1], DataType.DateTime, settings.UseUtc2NormalTime);
                    it.WeekName = (byte[])item[2];
                    items.Add(it);
                }
                return items.ToArray();
            }
            return null;
        }

        static GXDLMSWeekProfile[] SetWeekProfileTable(GXDLMSSettings settings, Object value)
        {
            if (value != null)
            {
                List<GXDLMSWeekProfile> items = new List<GXDLMSWeekProfile>();
                foreach (object[] item in (object[])value)
                {
                    GXDLMSWeekProfile it = new GXDLMSWeekProfile();
                    it.Name = (byte[])item[0];
                    it.Monday = Convert.ToInt32(item[1]);
                    it.Tuesday = Convert.ToInt32(item[2]);
                    it.Wednesday = Convert.ToInt32(item[3]);
                    it.Thursday = Convert.ToInt32(item[4]);
                    it.Friday = Convert.ToInt32(item[5]);
                    it.Saturday = Convert.ToInt32(item[6]);
                    it.Sunday = Convert.ToInt32(item[7]);
                    items.Add(it);
                }
                return items.ToArray();
            }
            return null;
        }

        static GXDLMSDayProfile[] SetDayProfileTable(GXDLMSSettings settings, Object value)
        {
            if (value != null)
            {
                List<GXDLMSDayProfile> items = new List<GXDLMSDayProfile>();
                foreach (object[] item in (object[])value)
                {
                    GXDLMSDayProfile it = new GXDLMSDayProfile();
                    it.DayId = Convert.ToInt32(item[0]);
                    List<GXDLMSDayProfileAction> actions = new List<GXDLMSDayProfileAction>();
                    foreach (object[] it2 in (object[])item[1])
                    {
                        GXDLMSDayProfileAction ac = new GXDLMSDayProfileAction();
                        if (it2[0] is GXTime)
                        {
                            ac.StartTime = (GXTime)it2[0];
                        }
                        else if (it2[0] is GXDateTime)
                        {
                            ac.StartTime = new GXTime((GXDateTime)it2[0]);
                        }
                        else
                        {
                            ac.StartTime = (GXTime)GXDLMSClient.ChangeType((byte[])it2[0], DataType.Time, settings.UseUtc2NormalTime);
                        }
                        ac.ScriptLogicalName = GXCommon.ToLogicalName(it2[1]);
                        ac.ScriptSelector = Convert.ToUInt16(it2[2]);
                        actions.Add(ac);
                    }
                    it.DaySchedules = actions.ToArray();
                    items.Add(it);
                }
                return items.ToArray();
            }
            return null;
        }

        void IGXDLMSBase.SetValue(GXDLMSSettings settings, ValueEventArgs e)
        {
            if (e.Index == 1)
            {
                LogicalName = GXCommon.ToLogicalName(e.Value);
            }
            else if (e.Index == 2)
            {
                if (e.Value is byte[])
                {
                    CalendarNameActive = ASCIIEncoding.ASCII.GetString((byte[])e.Value);
                }
                else
                {
                    CalendarNameActive = Convert.ToString(e.Value);
                }
            }
            else if (e.Index == 3)
            {
                SeasonProfileActive = SetSeasonProfile(settings, e.Value);
            }
            else if (e.Index == 4)
            {
                WeekProfileTableActive = SetWeekProfileTable(settings, e.Value);
            }
            else if (e.Index == 5)
            {
                DayProfileTableActive = SetDayProfileTable(settings, e.Value);
            }
            else if (e.Index == 6)
            {
                if (e.Value is byte[])
                {
                    CalendarNamePassive = ASCIIEncoding.ASCII.GetString((byte[])e.Value);
                }
                else
                {
                    CalendarNamePassive = Convert.ToString(e.Value);
                }
            }
            else if (e.Index == 7)
            {
                SeasonProfilePassive = SetSeasonProfile(settings, e.Value);
            }
            else if (e.Index == 8)
            {
                WeekProfileTablePassive = SetWeekProfileTable(settings, e.Value);
            }
            else if (e.Index == 9)
            {
                DayProfileTablePassive = SetDayProfileTable(settings, e.Value);
            }
            else if (e.Index == 10)
            {
                if (e.Value is byte[])
                {
                    Time = (GXDateTime)GXDLMSClient.ChangeType((byte[])e.Value, DataType.DateTime, settings.UseUtc2NormalTime);
                }
                else
                {
                    Time = new GXDateTime(Convert.ToDateTime(e.Value));
                }
            }
            else
            {
                e.Error = ErrorCode.ReadWriteDenied;
            }
        }

        byte[] IGXDLMSBase.Invoke(GXDLMSSettings settings, ValueEventArgs e)
        {
            e.Error = ErrorCode.ReadWriteDenied;
            return null;
        }

        private static GXDLMSSeasonProfile[] LoadSeasonProfile(GXXmlReader reader, string name)
        {
            List<GXDLMSSeasonProfile> list = new List<GXDLMSSeasonProfile>();
            if (reader.IsStartElement(name, true))
            {
                while (reader.IsStartElement("Item", true))
                {
                    GXDLMSSeasonProfile it = new GXDLMSSeasonProfile();
                    it.Name = GXDLMSTranslator.HexToBytes(reader.ReadElementContentAsString("Name"));
                    it.Start = new GXDateTime(reader.ReadElementContentAsString("Start"), CultureInfo.InvariantCulture);
                    it.WeekName = GXDLMSTranslator.HexToBytes(reader.ReadElementContentAsString("WeekName"));
                    list.Add(it);
                }
                reader.ReadEndElement(name);
            }
            return list.ToArray();
        }

        private static GXDLMSWeekProfile[] LoadWeekProfileTable(GXXmlReader reader, string name)
        {
            List<GXDLMSWeekProfile> list = new List<GXDLMSWeekProfile>();
            if (reader.IsStartElement(name, true))
            {
                while (reader.IsStartElement("Item", true))
                {
                    GXDLMSWeekProfile it = new GXDLMSWeekProfile();
                    it.Name = GXDLMSTranslator.HexToBytes(reader.ReadElementContentAsString("Name"));
                    it.Monday = reader.ReadElementContentAsInt("Monday");
                    it.Tuesday = reader.ReadElementContentAsInt("Tuesday");
                    it.Wednesday = reader.ReadElementContentAsInt("Wednesday");
                    it.Thursday = reader.ReadElementContentAsInt("Thursday");
                    it.Friday = reader.ReadElementContentAsInt("Friday");
                    it.Saturday = reader.ReadElementContentAsInt("Saturday");
                    it.Sunday = reader.ReadElementContentAsInt("Sunday");
                    list.Add(it);
                }
                reader.ReadEndElement(name);
            }
            return list.ToArray();
        }

        private static GXDLMSDayProfile[] LoadDayProfileTable(GXXmlReader reader, string name)
        {
            List<GXDLMSDayProfile> list = new List<GXDLMSDayProfile>();
            if (reader.IsStartElement(name, true))
            {
                while (reader.IsStartElement("Item", true))
                {
                    GXDLMSDayProfile it = new GXDLMSDayProfile();
                    it.DayId = reader.ReadElementContentAsInt("DayId");
                    list.Add(it);
                    List<GXDLMSDayProfileAction> actions = new List<GXDLMSDayProfileAction>();
                    if (reader.IsStartElement("Actions", true))
                    {
                        while (reader.IsStartElement("Action", true))
                        {
                            GXDLMSDayProfileAction d = new GXDLMSDayProfileAction();
                            actions.Add(d);
                            d.StartTime = new GXTime(reader.ReadElementContentAsString("Start"), CultureInfo.InvariantCulture);
                            d.ScriptLogicalName = reader.ReadElementContentAsString("LN");
                            d.ScriptSelector = (UInt16)reader.ReadElementContentAsInt("Selector");
                        }
                        reader.ReadEndElement("Actions");
                    }
                    it.DaySchedules = actions.ToArray();
                }
                reader.ReadEndElement(name);
            }
            return list.ToArray();
        }

        void IGXDLMSBase.Load(GXXmlReader reader)
        {
            CalendarNameActive = reader.ReadElementContentAsString("CalendarNameActive");
            SeasonProfileActive = LoadSeasonProfile(reader, "SeasonProfileActive");
            WeekProfileTableActive = LoadWeekProfileTable(reader, "WeekProfileTableActive");
            DayProfileTableActive = LoadDayProfileTable(reader, "DayProfileTableActive");
            CalendarNamePassive = reader.ReadElementContentAsString("CalendarNamePassive");
            SeasonProfilePassive = LoadSeasonProfile(reader, "SeasonProfilePassive");
            WeekProfileTablePassive = LoadWeekProfileTable(reader, "WeekProfileTablePassive");
            DayProfileTablePassive = LoadDayProfileTable(reader, "DayProfileTablePassive");
            string str = reader.ReadElementContentAsString("Time");
            if (!string.IsNullOrEmpty(str))
            {
                Time = new GXDateTime(str, CultureInfo.InvariantCulture);
            }
        }

        private void SaveSeasonProfile(GXXmlWriter writer, GXDLMSSeasonProfile[] list, string name)
        {
            if (list != null)
            {
                writer.WriteStartElement(name);
                foreach (GXDLMSSeasonProfile it in list)
                {
                    writer.WriteStartElement("Item");
                    writer.WriteElementString("Name", GXDLMSTranslator.ToHex(it.Name));
                    writer.WriteElementString("Start", it.Start.ToFormatString(CultureInfo.InvariantCulture));
                    writer.WriteElementString("WeekName", GXDLMSTranslator.ToHex(it.WeekName));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private void SaveWeekProfileTable(GXXmlWriter writer, GXDLMSWeekProfile[] list, string name)
        {
            if (list != null)
            {
                writer.WriteStartElement(name);
                foreach (GXDLMSWeekProfile it in list)
                {
                    writer.WriteStartElement("Item");
                    writer.WriteElementString("Name", GXDLMSTranslator.ToHex(it.Name));
                    writer.WriteElementString("Monday", it.Monday);
                    writer.WriteElementString("Tuesday", it.Tuesday);
                    writer.WriteElementString("Wednesday", it.Wednesday);
                    writer.WriteElementString("Thursday", it.Thursday);
                    writer.WriteElementString("Friday", it.Friday);
                    writer.WriteElementString("Saturday", it.Saturday);
                    writer.WriteElementString("Sunday", it.Sunday);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private void SaveDayProfileTable(GXXmlWriter writer, GXDLMSDayProfile[] list, string name)
        {
            if (list != null)
            {
                writer.WriteStartElement(name);
                foreach (GXDLMSDayProfile it in list)
                {
                    writer.WriteStartElement("Item");
                    writer.WriteElementString("DayId", it.DayId.ToString());
                    writer.WriteStartElement("Actions");
                    foreach (GXDLMSDayProfileAction d in it.DaySchedules)
                    {
                        writer.WriteStartElement("Action");
                        writer.WriteElementString("Start", d.StartTime.ToFormatString(CultureInfo.InvariantCulture));
                        writer.WriteElementString("LN", d.ScriptLogicalName);
                        writer.WriteElementString("Selector", d.ScriptSelector);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        void IGXDLMSBase.Save(GXXmlWriter writer)
        {
            writer.WriteElementString("CalendarNameActive", CalendarNameActive);
            SaveSeasonProfile(writer, SeasonProfileActive, "SeasonProfileActive");
            SaveWeekProfileTable(writer, WeekProfileTableActive, "WeekProfileTableActive");
            SaveDayProfileTable(writer, DayProfileTableActive, "DayProfileTableActive");
            writer.WriteElementString("CalendarNamePassive", CalendarNamePassive);
            SaveSeasonProfile(writer, SeasonProfilePassive, "SeasonProfilePassive");
            SaveWeekProfileTable(writer, WeekProfileTablePassive, "WeekProfileTablePassive");
            SaveDayProfileTable(writer, DayProfileTablePassive, "DayProfileTablePassive");
            if (Time != null)
            {
                writer.WriteElementString("Time", Time.ToFormatString(System.Globalization.CultureInfo.InvariantCulture));
            }
        }

        void IGXDLMSBase.PostLoad(GXXmlReader reader)
        {
        }
        #endregion
    }
}