﻿// <auto-generated />
#pragma warning disable CS0618 // 'member' is obsolete: 'text'
#pragma warning disable CS0612 // 'member' is obsolete
#pragma warning disable CS8019 // Unnecessary using directive.

namespace TempProject
{
    using global::System;
    using global::MessagePack;

    partial class MagicOnionInitializer
    {
        public static global::MessagePack.IFormatterResolver Resolver => MessagePackGeneratedResolver.Instance;
        class MessagePackGeneratedResolver : global::MessagePack.IFormatterResolver
        {
            public static readonly global::MessagePack.IFormatterResolver Instance = new MessagePackGeneratedResolver();

            MessagePackGeneratedResolver() {}

            public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
                => FormatterCache<T>.formatter;

            static class FormatterCache<T>
            {
                public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

                static FormatterCache()
                {
                    var f = MessagePackGeneratedGetFormatterHelper.GetFormatter(typeof(T));
                    if (f != null)
                    {
                        formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                    }
                }
            }
        }
        static class MessagePackGeneratedGetFormatterHelper
        {
            static readonly global::System.Collections.Generic.Dictionary<global::System.Type, int> lookup;

            static MessagePackGeneratedGetFormatterHelper()
            {
                lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(6)
                {
                    {typeof(global::TempProject.MyGenericObject<global::System.Int32>), 0},
                    {typeof(global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::System.Int32>>), 1},
                    {typeof(global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::System.Int32>>>), 2},
                    {typeof(global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyObject>>>), 3},
                    {typeof(global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyObject>>), 4},
                    {typeof(global::TempProject.MyGenericObject<global::TempProject.MyObject>), 5},
                };
            }
            internal static object GetFormatter(global::System.Type t)
            {
                int key;
                if (!lookup.TryGetValue(t, out key))
                {
                    return null;
                }
            
                switch (key)
                {
                    case 0: return new global::MessagePack.Formatters.TempProject.MyGenericObjectFormatter<global::System.Int32>();
                    case 1: return new global::MessagePack.Formatters.TempProject.MyGenericObjectFormatter<global::TempProject.MyGenericObject<global::System.Int32>>();
                    case 2: return new global::MessagePack.Formatters.TempProject.MyGenericObjectFormatter<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::System.Int32>>>();
                    case 3: return new global::MessagePack.Formatters.TempProject.MyGenericObjectFormatter<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyObject>>>();
                    case 4: return new global::MessagePack.Formatters.TempProject.MyGenericObjectFormatter<global::TempProject.MyGenericObject<global::TempProject.MyObject>>();
                    case 5: return new global::MessagePack.Formatters.TempProject.MyGenericObjectFormatter<global::TempProject.MyObject>();
                    default: return null;
                }
            }
        }
        /// <summary>Type hints for Ahead-of-Time compilation.</summary>
        [Preserve]
        internal static class TypeHints
        {
            [Preserve]
            internal static void Register()
            {
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::MessagePack.Nil>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::System.Int32>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::TempProject.MyGenericObject<global::System.Int32>>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::System.Int32>>>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::System.Int32>>>>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyObject>>>>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::TempProject.MyGenericObject<global::TempProject.MyGenericObject<global::TempProject.MyObject>>>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::TempProject.MyGenericObject<global::TempProject.MyObject>>();
                _ = MessagePackGeneratedResolver.Instance.GetFormatter<global::TempProject.MyObject>();
            }
        }
    }
}
