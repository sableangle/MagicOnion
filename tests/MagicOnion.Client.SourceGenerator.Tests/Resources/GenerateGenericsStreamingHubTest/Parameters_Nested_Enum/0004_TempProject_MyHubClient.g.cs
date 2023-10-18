﻿// <auto-generated />
#pragma warning disable CS0618 // 'member' is obsolete: 'text'
#pragma warning disable CS0612 // 'member' is obsolete
#pragma warning disable CS0414 // The private field 'field' is assigned but its value is never used
#pragma warning disable CS8019 // Unnecessary using directive.
#pragma warning disable CS1522 // Empty switch block

namespace TempProject
{
    using global::System;
    using global::Grpc.Core;
    using global::MagicOnion;
    using global::MagicOnion.Client;
    using global::MessagePack;

    partial class MagicOnionInitializer
    {
        static partial class MagicOnionGeneratedClient
        {
            [global::MagicOnion.Ignore]
            public class TempProject_MyHubClient : global::MagicOnion.Client.StreamingHubClientBase<global::TempProject.IMyHub, global::TempProject.IMyHubReceiver>, global::TempProject.IMyHub
            {
                protected override global::Grpc.Core.Method<global::System.Byte[], global::System.Byte[]> DuplexStreamingAsyncMethod { get; }

                public TempProject_MyHubClient(global::Grpc.Core.CallInvoker callInvoker, global::System.String host, global::Grpc.Core.CallOptions options, global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider, global::MagicOnion.Client.IMagicOnionClientLogger logger)
                    : base(callInvoker, host, options, serializerProvider, logger)
                {
                    var marshaller = global::MagicOnion.MagicOnionMarshallers.ThroughMarshaller;
                    DuplexStreamingAsyncMethod = new global::Grpc.Core.Method<global::System.Byte[], global::System.Byte[]>(global::Grpc.Core.MethodType.DuplexStreaming, "IMyHub", "Connect", marshaller, marshaller);
                }

                public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetEnumAsync(global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyEnum>> arg0)
                    => base.WriteMessageWithResponseAsync<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyEnum>>, global::MessagePack.Nil>(-1221306238, arg0);

                public global::TempProject.IMyHub FireAndForget()
                    => new FireAndForgetClient(this);
                    
                [global::MagicOnion.Ignore]
                class FireAndForgetClient : global::TempProject.IMyHub
                {
                    readonly TempProject_MyHubClient parent;

                    public FireAndForgetClient(TempProject_MyHubClient parent)
                        => this.parent = parent;

                    public global::TempProject.IMyHub FireAndForget() => this;
                    public global::System.Threading.Tasks.Task DisposeAsync() => throw new global::System.NotSupportedException();
                    public global::System.Threading.Tasks.Task WaitForDisconnect() => throw new global::System.NotSupportedException();

                    public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetEnumAsync(global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyEnum>> arg0)
                        => parent.WriteMessageFireAndForgetAsync<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyEnum>>, global::MessagePack.Nil>(-1221306238, arg0);

                }

                protected override void OnBroadcastEvent(global::System.Int32 methodId, global::System.ArraySegment<global::System.Byte> data)
                {
                    switch (methodId)
                    {
                    }
                }

                protected override void OnResponseEvent(global::System.Int32 methodId, global::System.Object taskCompletionSource, global::System.ArraySegment<global::System.Byte> data)
                {
                    switch (methodId)
                    {
                        case -1221306238: // Task<Nil> GetEnumAsync(global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyEnum>> arg0)
                            base.SetResultForResponse<global::MessagePack.Nil>(taskCompletionSource, data);
                            break;
                    }
                }

            }
        }
    }
}
