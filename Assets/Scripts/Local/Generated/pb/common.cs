// This file was generated by a tool; you should avoid making direct changes.
// Consider using 'partial classes' to extend these types
// Input: common.proto

#pragma warning disable CS1591, CS0612, CS3021

[global::ProtoBuf.ProtoContract()]
public partial class Gamer
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

}

public class ILRuntime_common
{
    static ILRuntime_common()
    {

        //Initlize();

    }
    public static void Initlize()
    {

        ProtoBuf.PType.RegisterType("Gamer", typeof(Gamer));

    }
}

#pragma warning restore CS1591, CS0612, CS3021
