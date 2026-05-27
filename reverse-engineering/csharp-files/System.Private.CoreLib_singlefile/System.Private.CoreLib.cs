Error decompiling @06000011 Interop.Sys.GetEnv
in assembly "./System.Private.CoreLib.dll"
 ---> System.Collections.Generic.KeyNotFoundException: The given key '0' was not present in the dictionary.
   at System.ThrowHelper.ThrowKeyNotFoundException[T](T key) in offset 0
   at System.Collections.Generic.Dictionary`2.get_Item(TKey key) in offset 23
   at ICSharpCode.Decompiler.IL.Transforms.AssignVariableNames.VariableScope..ctor(ILFunction function, ILTransformContext context, VariableScope parentScope) in AssignVariableNames.cs:line 212
   at ICSharpCode.Decompiler.IL.Transforms.AssignVariableNames.Run(ILFunction function, ILTransformContext context) in AssignVariableNames.cs:line 497
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext) in CSharpDecompiler.cs:line 1762
-- continuing with outer exception (ICSharpCode.Decompiler.DecompilerException) --
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext) in CSharpDecompiler.cs:line 1798
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DoDecompile(IMethod method, DecompileRun decompileRun, ITypeResolveContext decompilationContext) in CSharpDecompiler.cs:line 1646
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.<>c__DisplayClass75_0.<DoDecompile>g__DoDecompileMember|0(IEntity entity, RecordDecompiler recordDecompiler, PartialTypeInfo partialType) in CSharpDecompiler.cs:line 1521
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DoDecompile(ITypeDefinition typeDef, DecompileRun decompileRun, ITypeResolveContext decompilationContext) in CSharpDecompiler.cs:line 1384
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.<>c__DisplayClass75_0.<DoDecompile>g__DoDecompileMember|0(IEntity entity, RecordDecompiler recordDecompiler, PartialTypeInfo partialType) in CSharpDecompiler.cs:line 1533
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DoDecompile(ITypeDefinition typeDef, DecompileRun decompileRun, ITypeResolveContext decompilationContext) in CSharpDecompiler.cs:line 1384
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DoDecompileTypes(IEnumerable`1 types, DecompileRun decompileRun, ITypeResolveContext decompilationContext, SyntaxTree syntaxTree) in CSharpDecompiler.cs:line 659
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileWholeModuleAsSingleFile(Boolean sortTypes) in CSharpDecompiler.cs:line 692
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileWholeModuleAsSingleFile() in CSharpDecompiler.cs:line 669
   at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileWholeModuleAsString() in CSharpDecompiler.cs:line 933
   at ICSharpCode.ILSpyCmd.ILSpyCmdProgram.Decompile(String assemblyFileName, TextWriter output, String typeName) in IlspyCmdProgram.cs:line 394
   at ICSharpCode.ILSpyCmd.ILSpyCmdProgram.<OnExecuteAsync>g__PerformPerFileAction|83_0(String fileName, <>c__DisplayClass83_0&) in IlspyCmdProgram.cs:line 311
   at ICSharpCode.ILSpyCmd.ILSpyCmdProgram.<OnExecuteAsync>d__83.MoveNext() in IlspyCmdProgram.cs:line 232