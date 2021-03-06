﻿using JetBrains.Annotations;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Tree;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Caches2;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Cache2.Parts
{
  internal class RecordPart : SimpleTypePartBase, Class.IClassPart
  {
    public readonly bool HasCliMutable;

    public RecordPart([NotNull] IFSharpTypeDeclaration declaration, [NotNull] ICacheBuilder cacheBuilder)
      : base(declaration, cacheBuilder)
    {
      HasCliMutable = declaration.Attributes.Any(attr => attr.ShortNameEquals("CLIMutable")); // todo: resolve
    }

    public RecordPart(IReader reader) : base(reader)
    {
    }

    public override TypeElement CreateTypeElement()
    {
      return new FSharpRecord(this);
    }

    protected override byte SerializationTag => (byte) FSharpPartKind.Record;
  }
}