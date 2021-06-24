// This file was generated by a tool; you should avoid making direct changes.
// Consider using 'partial classes' to extend these types
// Input: client.proto

#pragma warning disable CS1591, CS0612, CS3021

[global::ProtoBuf.ProtoContract()]
public partial class LoginBySessionC2S
{
    [global::ProtoBuf.ProtoMember(1)]
    public long id
    {
        get { return __pbn__id.GetValueOrDefault(); }
        set { __pbn__id = value; }
    }
    public bool ShouldSerializeid() => __pbn__id != null;
    public void Resetid() => __pbn__id = null;
    private long? __pbn__id;

    [global::ProtoBuf.ProtoMember(2)]
    [global::System.ComponentModel.DefaultValue("")]
    public string platform
    {
        get { return __pbn__platform ?? ""; }
        set { __pbn__platform = value; }
    }
    public bool ShouldSerializeplatform() => __pbn__platform != null;
    public void Resetplatform() => __pbn__platform = null;
    private string __pbn__platform;

    [global::ProtoBuf.ProtoMember(3)]
    [global::System.ComponentModel.DefaultValue("")]
    public string session
    {
        get { return __pbn__session ?? ""; }
        set { __pbn__session = value; }
    }
    public bool ShouldSerializesession() => __pbn__session != null;
    public void Resetsession() => __pbn__session = null;
    private string __pbn__session;

    [global::ProtoBuf.ProtoMember(4)]
    public bool reconnect
    {
        get { return __pbn__reconnect.GetValueOrDefault(); }
        set { __pbn__reconnect = value; }
    }
    public bool ShouldSerializereconnect() => __pbn__reconnect != null;
    public void Resetreconnect() => __pbn__reconnect = null;
    private bool? __pbn__reconnect;

    [global::ProtoBuf.ProtoMember(7)]
    [global::System.ComponentModel.DefaultValue("")]
    public string deviceModel
    {
        get { return __pbn__deviceModel ?? ""; }
        set { __pbn__deviceModel = value; }
    }
    public bool ShouldSerializedeviceModel() => __pbn__deviceModel != null;
    public void ResetdeviceModel() => __pbn__deviceModel = null;
    private string __pbn__deviceModel;

    [global::ProtoBuf.ProtoMember(8)]
    [global::System.ComponentModel.DefaultValue("")]
    public string operatingSystem
    {
        get { return __pbn__operatingSystem ?? ""; }
        set { __pbn__operatingSystem = value; }
    }
    public bool ShouldSerializeoperatingSystem() => __pbn__operatingSystem != null;
    public void ResetoperatingSystem() => __pbn__operatingSystem = null;
    private string __pbn__operatingSystem;

    [global::ProtoBuf.ProtoMember(9)]
    public int processorCount
    {
        get { return __pbn__processorCount.GetValueOrDefault(); }
        set { __pbn__processorCount = value; }
    }
    public bool ShouldSerializeprocessorCount() => __pbn__processorCount != null;
    public void ResetprocessorCount() => __pbn__processorCount = null;
    private int? __pbn__processorCount;

    [global::ProtoBuf.ProtoMember(10)]
    [global::System.ComponentModel.DefaultValue("")]
    public string deviceUniqueIdentifier
    {
        get { return __pbn__deviceUniqueIdentifier ?? ""; }
        set { __pbn__deviceUniqueIdentifier = value; }
    }
    public bool ShouldSerializedeviceUniqueIdentifier() => __pbn__deviceUniqueIdentifier != null;
    public void ResetdeviceUniqueIdentifier() => __pbn__deviceUniqueIdentifier = null;
    private string __pbn__deviceUniqueIdentifier;

    [global::ProtoBuf.ProtoMember(11)]
    public int systemMemorySize
    {
        get { return __pbn__systemMemorySize.GetValueOrDefault(); }
        set { __pbn__systemMemorySize = value; }
    }
    public bool ShouldSerializesystemMemorySize() => __pbn__systemMemorySize != null;
    public void ResetsystemMemorySize() => __pbn__systemMemorySize = null;
    private int? __pbn__systemMemorySize;

    [global::ProtoBuf.ProtoMember(12)]
    public bool simulator
    {
        get { return __pbn__simulator.GetValueOrDefault(); }
        set { __pbn__simulator = value; }
    }
    public bool ShouldSerializesimulator() => __pbn__simulator != null;
    public void Resetsimulator() => __pbn__simulator = null;
    private bool? __pbn__simulator;

    [global::ProtoBuf.ProtoMember(13)]
    public bool root
    {
        get { return __pbn__root.GetValueOrDefault(); }
        set { __pbn__root = value; }
    }
    public bool ShouldSerializeroot() => __pbn__root != null;
    public void Resetroot() => __pbn__root = null;
    private bool? __pbn__root;

    [global::ProtoBuf.ProtoMember(14)]
    [global::System.ComponentModel.DefaultValue("")]
    public string version
    {
        get { return __pbn__version ?? ""; }
        set { __pbn__version = value; }
    }
    public bool ShouldSerializeversion() => __pbn__version != null;
    public void Resetversion() => __pbn__version = null;
    private string __pbn__version;

}

[global::ProtoBuf.ProtoContract()]
public partial class LoginBySessionS2C
{
    [global::ProtoBuf.ProtoMember(1)]
    public int code
    {
        get { return __pbn__code.GetValueOrDefault(); }
        set { __pbn__code = value; }
    }
    public bool ShouldSerializecode() => __pbn__code != null;
    public void Resetcode() => __pbn__code = null;
    private int? __pbn__code;

    [global::ProtoBuf.ProtoMember(2)]
    public Gamer main { get; set; }

    [global::ProtoBuf.ProtoMember(4)]
    public int start
    {
        get { return __pbn__start.GetValueOrDefault(); }
        set { __pbn__start = value; }
    }
    public bool ShouldSerializestart() => __pbn__start != null;
    public void Resetstart() => __pbn__start = null;
    private int? __pbn__start;

    [global::ProtoBuf.ProtoMember(5)]
    public int end
    {
        get { return __pbn__end.GetValueOrDefault(); }
        set { __pbn__end = value; }
    }
    public bool ShouldSerializeend() => __pbn__end != null;
    public void Resetend() => __pbn__end = null;
    private int? __pbn__end;

    [global::ProtoBuf.ProtoMember(6)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reason
    {
        get { return __pbn__reason ?? ""; }
        set { __pbn__reason = value; }
    }
    public bool ShouldSerializereason() => __pbn__reason != null;
    public void Resetreason() => __pbn__reason = null;
    private string __pbn__reason;

}

[global::ProtoBuf.ProtoContract()]
public partial class NotifyKickS2C
{
    [global::ProtoBuf.ProtoMember(1)]
    public int reason
    {
        get { return __pbn__reason.GetValueOrDefault(); }
        set { __pbn__reason = value; }
    }
    public bool ShouldSerializereason() => __pbn__reason != null;
    public void Resetreason() => __pbn__reason = null;
    private int? __pbn__reason;

}

public class ILRuntime_client
{
    static ILRuntime_client()
    {

        //Initlize();

    }
    public static void Initlize()
    {

        ProtoBuf.PType.RegisterType("LoginBySessionC2S", typeof(LoginBySessionC2S));
        ProtoBuf.PType.RegisterType("LoginBySessionS2C", typeof(LoginBySessionS2C));
        ProtoBuf.PType.RegisterType("NotifyKickS2C", typeof(NotifyKickS2C));

    }
}

#pragma warning restore CS1591, CS0612, CS3021
