using MagicOnion.Client.SourceGenerator.CodeAnalysis;

namespace MagicOnion.Client.SourceGenerator.CodeGen;

internal class MessagePackFormatterResolverGenerator : ISerializerFormatterGenerator
{
    public string Build(GenerationContext generationContext, SerializationFormatterCodeGenContext ctx)
    {
        EmitPreamble(generationContext, ctx);
        EmitBody(generationContext, ctx);
        EmitPostscript(generationContext, ctx);

        return ctx.GetWrittenText();
    }

    static void EmitPreamble(GenerationContext generationContext, SerializationFormatterCodeGenContext ctx)
    {
        ctx.TextWriter.WriteLine("""
            // <auto-generated />
            #pragma warning disable CS0618 // 'member' is obsolete: 'text'
            #pragma warning disable CS0612 // 'member' is obsolete
            #pragma warning disable CS8019 // Unnecessary using directive.
            #pragma warning disable CS1522 // Empty switch block
            
            """);
    }

    static void EmitBody(GenerationContext generationContext, SerializationFormatterCodeGenContext ctx)
    {
        if (!string.IsNullOrEmpty(generationContext.Namespace))
        {
            ctx.TextWriter.WriteLine($$"""
            namespace {{generationContext.Namespace}}
            {
            """);
        }
        ctx.TextWriter.WriteLine($$"""
                using global::System;
                using global::MessagePack;

                partial class {{generationContext.InitializerPartialTypeName}}
                {
                    public static global::MessagePack.IFormatterResolver Resolver => MessagePackGeneratedResolver.Instance;
            """);

        EmitResolver(ctx);
        EmitGetFormatterHelper(ctx);
        EmitTypeHints(ctx);

        ctx.TextWriter.WriteLine($$"""
                }
            """);

        if (!string.IsNullOrEmpty(generationContext.Namespace))
        {
            ctx.TextWriter.WriteLine($$"""
            }
            """);
        }
    }

    static void EmitResolver(SerializationFormatterCodeGenContext ctx)
    {
        ctx.TextWriter.WriteLine($$"""
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
            """);
    }

    static void EmitGetFormatterHelper(SerializationFormatterCodeGenContext ctx)
    {
        ctx.TextWriter.WriteLine($$"""
                    static class MessagePackGeneratedGetFormatterHelper
                    {
                        static readonly global::System.Collections.Generic.Dictionary<global::System.Type, int> lookup;

                        static MessagePackGeneratedGetFormatterHelper()
                        {
                            lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>({{ctx.FormatterRegistrations.Count}})
                            {
            """);
        foreach (var (resolverInfo, index) in ctx.FormatterRegistrations.Select((x, i) => (x, i)))
        {
            ctx.TextWriter.WriteLine($$"""
                                {typeof({{resolverInfo.FullName}}), {{index}}},
            """);
        }
        ctx.TextWriter.WriteLine($$"""
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
            """);
        foreach (var (resolverInfo, index) in ctx.FormatterRegistrations.Select((x, i) => (x, i)))
        {
            if (resolverInfo is EnumSerializationInfo)
            {
                // Use EnumFormatter generated by MagicOnion.Client.SourceGenerator
                ctx.TextWriter.WriteLine($$"""
                                case {{index}}: return new MessagePackEnumFormatters.{{resolverInfo.FormatterName}}{{resolverInfo.FormatterConstructorArgs}};
            """);
            }
            else
            {
                // Use formatter generated by MessagePack generator.
                ctx.TextWriter.WriteLine($$"""
                                case {{index}}: return new {{(resolverInfo.FormatterName.StartsWith("global::") || string.IsNullOrWhiteSpace(ctx.FormatterNamespace) ? "" : ctx.FormatterNamespace + ".") + resolverInfo.FormatterName}}{{resolverInfo.FormatterConstructorArgs}};
            """);
            }
        }
        ctx.TextWriter.WriteLine($$"""
                                default: return null;
                            }
                        }
                    }
            """);
    }

    static void EmitTypeHints(SerializationFormatterCodeGenContext ctx)
    {
        ctx.TextWriter.WriteLine($$"""
                    /// <summary>Type hints for Ahead-of-Time compilation.</summary>
                    [Preserve]
                    static class TypeHints
                    {
                        [Preserve]
                        internal static void Register()
                        {
            """);
        foreach (var typeHint in ctx.TypeHints)
        {
            ctx.TextWriter.WriteLine($$"""
                            _ = MessagePackGeneratedResolver.Instance.GetFormatter<{{typeHint.FullName}}>();
            """);
        }
        ctx.TextWriter.WriteLine($$"""
                        }
                    }
            """);
    }

    static void EmitPostscript(GenerationContext generationContext, SerializationFormatterCodeGenContext ctx)
    {
    }
}
