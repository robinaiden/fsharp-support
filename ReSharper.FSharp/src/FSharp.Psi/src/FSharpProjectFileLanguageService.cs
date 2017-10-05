﻿using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Resources;
using JetBrains.ReSharper.Plugins.FSharp.Common.Checker;
using JetBrains.ReSharper.Plugins.FSharp.ProjectModelBase;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Parsing;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;
using JetBrains.UI.Icons;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi
{
  [ProjectFileType(typeof(FSharpProjectFileType))]
  public class FSharpProjectFileLanguageService : ProjectFileLanguageService
  {
    private readonly FSharpCheckerService myCheckerService;

    public FSharpProjectFileLanguageService(ProjectFileType projectFileType, FSharpCheckerService checkerService)
      : base(projectFileType)
    {
      myCheckerService = checkerService;
    }

    protected override PsiLanguageType PsiLanguageType => FSharpLanguage.Instance;
    public override IconId Icon => ProjectModelThemedIcons.Fsharp.Id;

    public override ILexerFactory GetMixedLexerFactory(ISolution solution, IBuffer buffer,
      IPsiSourceFile sourceFile = null)
    {
      return sourceFile != null
        ? new FSharpLexerFactory(sourceFile, myCheckerService.GetDefines(sourceFile))
        : FSharpLanguage.Instance.LanguageService().GetPrimaryLexerFactory();
    }

    public override IPsiSourceFileProperties GetPsiProperties(IProjectFile projectFile, IPsiSourceFile sourceFile,
      IsCompileService isCompileService)
    {
      return new FSharpPsiProperties(projectFile, sourceFile);
    }
  }
}