﻿using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Cache2.Parts;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.DeclaredElement;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Cache2
{
  internal class FSharpUnionCase : FSharpClass
  {

    public FSharpUnionCase([NotNull] IClassPart part) : base(part)
    {
    }

    public IEnumerable<FSharpFieldProperty> CaseFields =>
      EnumerateParts<UnionCasePart, FSharpFieldProperty>(part => part.CaseFields);
  }
}