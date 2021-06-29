using System;
using System.ComponentModel;
using System.Linq;

namespace EIPTemplate
{
    public class EtherNetIPConfig : BindableBase, ICloneable
    {
        private string _ipAddress = "127.0.0.1";
        private ushort _udpPort = 0x8AE;
        private BindingList<RemoteDevice> _remoteDevices;

        [DisplayName("IP地址")]
        public string IPAddress
        {
            get => _ipAddress;
            set => SetProperty(ref _ipAddress, value);
        }

        [DisplayName("UDP端口")]
        public ushort UdpPort
        {
            get => _udpPort;
            set => SetProperty(ref _udpPort, value);
        }

        [DisplayName("远程设备")]
        public BindingList<RemoteDevice> RemoteDevices
        {
            get => _remoteDevices ?? (_remoteDevices = new BindingList<RemoteDevice>());
            set => SetProperty(ref _remoteDevices, value);
        }

        public object Clone()
        {
            var clone = MemberwiseClone() as EtherNetIPConfig;
            clone.RemoteDevices = new BindingList<RemoteDevice>(RemoteDevices.Select(i => (RemoteDevice)i.Clone()).ToList());
            return clone;
        }
    }

    public class RemoteDevice : BindableBase, ICloneable
    {
        private string _ipAddress = "192.168.0.1";
        private ushort _tcpPort = 0xAF12;
        private ushort _udpPort = 0x8AE;
        private uint _cycleTime = 10;
        private uint _timeoutTick = 50;
        private string _name = "";
        private string _description = "";
        private string _watchdog = "";
        private DeviceType _type = 0;
        private string _typeVar = "";
        private EIPConfig _eipConfig;
        private EIPConfig _eipO2T;
        private EIPConfig _eipT2O;
        private ushort _configBytes = 0;
        private ushort _o2TBytes = 0;
        private ushort _t2OBytes = 0;

        private BindingList<Signal> _signals;

        [DisplayName("IP地址")]
        public string IPAddress
        {
            get => _ipAddress;
            set => SetProperty(ref _ipAddress, value);
        }

        [DisplayName("TCP端口")]
        public ushort TcpPort
        {
            get => _tcpPort;
            set => SetProperty(ref _tcpPort, value);
        }

        [DisplayName("UDP端口")]
        public ushort UdpPort
        {
            get => _udpPort;
            set => SetProperty(ref _udpPort, value);
        }

        [DisplayName("循环周期(ms)")]
        public uint CycleTime
        {
            get => _cycleTime;
            set => SetProperty(ref _cycleTime, value);
        }

        [DisplayName("超时数")]
        public uint TimeoutTicks
        {
            get => _timeoutTick;
            set => SetProperty(ref _timeoutTick, value);
        }

        [DisplayName("设备名称")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [DisplayName("设备描述")]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        [DisplayName("看门狗")]
        public string Watchdog
        {
            get => _watchdog;
            set => SetProperty(ref _watchdog, value);
        }

        [DisplayName("设备类型")]
        public DeviceType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        [DisplayName("设备类型变量")]
        public string TypeVar
        {
            get => _typeVar;
            set => SetProperty(ref _typeVar, value);
        }

        public EIPConfig EIPConfig
        {
            get => _eipConfig ?? (_eipConfig = new EIPConfig());
            set => SetProperty(ref _eipConfig, value);
        }

        public EIPConfig EIPO2T
        {
            get => _eipO2T ?? (_eipO2T = new EIPConfig());
            set => SetProperty(ref _eipO2T, value);
        }

        public EIPConfig EIPT2O
        {
            get => _eipT2O ?? (_eipT2O = new EIPConfig());
            set => SetProperty(ref _eipT2O, value);
        }

        public ushort ConfigBytes
        {
            get => _configBytes;
            set => SetProperty(ref _configBytes, value);
        }

        public ushort O2TBytes
        {
            get => _o2TBytes;
            set => SetProperty(ref _o2TBytes, value);
        }

        public ushort T2OBytes
        {
            get => _t2OBytes;
            set => SetProperty(ref _t2OBytes, value);
        }

        public BindingList<Signal> Signals
        {
            get => _signals ?? (_signals = new BindingList<Signal>());
            set => SetProperty(ref _signals, value);
        }

        public object Clone()
        {
            var clone = MemberwiseClone() as RemoteDevice;
            clone.EIPConfig = EIPConfig.Clone() as EIPConfig;
            clone.EIPO2T = EIPO2T.Clone() as EIPConfig;
            clone.EIPT2O = EIPT2O.Clone() as EIPConfig;
            clone.Signals = new BindingList<Signal>(Signals.Select(i => (Signal)i.Clone()).ToList());
            return clone;
        }
    }

    public class Signal : BindableBase, ICloneable
    {
        private SignalTypeEnum _signalTypeEnum = SignalTypeEnum.Config;
        private string _name = "";
        private string _varName = "";
        private string _description = "";
        private ByteOrderEnum _byteOrder = ByteOrderEnum.BigEndian;
        private DataTypeEnum _dataType = DataTypeEnum.BOOL;
        private int _startBit = 0;
        private int _numberOfBits = 0;
        private double _gain = 1;
        private double _offset = 0;
        private double _maxValue = 0;
        private double _minValue = 0;
        private double _defaultValue = 0;

        [DisplayName("信号类型")]
        [DefaultValue(SignalTypeEnum.Input)]
        public SignalTypeEnum SignalType
        {
            get => _signalTypeEnum;
            set => SetProperty(ref _signalTypeEnum, value);
        }

        [DisplayName("名称")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [DisplayName("变量")]
        public string VarName
        {
            get => _varName;
            set => SetProperty(ref _varName, value);
        }

        [DisplayName("字节顺序")]
        public ByteOrderEnum ByteOrder
        {
            get => _byteOrder;
            set => SetProperty(ref _byteOrder, value);
        }

        [DisplayName("数据类型")]
        public DataTypeEnum DataType
        {
            get => _dataType;
            set => SetProperty(ref _dataType, value);
        }

        [DisplayName("起始位")]
        public int StartBit
        {
            get => _startBit;
            set => SetProperty(ref _startBit, value);
        }

        [DisplayName("位数量")]
        public int NumberOfBits
        {
            get => _numberOfBits;
            set => SetProperty(ref _numberOfBits, value);
        }

        [DisplayName("增益")]
        public double Gain
        {
            get => _gain;
            set => SetProperty(ref _gain, value);
        }

        [DisplayName("偏移")]
        public double Offset
        {
            get => _offset;
            set => SetProperty(ref _offset, value);
        }

        [DisplayName("最大值")]
        [Browsable(false)]
        public double MaxValue
        {
            get => _maxValue;
            set => SetProperty(ref _maxValue, value);
        }

        [DisplayName("最小值")]
        [Browsable(false)]
        public double MinValue
        {
            get => _minValue;
            set => SetProperty(ref _minValue, value);
        }

        [DisplayName("默认值")]
        [Browsable(false)]
        public double DefaultValue
        {
            get => _defaultValue;
            set => SetProperty(ref _defaultValue, value);
        }

        [DisplayName("描述")]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class EIPConfig : BindableBase, ICloneable
    {
        private ushort _classId = 4;
        private ushort _instanceId = 0;
        private ushort _attributeId = 3;

        public ushort ClassID
        {
            get => _classId;
            set => SetProperty(ref _classId, value);
        }

        public ushort InstanceID
        {
            get => _instanceId;
            set => SetProperty(ref _instanceId, value);
        }

        public ushort AttributeID
        {
            get => _attributeId;
            set => SetProperty(ref _attributeId, value);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public enum ByteOrderEnum
    {
        BigEndian, LittleEndian
    }

    public enum DataTypeEnum
    {
        Default, BOOL, U8, I8, U16, I16, U32, I32, U64, I64, Float, Double
    }

    public enum SignalTypeEnum
    {
        Config, Input, Output
    }

    public enum DeviceType : int
    {
        Default,
        Open,
        Close,
        UseVar
    }
}
