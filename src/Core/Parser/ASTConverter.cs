﻿using System;
using System.Collections.Generic;
using CppSharp.Parser.AST;

namespace CppSharp
{
    #region Parser AST visitors

    /// <summary>
    /// Implements the visitor pattern for the generated type bindings.
    /// </summary>
    public abstract class TypeVisitor<TRet>
    {
        public abstract TRet VisitTag(TagType type);
        public abstract TRet VisitArray(ArrayType type);
        public abstract TRet VisitFunction(FunctionType type);
        public abstract TRet VisitPointer(PointerType type);
        public abstract TRet VisitMemberPointer(MemberPointerType type);
        public abstract TRet VisitTypedef(TypedefType type);
        public abstract TRet VisitAttributed(AttributedType type);
        public abstract TRet VisitDecayed(DecayedType type);
        public abstract TRet VisitTemplateSpecialization(TemplateSpecializationType type);
        public abstract TRet VisitTemplateParameter(TemplateParameterType type);
        public abstract TRet VisitTemplateParameterSubstitution(TemplateParameterSubstitutionType type);
        public abstract TRet VisitInjectedClassName(InjectedClassNameType type);
        public abstract TRet VisitDependentName(DependentNameType type);
        public abstract TRet VisitBuiltin(BuiltinType type);
        public abstract TRet VisitPackExpansion(PackExpansionType type);

        public TRet Visit(Parser.AST.Type type)
        {
            if (type == null)
                return default(TRet);

            switch (type.Kind)
            {
                case TypeKind.Tag:
                {
                    var _type = TagType.__CreateInstance(type.__Instance);
                    return VisitTag(_type);
                }
                case TypeKind.Array:
                {
                    var _type = ArrayType.__CreateInstance(type.__Instance);
                    return VisitArray(_type);
                }
                case TypeKind.Function:
                {
                    var _type = FunctionType.__CreateInstance(type.__Instance);
                    return VisitFunction(_type);
                }
                case TypeKind.Pointer:
                {
                    var _type = PointerType.__CreateInstance(type.__Instance);
                    return VisitPointer(_type);
                }
                case TypeKind.MemberPointer:
                {
                    var _type = MemberPointerType.__CreateInstance(type.__Instance);
                    return VisitMemberPointer(_type);
                }
                case TypeKind.Typedef:
                {
                    var _type = TypedefType.__CreateInstance(type.__Instance);
                    return VisitTypedef(_type);
                }
                case TypeKind.Attributed:
                {
                    var _type = AttributedType.__CreateInstance(type.__Instance);
                    return VisitAttributed(_type);
                }
                case TypeKind.Decayed:
                {
                    var _type = DecayedType.__CreateInstance(type.__Instance);
                    return VisitDecayed(_type);
                }
                case TypeKind.TemplateSpecialization:
                {
                    var _type = TemplateSpecializationType.__CreateInstance(type.__Instance);
                    return VisitTemplateSpecialization(_type);
                }
                case TypeKind.TemplateParameter:
                {
                    var _type = TemplateParameterType.__CreateInstance(type.__Instance);
                    return VisitTemplateParameter(_type);
                }
                case TypeKind.TemplateParameterSubstitution:
                {
                    var _type = TemplateParameterSubstitutionType.__CreateInstance(type.__Instance);
                    return VisitTemplateParameterSubstitution(_type);
                }
                case TypeKind.InjectedClassName:
                {
                    var _type = InjectedClassNameType.__CreateInstance(type.__Instance);
                    return VisitInjectedClassName(_type);
                }
                case TypeKind.DependentName:
                {
                    var _type = DependentNameType.__CreateInstance(type.__Instance);
                    return VisitDependentName(_type);
                }
                case TypeKind.Builtin:
                {
                    var _type = BuiltinType.__CreateInstance(type.__Instance);
                    return VisitBuiltin(_type);
                }
                case TypeKind.PackExpansion:
                {
                    var _type = PackExpansionType.__CreateInstance(type.__Instance);
                    return VisitPackExpansion(_type);
                }
            }

            throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Implements the visitor pattern for the generated decl bindings.
    /// </summary>
    public abstract class DeclVisitor<TRet>
    {
        public abstract TRet VisitTranslationUnit(TranslationUnit decl);
        public abstract TRet VisitNamespace(Namespace decl);
        public abstract TRet VisitTypedef(TypedefDecl decl);
        public abstract TRet VisitParameter(Parameter decl);
        public abstract TRet VisitFunction(Function decl);
        public abstract TRet VisitMethod(Method decl);
        public abstract TRet VisitEnumeration(Enumeration decl);
        public abstract TRet VisitEnumerationItem(Enumeration.Item decl);
        public abstract TRet VisitVariable(Variable decl);
        public abstract TRet VisitFriend(Friend decl);
        public abstract TRet VisitField(Field decl);
        public abstract TRet VisitAccessSpecifier(AccessSpecifierDecl decl);
        public abstract TRet VisitClass(Class decl);
        public abstract TRet VisitClassTemplate(ClassTemplate decl);
        public abstract TRet VisitClassTemplateSpecialization(
            ClassTemplateSpecialization decl);
        public abstract TRet VisitClassTemplatePartialSpecialization(
            ClassTemplatePartialSpecialization decl);
        public abstract TRet VisitFunctionTemplate(FunctionTemplate decl);

        public virtual TRet Visit(Parser.AST.Declaration decl)
        {
            switch (decl.Kind)
            {
                case DeclarationKind.TranslationUnit:
                    {
                        var _decl = TranslationUnit.__CreateInstance(decl.__Instance);
                        return VisitTranslationUnit(_decl);
                    }
                case DeclarationKind.Namespace:
                    {
                        var _decl = Namespace.__CreateInstance(decl.__Instance);
                        return VisitNamespace(_decl);
                    }
                case DeclarationKind.Typedef:
                    {
                        var _decl = TypedefDecl.__CreateInstance(decl.__Instance);
                        return VisitTypedef(_decl);
                    }
                case DeclarationKind.Parameter:
                    {
                        var _decl = Parameter.__CreateInstance(decl.__Instance);
                        return VisitParameter(_decl);
                    }
                case DeclarationKind.Function:
                    {
                        var _decl = Function.__CreateInstance(decl.__Instance);
                        return VisitFunction(_decl);
                    }
                case DeclarationKind.Method:
                    {
                        var _decl = Method.__CreateInstance(decl.__Instance);
                        return VisitMethod(_decl);
                    }
                case DeclarationKind.Enumeration:
                    {
                        var _decl = Enumeration.__CreateInstance(decl.__Instance);
                        return VisitEnumeration(_decl);
                    }
                case DeclarationKind.EnumerationItem:
                    {
                        var _decl = Enumeration.Item.__CreateInstance(decl.__Instance);
                        return VisitEnumerationItem(_decl);
                    }
                case DeclarationKind.Variable:
                    {
                        var _decl = Variable.__CreateInstance(decl.__Instance);
                        return VisitVariable(_decl);
                    }
                case DeclarationKind.Friend:
                    {
                        var _decl = Friend.__CreateInstance(decl.__Instance);
                        return VisitFriend(_decl);
                    }
                case DeclarationKind.Field:
                    {
                        var _decl = Field.__CreateInstance(decl.__Instance);
                        return VisitField(_decl);
                    }
                case DeclarationKind.AccessSpecifier:
                    {
                        var _decl = AccessSpecifierDecl.__CreateInstance(decl.__Instance);
                        return VisitAccessSpecifier(_decl);
                    }
                case DeclarationKind.Class:
                    {
                        var _decl = Class.__CreateInstance(decl.__Instance);
                        return VisitClass(_decl);
                    }
                case DeclarationKind.ClassTemplate:
                    {
                        var _decl = ClassTemplate.__CreateInstance(decl.__Instance);
                        return VisitClassTemplate(_decl);
                    }
                case DeclarationKind.ClassTemplateSpecialization:
                    {
                        var _decl = ClassTemplateSpecialization.__CreateInstance(decl.__Instance);
                        return VisitClassTemplateSpecialization(_decl);
                    }
                case DeclarationKind.ClassTemplatePartialSpecialization:
                    {
                        var _decl = ClassTemplatePartialSpecialization.__CreateInstance(decl.__Instance);
                        return VisitClassTemplatePartialSpecialization(_decl);
                    }
                case DeclarationKind.FunctionTemplate:
                    {
                        var _decl = FunctionTemplate.__CreateInstance(decl.__Instance);
                        return VisitFunctionTemplate(_decl);
                    }
            }

            throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Implements the visitor pattern for the generated comment bindings.
    /// </summary>
    public abstract class CommentsVisitor<TRet>
    {
        public abstract TRet VisitFullComment(FullComment comment);

        protected abstract TRet VisitBlockCommandComment(BlockCommandComment comment);

        protected abstract TRet VisitParamCommandComment(ParamCommandComment comment);

        protected abstract TRet VisitTParamCommandComment(TParamCommandComment comment);

        protected abstract TRet VisitVerbatimBlockComment(VerbatimBlockComment comment);

        protected abstract TRet VisitVerbatimLineComment(VerbatimLineComment comment);

        protected abstract TRet VisitParagraphComment(ParagraphComment comment);

        protected abstract TRet VisitHTMLStartTagComment(HTMLStartTagComment comment);

        protected abstract TRet VisitHTMLEndTagComment(HTMLEndTagComment comment);

        protected abstract TRet VisitTextComment(TextComment comment);

        protected abstract TRet VisitInlineCommandComment(InlineCommandComment comment);

        protected abstract TRet VisitVerbatimBlockLineComment(VerbatimBlockLineComment comment);

        public virtual TRet Visit(Comment comment)
        {
            switch (comment.Kind)
            {
                case CommentKind.FullComment:
                    return VisitFullComment(FullComment.__CreateInstance(comment.__Instance));
                case CommentKind.BlockCommandComment:
                    return VisitBlockCommandComment(BlockCommandComment.__CreateInstance(comment.__Instance));
                case CommentKind.ParamCommandComment:
                    return VisitParamCommandComment(ParamCommandComment.__CreateInstance(comment.__Instance));
                case CommentKind.TParamCommandComment:
                    return VisitTParamCommandComment(TParamCommandComment.__CreateInstance(comment.__Instance));
                case CommentKind.VerbatimBlockComment:
                    return VisitVerbatimBlockComment(VerbatimBlockComment.__CreateInstance(comment.__Instance));
                case CommentKind.VerbatimLineComment:
                    return VisitVerbatimLineComment(VerbatimLineComment.__CreateInstance(comment.__Instance));
                case CommentKind.ParagraphComment:
                    return VisitParagraphComment(ParagraphComment.__CreateInstance(comment.__Instance));
                case CommentKind.HTMLStartTagComment:
                    return VisitHTMLStartTagComment(HTMLStartTagComment.__CreateInstance(comment.__Instance));
                case CommentKind.HTMLEndTagComment:
                    return VisitHTMLEndTagComment(HTMLEndTagComment.__CreateInstance(comment.__Instance));
                case CommentKind.TextComment:
                    return VisitTextComment(TextComment.__CreateInstance(comment.__Instance));
                case CommentKind.InlineCommandComment:
                    return VisitInlineCommandComment(InlineCommandComment.__CreateInstance(comment.__Instance));
                case CommentKind.VerbatimBlockLineComment:
                    return VisitVerbatimBlockLineComment(VerbatimBlockLineComment.__CreateInstance(comment.__Instance));
            }

            throw new ArgumentOutOfRangeException();
        }
    }

    #endregion

    #region Parser AST converters

    /// <summary>
    /// This class converts from the C++ parser AST bindings to the
    /// AST defined in C#.
    /// </summary>
    public class ASTConverter
    {
        ASTContext Context { get; set; }
        readonly TypeConverter typeConverter;
        readonly DeclConverter declConverter;
        readonly CommentConverter commentConverter;

        public ASTConverter(ASTContext context)
        {
            Context = context;
            typeConverter = new TypeConverter();
            commentConverter = new CommentConverter();
            declConverter = new DeclConverter(typeConverter, commentConverter);
            typeConverter.declConverter = declConverter;
        }

        public CppSharp.AST.ASTContext Convert()
        {
            var _ctx = new AST.ASTContext();

            for (uint i = 0; i < Context.TranslationUnitsCount; ++i)
            {
                var unit = Context.getTranslationUnits(i);
                var _unit = declConverter.Visit(unit) as AST.TranslationUnit;
                _ctx.TranslationUnits.Add(_unit);
            }

            foreach (var nativeObject in typeConverter.NativeObjects)
                nativeObject.Dispose();

            foreach (var nativeObject in declConverter.NativeObjects)
                nativeObject.Dispose();

            Context.Dispose();

            return _ctx;
        }
    }

    public class TypeConverter : TypeVisitor<AST.Type>
    {
        internal DeclConverter declConverter;

        public TypeConverter()
        {
            NativeObjects = new HashSet<IDisposable>();
        }

        public HashSet<IDisposable> NativeObjects { get; private set; }

        public AST.QualifiedType VisitQualified(QualifiedType qualType)
        {
            var _qualType = new AST.QualifiedType
            {
                Qualifiers = new AST.TypeQualifiers
                {
                    IsConst = qualType.Qualifiers.IsConst,
                    IsRestrict = qualType.Qualifiers.IsRestrict,
                    IsVolatile = qualType.Qualifiers.IsVolatile,
                },
                Type = Visit(qualType.Type)
            };

            return _qualType;
        }

        AST.ArrayType.ArraySize VisitArraySizeType(ArrayType.ArraySize size)
        {
            switch (size)
            {
                case ArrayType.ArraySize.Constant:
                    return AST.ArrayType.ArraySize.Constant;
                case ArrayType.ArraySize.Variable:
                    return AST.ArrayType.ArraySize.Variable;
                case ArrayType.ArraySize.Dependent:
                    return AST.ArrayType.ArraySize.Dependent;
                case ArrayType.ArraySize.Incomplete:
                    return AST.ArrayType.ArraySize.Incomplete;
                default:
                    throw new ArgumentOutOfRangeException("size");
            }
        }

        void VisitType(Parser.AST.Type origType, CppSharp.AST.Type type)
        {
            type.IsDependent = origType.IsDependent;
            NativeObjects.Add(origType);
        }

        public override AST.Type VisitTag(TagType type)
        {
            var _type = new AST.TagType();
            _type.Declaration = declConverter.Visit(type.Declaration);
            VisitType(type, _type);
            return _type;
        }

        public override AST.Type VisitArray(ArrayType type)
        {
            var _type = new AST.ArrayType
            {
                Size = type.Size,
                SizeType = VisitArraySizeType(type.SizeType),
                QualifiedType = VisitQualified(type.QualifiedType),
                ElementSize = type.ElementSize
            };
            VisitType(type, _type);
            return _type;
        }

        public override AST.Type VisitFunction(FunctionType type)
        {
            var _type = new AST.FunctionType();
            VisitType(type, _type);
            _type.ReturnType = VisitQualified(type.ReturnType);
            _type.CallingConvention = DeclConverter.VisitCallingConvention(
                type.CallingConvention);

            for (uint i = 0; i < type.ParametersCount; ++i)
            {
                var param = type.getParameters(i);
                var _param = declConverter.Visit(param) as AST.Parameter;
                _type.Parameters.Add(_param);
            }

            return _type;
        }

        public override AST.Type VisitPointer(PointerType type)
        {
            var _type = new AST.PointerType();
            _type.QualifiedPointee = VisitQualified(type.QualifiedPointee);
            _type.Modifier = VisitTypeModifier(type.Modifier);
            VisitType(type, _type);
            return _type;
        }

        AST.PointerType.TypeModifier VisitTypeModifier(PointerType.TypeModifier modifier)
        {
            switch (modifier)
            {
                case PointerType.TypeModifier.Value:
                    return AST.PointerType.TypeModifier.Value;
                case PointerType.TypeModifier.Pointer:
                    return AST.PointerType.TypeModifier.Pointer;
                case PointerType.TypeModifier.LVReference:
                    return AST.PointerType.TypeModifier.LVReference;
                case PointerType.TypeModifier.RVReference:
                    return AST.PointerType.TypeModifier.RVReference;
                default:
                    throw new ArgumentOutOfRangeException("modifier");
            }
        }

        public override AST.Type VisitMemberPointer(MemberPointerType type)
        {
            var _type = new CppSharp.AST.MemberPointerType();
            VisitType(type, _type);
            _type.QualifiedPointee = VisitQualified(type.Pointee);
            return _type;
        }

        public override AST.Type VisitTypedef(TypedefType type)
        {
            var _type = new CppSharp.AST.TypedefType();
            VisitType(type, _type);
            _type.Declaration = declConverter.Visit(type.Declaration)
                as AST.TypedefDecl;
            return _type;
        }

        public override AST.Type VisitAttributed(AttributedType type)
        {
            var _type = new CppSharp.AST.AttributedType();
            VisitType(type, _type);
            _type.Modified = VisitQualified(type.Modified);
            _type.Equivalent = VisitQualified(type.Equivalent);
            return _type;
        }

        public override AST.Type VisitDecayed(DecayedType type)
        {
            var _type = new CppSharp.AST.DecayedType();
            _type.Decayed = VisitQualified(type.Decayed);
            _type.Original = VisitQualified(type.Original);
            _type.Pointee = VisitQualified(type.Pointee);
            VisitType(type, _type);
            return _type;
        }

        AST.TemplateArgument VisitTemplateArgument(TemplateArgument arg)
        {
            var _arg = new AST.TemplateArgument();
            _arg.Kind = VisitArgumentKind(arg.Kind);
            _arg.Type = VisitQualified(arg.Type);
            _arg.Declaration = declConverter.Visit(arg.Declaration);
            _arg.Integral = arg.Integral;
            NativeObjects.Add(arg);
            return _arg;
        }

        private AST.TemplateArgument.ArgumentKind VisitArgumentKind(TemplateArgument.ArgumentKind kind)
        {
            switch (kind)
            {
                case TemplateArgument.ArgumentKind.Type:
                    return AST.TemplateArgument.ArgumentKind.Type;
                case TemplateArgument.ArgumentKind.Declaration:
                    return AST.TemplateArgument.ArgumentKind.Declaration;
                case TemplateArgument.ArgumentKind.NullPtr:
                    return AST.TemplateArgument.ArgumentKind.NullPtr;
                case TemplateArgument.ArgumentKind.Integral:
                    return AST.TemplateArgument.ArgumentKind.Integral;
                case TemplateArgument.ArgumentKind.Template:
                    return AST.TemplateArgument.ArgumentKind.Template;
                case TemplateArgument.ArgumentKind.TemplateExpansion:
                    return AST.TemplateArgument.ArgumentKind.TemplateExpansion;
                case TemplateArgument.ArgumentKind.Expression:
                    return AST.TemplateArgument.ArgumentKind.Expression;
                case TemplateArgument.ArgumentKind.Pack:
                    return AST.TemplateArgument.ArgumentKind.Pack;
                default:
                    throw new ArgumentOutOfRangeException("kind");
            }
        }

        public override AST.Type VisitTemplateSpecialization(TemplateSpecializationType type)
        {
            var _type = new CppSharp.AST.TemplateSpecializationType();

            for (uint i = 0; i < type.ArgumentsCount; ++i)
            {
                var arg = type.getArguments(i);
                var _arg = VisitTemplateArgument(arg);
                _type.Arguments.Add(_arg);
            }

            _type.Template = declConverter.Visit(type.Template) as AST.Template;
            _type.Desugared = Visit(type.Desugared);

            VisitType(type, _type);

            return _type;
        }

        public override AST.Type VisitTemplateParameter(TemplateParameterType type)
        {
            var _type = new AST.TemplateParameterType();
            _type.Parameter = DeclConverter.VisitTemplateParameter(type.Parameter);
            _type.Depth = type.Depth;
            _type.Index = type.Index;
            _type.IsParameterPack = type.IsParameterPack;
            VisitType(type, _type);
            return _type;
        }

        public override AST.Type VisitTemplateParameterSubstitution(TemplateParameterSubstitutionType type)
        {
            var _type = new CppSharp.AST.TemplateParameterSubstitutionType();
            _type.Replacement = VisitQualified(type.Replacement);
            VisitType(type, _type);
            return _type;
        }

        public override AST.Type VisitInjectedClassName(InjectedClassNameType type)
        {
            var _type = new CppSharp.AST.InjectedClassNameType();
            _type.TemplateSpecialization = Visit(type.TemplateSpecialization)
                as AST.TemplateSpecializationType;
            _type.Class = declConverter.Visit(type.Class) as AST.Class;
            VisitType(type, _type);
            return _type;
        }

        public override AST.Type VisitDependentName(DependentNameType type)
        {
            var _type = new CppSharp.AST.DependentNameType();
            VisitType(type, _type);
            return _type;
        }

        public override AST.Type VisitBuiltin(BuiltinType type)
        {
            var _type = new CppSharp.AST.BuiltinType();
            _type.Type = VisitPrimitive(type.Type);
            VisitType(type, _type);
            return _type;
        }

        AST.PrimitiveType VisitPrimitive(PrimitiveType type)
        {
            switch (type)
            {
                case PrimitiveType.Null:
                    return AST.PrimitiveType.Null;
                case PrimitiveType.Void:
                    return AST.PrimitiveType.Void;
                case PrimitiveType.Bool:
                    return AST.PrimitiveType.Bool;
                case PrimitiveType.WideChar:
                    return AST.PrimitiveType.WideChar;
                case PrimitiveType.Char:
                    return AST.PrimitiveType.Char;
                case PrimitiveType.UChar:
                    return AST.PrimitiveType.UChar;
                case PrimitiveType.Short:
                    return AST.PrimitiveType.Short;
                case PrimitiveType.UShort:
                    return AST.PrimitiveType.UShort;
                case PrimitiveType.Int:
                    return AST.PrimitiveType.Int;
                case PrimitiveType.UInt:
                    return AST.PrimitiveType.UInt;
                case PrimitiveType.Long:
                    return AST.PrimitiveType.Long;
                case PrimitiveType.ULong:
                    return AST.PrimitiveType.ULong;
                case PrimitiveType.LongLong:
                    return AST.PrimitiveType.LongLong;
                case PrimitiveType.ULongLong:
                    return AST.PrimitiveType.ULongLong;
                case PrimitiveType.Float:
                    return AST.PrimitiveType.Float;
                case PrimitiveType.Double:
                    return AST.PrimitiveType.Double;
                case PrimitiveType.IntPtr:
                    return AST.PrimitiveType.IntPtr;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public override AST.Type VisitPackExpansion(PackExpansionType type)
        {
            var _type = new CppSharp.AST.PackExpansionType();
            _type.IsDependent = type.IsDependent;
            VisitType(type, _type);
            return _type;
        }
    }

    public unsafe class DeclConverter : DeclVisitor<AST.Declaration>
    {
        readonly TypeConverter typeConverter;
        readonly CommentConverter commentConverter;

        readonly Dictionary<IntPtr, AST.Declaration> Declarations;
        readonly Dictionary<IntPtr, AST.PreprocessedEntity> PreprocessedEntities;
        readonly Dictionary<IntPtr, AST.FunctionTemplateSpecialization> FunctionTemplateSpecializations;

        public DeclConverter(TypeConverter type, CommentConverter comment)
        {
            NativeObjects = new HashSet<IDisposable>();
            typeConverter = type;
            commentConverter = comment;
            Declarations = new Dictionary<IntPtr, AST.Declaration>();
            PreprocessedEntities = new Dictionary<IntPtr, AST.PreprocessedEntity>();
            FunctionTemplateSpecializations = new Dictionary<IntPtr, AST.FunctionTemplateSpecialization>();
        }

        public HashSet<IDisposable> NativeObjects { get; private set; }

        public override AST.Declaration Visit(Parser.AST.Declaration decl)
        {
            if (decl == null)
                return null;

            if (decl.OriginalPtr == IntPtr.Zero)
                throw new NotSupportedException("Original pointer must not be null");

            var originalPtr = decl.OriginalPtr;

            // Check if the declaration was already handled and return its
            // existing instance.
            if (CheckForDuplicates(decl))
                if (Declarations.ContainsKey(originalPtr))
                    return Declarations[originalPtr];

            var newDecl = base.Visit(decl);
            return newDecl;
        }

        AST.AccessSpecifier VisitAccessSpecifier(AccessSpecifier access)
        {
            switch (access)
            {
                case AccessSpecifier.Private:
                    return AST.AccessSpecifier.Private;
                case AccessSpecifier.Protected:
                    return AST.AccessSpecifier.Protected;
                case AccessSpecifier.Public:
                    return AST.AccessSpecifier.Public;
            }

            throw new ArgumentOutOfRangeException();
        }

        AST.BaseClassSpecifier VisitBaseClassSpecifier(BaseClassSpecifier @base)
        {
            var _base = new AST.BaseClassSpecifier
            {
                IsVirtual = @base.IsVirtual,
                Access = VisitAccessSpecifier(@base.Access),
                Type = typeConverter.Visit(@base.Type),
                Offset = @base.Offset
            };

            NativeObjects.Add(@base);

            return _base;
        }

        AST.RawComment VisitRawComment(RawComment rawComment)
        {
            var _rawComment = new AST.RawComment
            {
                Kind = ConvertRawCommentKind(rawComment.Kind),
                BriefText = rawComment.BriefText,
                Text = rawComment.Text,
            };

            if (rawComment.FullCommentBlock != null)
                _rawComment.FullComment = commentConverter.Visit(rawComment.FullCommentBlock)
                    as AST.FullComment;

            NativeObjects.Add(rawComment);

            return _rawComment;
        }

        private AST.RawCommentKind ConvertRawCommentKind(RawCommentKind kind)
        {
            switch (kind)
            {
                case RawCommentKind.Invalid:
                    return AST.RawCommentKind.Invalid;
                case RawCommentKind.OrdinaryBCPL:
                    return AST.RawCommentKind.OrdinaryBCPL;
                case RawCommentKind.OrdinaryC:
                    return AST.RawCommentKind.OrdinaryC;
                case RawCommentKind.BCPLSlash:
                    return AST.RawCommentKind.BCPLSlash;
                case RawCommentKind.BCPLExcl:
                    return AST.RawCommentKind.BCPLExcl;
                case RawCommentKind.JavaDoc:
                    return AST.RawCommentKind.JavaDoc;
                case RawCommentKind.Qt:
                    return AST.RawCommentKind.Qt;
                case RawCommentKind.Merged:
                    return AST.RawCommentKind.Merged;
                default:
                    throw new ArgumentOutOfRangeException("kind");
            }
        }

        bool CheckForDuplicates(Declaration decl)
        {
            if (decl.OriginalPtr.ToPointer() == (void*) (0x1))
                return false;

            return !(decl is PreprocessedEntity);
        }

        void VisitDeclaration(Declaration decl, AST.Declaration _decl)
        {
            var originalPtr = decl.OriginalPtr;

            if (CheckForDuplicates(decl))
                if (Declarations.ContainsKey(originalPtr))
                    throw new NotSupportedException("Duplicate declaration processed");

            // Add the declaration to the map so that we can check if have
            // already handled it and return the declaration.
            Declarations[originalPtr] = _decl;

            _decl.Access = VisitAccessSpecifier(decl.Access);
            _decl.Name = decl.Name;
            _decl.Namespace = Visit(decl._Namespace) as AST.DeclarationContext;
            _decl.Location = new SourceLocation(decl.Location.ID);
            _decl.LineNumberStart = decl.LineNumberStart;
            _decl.LineNumberEnd = decl.LineNumberEnd;
            _decl.DebugText = decl.DebugText;
            _decl.IsIncomplete = decl.IsIncomplete;
            _decl.IsDependent = decl.IsDependent;
            _decl.DefinitionOrder = decl.DefinitionOrder;
            if (decl.CompleteDeclaration != null)
                _decl.CompleteDeclaration = Visit(decl.CompleteDeclaration);
            if (decl.Comment != null)
                _decl.Comment = VisitRawComment(decl.Comment);

            for (uint i = 0; i < decl.PreprocessedEntitiesCount; ++i)
            {
                var entity = decl.getPreprocessedEntities(i);
                var _entity = VisitPreprocessedEntity(entity);
                _decl.PreprocessedEntities.Add(_entity);
            }

            _decl.OriginalPtr = originalPtr;

            NativeObjects.Add(decl);
        }

        void VisitDeclContext(DeclarationContext ctx, AST.DeclarationContext _ctx)
        {
            for (uint i = 0; i < ctx.NamespacesCount; ++i)
            {
                var decl = ctx.getNamespaces(i);
                var _decl = Visit(decl) as AST.Namespace;
                _ctx.Namespaces.Add(_decl);
            }

            for (uint i = 0; i < ctx.EnumsCount; ++i)
            {
                var decl = ctx.getEnums(i);
                var _decl = Visit(decl) as AST.Enumeration;
                _ctx.Enums.Add(_decl);
            }

            for (uint i = 0; i < ctx.FunctionsCount; ++i)
            {
                var decl = ctx.getFunctions(i);
                var _decl = Visit(decl) as AST.Function;
                _ctx.Functions.Add(_decl);
            }

            for (uint i = 0; i < ctx.ClassesCount; ++i)
            {
                var decl = ctx.getClasses(i);
                var _decl = Visit(decl) as AST.Class;
                _ctx.Classes.Add(_decl);
            }

            for (uint i = 0; i < ctx.TemplatesCount; ++i)
            {
                var decl = ctx.getTemplates(i);
                var _decl = Visit(decl) as AST.Template;
                _ctx.Templates.Add(_decl);
            }

            for (uint i = 0; i < ctx.TypedefsCount; ++i)
            {
                var decl = ctx.getTypedefs(i);
                var _decl = Visit(decl) as AST.TypedefDecl;
                _ctx.Typedefs.Add(_decl);
            }

            for (uint i = 0; i < ctx.VariablesCount; ++i)
            {
                var decl = ctx.getVariables(i);
                var _decl = Visit(decl) as AST.Variable;
                _ctx.Variables.Add(_decl);
            }

            for (uint i = 0; i < ctx.FriendsCount; ++i)
            {
                var decl = ctx.getFriends(i);
                var _decl = Visit(decl) as AST.Friend;
                _ctx.Declarations.Add(_decl);
            }

            // Anonymous types
        }

        public override AST.Declaration VisitTranslationUnit(TranslationUnit decl)
        {
            var _unit = new AST.TranslationUnit();
            _unit.FilePath = decl.FileName;
            _unit.IsSystemHeader = decl.IsSystemHeader;

            for (uint i = 0; i < decl.MacrosCount; ++i)
            {
                var macro = decl.getMacros(i);
                var _macro = VisitMacroDefinition(macro);
                _unit.Macros.Add(_macro);
            }

            VisitDeclaration(decl, _unit);
            VisitDeclContext(decl, _unit);
            return _unit;
        }

        public override AST.Declaration VisitNamespace(Namespace decl)
        {
            var _namespace = new AST.Namespace();
            VisitDeclaration(decl, _namespace);
            VisitDeclContext(decl, _namespace);
            _namespace.IsInline = decl.IsInline;

            return _namespace;
        }

        public override AST.Declaration VisitTypedef(TypedefDecl decl)
        {
            var _typedef = new AST.TypedefDecl();
            VisitDeclaration(decl, _typedef);
            _typedef.QualifiedType = typeConverter.VisitQualified(decl.QualifiedType);

            return _typedef;
        }

        public override AST.Declaration VisitParameter(Parameter decl)
        {
            var _param = new AST.Parameter();
            VisitDeclaration(decl, _param);

            _param.QualifiedType = typeConverter.VisitQualified(decl.QualifiedType);
            _param.IsIndirect = decl.IsIndirect;
            _param.HasDefaultValue = decl.HasDefaultValue;
            _param.Index = decl.Index;
            _param.DefaultArgument = VisitStatement(decl.DefaultArgument);

            return _param;
        }

        private AST.Expression VisitStatement(Statement statement)
        {
            if (statement == null)
                return null;

            AST.Expression expression;
            switch (statement.Class)
            {
                case StatementClass.BinaryOperator:
                    var binaryOperator = BinaryOperator.__CreateInstance(statement.__Instance);
                    expression = new AST.BinaryOperator(VisitStatement(binaryOperator.LHS),
                        VisitStatement(binaryOperator.RHS), binaryOperator.OpcodeStr);
                    break;
                case StatementClass.CallExprClass:
                    var callExpression = new AST.CallExpr();
                    var callExpr = CallExpr.__CreateInstance(statement.__Instance);
                    for (uint i = 0; i < callExpr.ArgumentsCount; i++)
                    {
                        var argument = VisitStatement(callExpr.getArguments(i));
                        callExpression.Arguments.Add(argument);
                    }
                    expression = callExpression;
                    break;
                case StatementClass.DeclRefExprClass:
                    expression = new AST.BuiltinTypeExpression();
                    expression.Class = AST.StatementClass.DeclarationReference;
                    break;
                case StatementClass.CXXOperatorCallExpr:
                    expression = new AST.BuiltinTypeExpression();
                    expression.Class = AST.StatementClass.CXXOperatorCall;
                    break;
                case StatementClass.CXXConstructExprClass:
                    var constructorExpression = new AST.CXXConstructExpr();
                    var constructorExpr = CXXConstructExpr.__CreateInstance(statement.__Instance);
                    for (uint i = 0; i < constructorExpr.ArgumentsCount; i++)
                    {
                        var argument = VisitStatement(constructorExpr.getArguments(i));
                        constructorExpression.Arguments.Add(argument);
                    }
                    expression = constructorExpression;
                    break;
                default:
                    expression = new AST.BuiltinTypeExpression();
                    break;
            }
            expression.Declaration = Visit(statement.Decl);
            expression.String = statement.String;

            return expression;
        }

        public void VisitFunction(Function function, AST.Function _function)
        {
            VisitDeclaration(function, _function);

            _function.ReturnType = typeConverter.VisitQualified(function.ReturnType);
            _function.IsReturnIndirect = function.IsReturnIndirect;
            _function.HasThisReturn = function.HasThisReturn;
            _function.IsVariadic = function.IsVariadic;
            _function.IsInline = function.IsInline;
            _function.IsPure = function.IsPure;
            _function.IsDeleted = function.IsDeleted;
            _function.OperatorKind = VisitCXXOperatorKind(function.OperatorKind);
            _function.Mangled = function.Mangled;
            _function.Signature = function.Signature;
            _function.CallingConvention = VisitCallingConvention(function.CallingConvention);

            for (uint i = 0; i < function.ParametersCount; ++i)
            {
                var param = function.getParameters(i);
                var _param = Visit(param) as AST.Parameter;
                _function.Parameters.Add(_param);
            }
        }

        public override AST.Declaration VisitFunction(Function decl)
        {
            var _function = new CppSharp.AST.Function();
            VisitFunction(decl, _function);

            return _function;
        }

        public override AST.Declaration VisitMethod(Method decl)
        {
            var _method = new AST.Method();
            VisitFunction(decl, _method);

            _method.IsVirtual = decl.IsVirtual;
            _method.IsStatic = decl.IsStatic;
            _method.IsConst = decl.IsConst;
            _method.IsImplicit = decl.IsImplicit;
            _method.IsExplicit = decl.IsExplicit;
            _method.IsOverride = decl.IsOverride;

            _method.Kind = VisitCXXMethodKind(decl.MethodKind);

            _method.IsDefaultConstructor = decl.IsDefaultConstructor;
            _method.IsCopyConstructor = decl.IsCopyConstructor;
            _method.IsMoveConstructor = decl.IsMoveConstructor;

            _method.ConversionType = typeConverter.VisitQualified(decl.ConversionType);

            return _method;
        }

        AST.CXXMethodKind VisitCXXMethodKind(CXXMethodKind methodKind)
        {
            switch (methodKind)
            {
                case CXXMethodKind.Normal:
                    return AST.CXXMethodKind.Normal;
                case CXXMethodKind.Constructor:
                    return AST.CXXMethodKind.Constructor;
                case CXXMethodKind.Destructor:
                    return AST.CXXMethodKind.Destructor;
                case CXXMethodKind.Conversion:
                    return AST.CXXMethodKind.Conversion;
                case CXXMethodKind.Operator:
                    return AST.CXXMethodKind.Operator;
                case CXXMethodKind.UsingDirective:
                    return AST.CXXMethodKind.UsingDirective;
                default:
                    throw new ArgumentOutOfRangeException("methodKind");
            }
        }

        AST.CXXOperatorKind VisitCXXOperatorKind(CXXOperatorKind operatorKind)
        {
            switch (operatorKind)
            {
                case CXXOperatorKind.None:
                    return AST.CXXOperatorKind.None;
                case CXXOperatorKind.New:
                    return AST.CXXOperatorKind.New;
                case CXXOperatorKind.Delete:
                    return AST.CXXOperatorKind.Delete;
                case CXXOperatorKind.Array_New:
                    return AST.CXXOperatorKind.Array_New;
                case CXXOperatorKind.Array_Delete:
                    return AST.CXXOperatorKind.Array_Delete;
                case CXXOperatorKind.Plus:
                    return AST.CXXOperatorKind.Plus;
                case CXXOperatorKind.Minus:
                    return AST.CXXOperatorKind.Minus;
                case CXXOperatorKind.Star:
                    return AST.CXXOperatorKind.Star;
                case CXXOperatorKind.Slash:
                    return AST.CXXOperatorKind.Slash;
                case CXXOperatorKind.Percent:
                    return AST.CXXOperatorKind.Percent;
                case CXXOperatorKind.Caret:
                    return AST.CXXOperatorKind.Caret;
                case CXXOperatorKind.Amp:
                    return AST.CXXOperatorKind.Amp;
                case CXXOperatorKind.Pipe:
                    return AST.CXXOperatorKind.Pipe;
                case CXXOperatorKind.Tilde:
                    return AST.CXXOperatorKind.Tilde;
                case CXXOperatorKind.Exclaim:
                    return AST.CXXOperatorKind.Exclaim;
                case CXXOperatorKind.Equal:
                    return AST.CXXOperatorKind.Equal;
                case CXXOperatorKind.Less:
                    return AST.CXXOperatorKind.Less;
                case CXXOperatorKind.Greater:
                    return AST.CXXOperatorKind.Greater;
                case CXXOperatorKind.PlusEqual:
                    return AST.CXXOperatorKind.PlusEqual;
                case CXXOperatorKind.MinusEqual:
                    return AST.CXXOperatorKind.MinusEqual;
                case CXXOperatorKind.StarEqual:
                    return AST.CXXOperatorKind.StarEqual;
                case CXXOperatorKind.SlashEqual:
                    return AST.CXXOperatorKind.SlashEqual;
                case CXXOperatorKind.PercentEqual:
                    return AST.CXXOperatorKind.PercentEqual;
                case CXXOperatorKind.CaretEqual:
                    return AST.CXXOperatorKind.CaretEqual;
                case CXXOperatorKind.AmpEqual:
                    return AST.CXXOperatorKind.AmpEqual;
                case CXXOperatorKind.PipeEqual:
                    return AST.CXXOperatorKind.PipeEqual;
                case CXXOperatorKind.LessLess:
                    return AST.CXXOperatorKind.LessLess;
                case CXXOperatorKind.GreaterGreater:
                    return AST.CXXOperatorKind.GreaterGreater;
                case CXXOperatorKind.LessLessEqual:
                    return AST.CXXOperatorKind.LessLessEqual;
                case CXXOperatorKind.GreaterGreaterEqual:
                    return AST.CXXOperatorKind.GreaterGreaterEqual;
                case CXXOperatorKind.EqualEqual:
                    return AST.CXXOperatorKind.EqualEqual;
                case CXXOperatorKind.ExclaimEqual:
                    return AST.CXXOperatorKind.ExclaimEqual;
                case CXXOperatorKind.LessEqual:
                    return AST.CXXOperatorKind.LessEqual;
                case CXXOperatorKind.GreaterEqual:
                    return AST.CXXOperatorKind.GreaterEqual;
                case CXXOperatorKind.AmpAmp:
                    return AST.CXXOperatorKind.AmpAmp;
                case CXXOperatorKind.PipePipe:
                    return AST.CXXOperatorKind.PipePipe;
                case CXXOperatorKind.PlusPlus:
                    return AST.CXXOperatorKind.PlusPlus;
                case CXXOperatorKind.MinusMinus:
                    return AST.CXXOperatorKind.MinusMinus;
                case CXXOperatorKind.Comma:
                    return AST.CXXOperatorKind.Comma;
                case CXXOperatorKind.ArrowStar:
                    return AST.CXXOperatorKind.ArrowStar;
                case CXXOperatorKind.Arrow:
                    return AST.CXXOperatorKind.Arrow;
                case CXXOperatorKind.Call:
                    return AST.CXXOperatorKind.Call;
                case CXXOperatorKind.Subscript:
                    return AST.CXXOperatorKind.Subscript;
                case CXXOperatorKind.Conditional:
                    return AST.CXXOperatorKind.Conditional;
                case CXXOperatorKind.Coawait:
                    return AST.CXXOperatorKind.Coawait;
                default:
                    throw new ArgumentOutOfRangeException("operatorKind");
            }
        }

        static internal AST.CallingConvention VisitCallingConvention(CallingConvention callingConvention)
        {
            switch (callingConvention)
            {
                case CallingConvention.Default:
                    return AST.CallingConvention.Default;
                case CallingConvention.C:
                    return AST.CallingConvention.C;
                case CallingConvention.StdCall:
                    return AST.CallingConvention.StdCall;
                case CallingConvention.ThisCall:
                    return AST.CallingConvention.ThisCall;
                case CallingConvention.FastCall:
                    return AST.CallingConvention.FastCall;
                case CallingConvention.Unknown:
                    return AST.CallingConvention.Unknown;
                default:
                    throw new ArgumentOutOfRangeException("callingConvention");
            }
        }

        public override AST.Declaration VisitEnumeration(Enumeration decl)
        {
            var _enum = new AST.Enumeration();
            VisitDeclaration(decl, _enum);

            _enum.Modifiers = VisitEnumModifiers(decl.Modifiers);
            _enum.Type = typeConverter.Visit(decl.Type);
            _enum.BuiltinType = typeConverter.Visit(decl.BuiltinType)
                as AST.BuiltinType;

            for (uint i = 0; i < decl.ItemsCount; ++i)
            {
                var item = decl.getItems(i);
                var _item = Visit(item) as AST.Enumeration.Item;
                _enum.AddItem(_item);
            }

            return _enum;
        }

        private AST.Enumeration.EnumModifiers VisitEnumModifiers(
            Enumeration.EnumModifiers modifiers)
        {
            return (AST.Enumeration.EnumModifiers) modifiers;
        }

        public override AST.Declaration VisitEnumerationItem(Enumeration.Item decl)
        {
            var _item = new AST.Enumeration.Item
            {
                Expression = decl.Expression,
                Value = decl.Value
            };
            VisitDeclaration(decl, _item);

            return _item;
        }

        public override AST.Declaration VisitVariable(Variable decl)
        {
            var _variable = new AST.Variable();
            VisitDeclaration(decl, _variable);
            _variable.Mangled = decl.Mangled;
            _variable.QualifiedType = typeConverter.VisitQualified(
                decl.QualifiedType);

            return _variable;
        }

        public override AST.Declaration VisitFriend(Friend decl)
        {
            var _friend = new AST.Friend();
            VisitDeclaration(decl, _friend);
            _friend.Declaration = Visit(decl.Declaration);

            return _friend;
        }

        public override AST.Declaration VisitField(Field decl)
        {
            var _field = new AST.Field();
            VisitDeclaration(decl, _field);

            _field.QualifiedType = typeConverter.VisitQualified(
                decl.QualifiedType);
            _field.Access = VisitAccessSpecifier(decl.Access);
            _field.Offset = decl.Offset;
            _field.Class = Visit(decl.Class) as AST.Class;
            _field.IsBitField = decl.IsBitField;
            _field.BitWidth = decl.BitWidth;

            return _field;
        }

        public override AST.Declaration VisitAccessSpecifier(AccessSpecifierDecl decl)
        {
            var _access = new AST.AccessSpecifierDecl();
            VisitDeclaration(decl, _access);

            return _access;
        }

        void VisitClass(Class @class, AST.Class _class)
        {
            VisitDeclaration(@class, _class);
            VisitDeclContext(@class, _class);

            for (uint i = 0; i < @class.BasesCount; ++i)
            {
                var @base = @class.getBases(i);
                var _base = VisitBaseClassSpecifier(@base);
                _class.Bases.Add(_base);
            }

            for (uint i = 0; i < @class.FieldsCount; ++i)
            {
                var field = @class.getFields(i);
                var _field = Visit(field) as AST.Field;
                _class.Fields.Add(_field);
            }

            for (uint i = 0; i < @class.MethodsCount; ++i)
            {
                var method = @class.getMethods(i);
                var _method = Visit(method) as AST.Method;
                _class.Methods.Add(_method);
            }

            for (uint i = 0; i < @class.SpecifiersCount; ++i)
            {
                var spec = @class.getSpecifiers(i);
                var _spec = Visit(spec) as AST.AccessSpecifierDecl;
                _class.Specifiers.Add(_spec);
            }

            _class.IsPOD = @class.IsPOD;
            _class.IsAbstract = @class.IsAbstract;
            _class.IsUnion = @class.IsUnion;
            _class.IsDynamic = @class.IsDynamic;
            _class.IsPolymorphic = @class.IsPolymorphic;
            _class.HasNonTrivialDefaultConstructor = @class.HasNonTrivialDefaultConstructor;
            _class.HasNonTrivialCopyConstructor = @class.HasNonTrivialCopyConstructor;
            _class.HasNonTrivialDestructor = @class.HasNonTrivialDestructor;
            _class.IsExternCContext = @class.IsExternCContext;

            if (@class.Layout != null)
                _class.Layout = VisitClassLayout(@class.Layout);
        }

        public override AST.Declaration VisitClass(Class @class)
        {
            var _class = new AST.Class();
            VisitClass(@class, _class);

            return _class;
        }

        AST.ClassLayout VisitClassLayout(ClassLayout layout)
        {
            var _layout = new AST.ClassLayout
            {
                ABI = VisitCppAbi(layout.ABI),
                Layout = VisitVTableLayout(layout.Layout),
                HasOwnVFPtr = layout.HasOwnVFPtr,
                VBPtrOffset = layout.VBPtrOffset,
                Alignment = layout.Alignment,
                Size = layout.Size,
                DataSize = layout.DataSize
            };

            for (uint i = 0; i < layout.VFTablesCount; ++i)
            {
                var vftableInfo = layout.getVFTables(i);
                var _vftableInfo = VisitVFTableInfo(vftableInfo);
                _layout.VFTables.Add(_vftableInfo);
            }

            return _layout;
        }

        AST.CppAbi VisitCppAbi(CppAbi abi)
        {
            switch (abi)
            {
                case CppAbi.Itanium:
                    return AST.CppAbi.Itanium;
                case CppAbi.Microsoft:
                    return AST.CppAbi.Microsoft;
                case CppAbi.ARM:
                    return AST.CppAbi.ARM;
                case CppAbi.iOS:
                    return AST.CppAbi.iOS;
                case CppAbi.iOS64:
                    return AST.CppAbi.iOS64;
                default:
                    throw new ArgumentOutOfRangeException("abi");
            }
        }

        AST.VFTableInfo VisitVFTableInfo(VFTableInfo vftableInfo)
        {
            var _vftableInfo = new AST.VFTableInfo
            {
                VBTableIndex = vftableInfo.VBTableIndex,
                VFPtrOffset = vftableInfo.VFPtrOffset,
                VFPtrFullOffset = vftableInfo.VFPtrFullOffset,
                Layout = VisitVTableLayout(vftableInfo.Layout)
            };

            NativeObjects.Add(vftableInfo);

            return _vftableInfo;
        }

        AST.VTableLayout VisitVTableLayout(VTableLayout layout)
        {
            var _layout = new AST.VTableLayout();

            for (uint i = 0; i < layout.ComponentsCount; ++i)
            {
                var component = layout.getComponents(i);
                var _component = VisitVTableComponent(component);
                _layout.Components.Add(_component);
            }

            return _layout;
        }

        AST.VTableComponent VisitVTableComponent(VTableComponent component)
        {
            var _component = new AST.VTableComponent
            {
                Kind = VisitVTableComponentKind(component.Kind),
                Offset = component.Offset,
                Declaration = Visit(component.Declaration)
            };

            NativeObjects.Add(component);

            return _component;
        }

        AST.VTableComponentKind VisitVTableComponentKind(VTableComponentKind kind)
        {
            switch (kind)
            {
                case VTableComponentKind.VCallOffset:
                    return AST.VTableComponentKind.VCallOffset;
                case VTableComponentKind.VBaseOffset:
                    return AST.VTableComponentKind.VBaseOffset;
                case VTableComponentKind.OffsetToTop:
                    return AST.VTableComponentKind.OffsetToTop;
                case VTableComponentKind.RTTI:
                    return AST.VTableComponentKind.RTTI;
                case VTableComponentKind.FunctionPointer:
                    return AST.VTableComponentKind.FunctionPointer;
                case VTableComponentKind.CompleteDtorPointer:
                    return AST.VTableComponentKind.CompleteDtorPointer;
                case VTableComponentKind.DeletingDtorPointer:
                    return AST.VTableComponentKind.DeletingDtorPointer;
                case VTableComponentKind.UnusedFunctionPointer:
                    return AST.VTableComponentKind.UnusedFunctionPointer;
                default:
                    throw new ArgumentOutOfRangeException("kind");
            }
        }

        public void VisitTemplate(Template template, AST.Template _template)
        {
            VisitDeclaration(template, _template);

            _template.TemplatedDecl = Visit(template.TemplatedDecl);

            for (uint i = 0; i < template.ParametersCount; ++i)
            {
                var param = template.getParameters(i);
                var _param = VisitTemplateParameter(param);
                _template.Parameters.Add(_param);
            }
        }

        public static AST.TemplateParameter VisitTemplateParameter(TemplateParameter param)
        {
            var _param = new AST.TemplateParameter();
            _param.Name = param.Name;
            _param.IsTypeParameter = param.IsTypeParameter;
            return _param;
        }

        public override AST.Declaration VisitClassTemplate(ClassTemplate decl)
        {
            var _decl = new AST.ClassTemplate();
            VisitTemplate(decl, _decl);
            for (uint i = 0; i < decl.SpecializationsCount; ++i)
            {
                var spec = decl.getSpecializations(i);
                var _spec = (AST.ClassTemplateSpecialization)Visit(spec);
                _decl.Specializations.Add(_spec);
            }
            return _decl;
        }

        public override AST.Declaration VisitClassTemplateSpecialization(
            ClassTemplateSpecialization decl)
        {
            var _decl = new AST.ClassTemplateSpecialization();
            VisitClassTemplateSpecialization(decl, _decl);
            return _decl;
        }

        private void VisitClassTemplateSpecialization(ClassTemplateSpecialization decl, AST.ClassTemplateSpecialization _decl)
        {
            VisitClass(decl, _decl);
            _decl.SpecializationKind = VisitSpecializationKind(decl.SpecializationKind);
            _decl.TemplatedDecl = (AST.ClassTemplate)Visit(decl.TemplatedDecl);
            for (uint i = 0; i < decl.ArgumentsCount; ++i)
            {
                var arg = decl.getArguments(i);
                var _arg = VisitTemplateArgument(arg);
                _decl.Arguments.Add(_arg);
            }
        }

        private AST.TemplateArgument VisitTemplateArgument(TemplateArgument arg)
        {
            var _arg = new AST.TemplateArgument();
            _arg.Kind = VisitTemplateArgumentKind(arg.Kind);
            _arg.Type = typeConverter.VisitQualified(arg.Type);
            _arg.Declaration = Visit(arg.Declaration);
            _arg.Integral = arg.Integral;
            NativeObjects.Add(arg);
            return _arg;
        }

        private AST.TemplateArgument.ArgumentKind VisitTemplateArgumentKind(TemplateArgument.ArgumentKind argumentKind)
        {
            switch (argumentKind)
            {
                case TemplateArgument.ArgumentKind.Declaration:
                    return AST.TemplateArgument.ArgumentKind.Declaration;
                case TemplateArgument.ArgumentKind.Expression:
                    return AST.TemplateArgument.ArgumentKind.Expression;
                case TemplateArgument.ArgumentKind.Integral:
                    return AST.TemplateArgument.ArgumentKind.Integral;
                case TemplateArgument.ArgumentKind.NullPtr:
                    return AST.TemplateArgument.ArgumentKind.NullPtr;
                case TemplateArgument.ArgumentKind.Pack:
                    return AST.TemplateArgument.ArgumentKind.Pack;
                case TemplateArgument.ArgumentKind.Template:
                    return AST.TemplateArgument.ArgumentKind.Template;
                case TemplateArgument.ArgumentKind.TemplateExpansion:
                    return AST.TemplateArgument.ArgumentKind.TemplateExpansion;
                case TemplateArgument.ArgumentKind.Type:
                    return AST.TemplateArgument.ArgumentKind.Type;
                default:
                    throw new NotImplementedException();
            }
        }

        private AST.TemplateSpecializationKind VisitSpecializationKind(TemplateSpecializationKind templateSpecializationKind)
        {
            switch (templateSpecializationKind)
            {
                case TemplateSpecializationKind.ExplicitInstantiationDeclaration:
                    return AST.TemplateSpecializationKind.ExplicitInstantiationDeclaration;
                case TemplateSpecializationKind.ExplicitInstantiationDefinition:
                    return AST.TemplateSpecializationKind.ExplicitInstantiationDefinition;
                case TemplateSpecializationKind.ExplicitSpecialization:
                    return AST.TemplateSpecializationKind.ExplicitSpecialization;
                case TemplateSpecializationKind.ImplicitInstantiation:
                    return AST.TemplateSpecializationKind.ImplicitInstantiation;
                case TemplateSpecializationKind.Undeclared:
                    return AST.TemplateSpecializationKind.Undeclared;
                default:
                    throw new NotImplementedException();
            }
        }

        public override AST.Declaration VisitClassTemplatePartialSpecialization(
            ClassTemplatePartialSpecialization decl)
        {
            var _decl = new AST.ClassTemplatePartialSpecialization();
            VisitClassTemplateSpecialization(decl, _decl);
            return _decl;
        }

        public override AST.Declaration VisitFunctionTemplate(FunctionTemplate decl)
        {
            var _decl = new AST.FunctionTemplate(Visit(decl.TemplatedDecl));
            VisitTemplate(decl, _decl);
            for (uint i = 0; i < decl.SpecializationsCount; ++i)
            {
                var _spec = VisitFunctionTemplateSpecialization(decl.getSpecializations(i));
                _decl.Specializations.Add(_spec);
            }
            return _decl;
        }

        private AST.FunctionTemplateSpecialization VisitFunctionTemplateSpecialization(FunctionTemplateSpecialization spec)
        {
            if (FunctionTemplateSpecializations.ContainsKey(spec.__Instance))
                return FunctionTemplateSpecializations[spec.__Instance];

            var _spec = new AST.FunctionTemplateSpecialization();
            _spec.Template = (AST.FunctionTemplate)Visit(spec.Template);
            _spec.SpecializedFunction = (AST.Function)Visit(spec.SpecializedFunction);
            _spec.SpecializationKind = VisitSpecializationKind(spec.SpecializationKind);
            for (uint i = 0; i < spec.ArgumentsCount; ++i)
            {
                var _arg = VisitTemplateArgument(spec.getArguments(i));
                _spec.Arguments.Add(_arg);
            }
            FunctionTemplateSpecializations.Add(spec.__Instance, _spec);
            NativeObjects.Add(spec);
            return _spec;
        }

        void VisitPreprocessedEntity(PreprocessedEntity entity, AST.PreprocessedEntity _entity)
        {
            if (PreprocessedEntities.ContainsKey(entity.__Instance))
            {
                _entity.MacroLocation = PreprocessedEntities[entity.__Instance].MacroLocation;
                return;
            }

            _entity.MacroLocation = VisitMacroLocation(entity.MacroLocation);
            PreprocessedEntities.Add(entity.__Instance, _entity);
            NativeObjects.Add(entity);
        }

        private AST.PreprocessedEntity VisitPreprocessedEntity(PreprocessedEntity entity)
        {
            switch (entity.Kind)
            {
                case DeclarationKind.MacroDefinition:
                    var macroDefinition = MacroDefinition.__CreateInstance(entity.__Instance);
                    return VisitMacroDefinition(macroDefinition);
                case DeclarationKind.MacroExpansion:
                    var macroExpansion = MacroExpansion.__CreateInstance(entity.__Instance);
                    return VisitMacroExpansion(macroExpansion);
                default:
                    throw new ArgumentOutOfRangeException("entity");
            }
        }

        private AST.MacroLocation VisitMacroLocation(MacroLocation location)
        {
            switch (location)
            {
                case MacroLocation.Unknown:
                    return AST.MacroLocation.Unknown;
                case MacroLocation.ClassHead:
                    return AST.MacroLocation.ClassHead;
                case MacroLocation.ClassBody:
                    return AST.MacroLocation.ClassBody;
                case MacroLocation.FunctionHead:
                    return AST.MacroLocation.FunctionHead;
                case MacroLocation.FunctionParameters:
                    return AST.MacroLocation.FunctionParameters;
                case MacroLocation.FunctionBody:
                    return AST.MacroLocation.FunctionBody;
                default:
                    throw new ArgumentOutOfRangeException("location");
            }
        }

        public AST.MacroDefinition VisitMacroDefinition(MacroDefinition macroDefinition)
        {
            var _macro = new AST.MacroDefinition();
            VisitPreprocessedEntity(macroDefinition, _macro);
            _macro.Name = macroDefinition.Name;
            _macro.Expression = macroDefinition.Expression;
            return _macro;
        }

        public AST.MacroExpansion VisitMacroExpansion(MacroExpansion macroExpansion)
        {
            var _macro = new AST.MacroExpansion();
            VisitPreprocessedEntity(macroExpansion, _macro);
            _macro.Name = macroExpansion.Name;
            _macro.Text = macroExpansion.Text;
            if (macroExpansion.Definition != null)
                _macro.Definition = VisitMacroDefinition(macroExpansion.Definition);
            return _macro;
        }
    }

    public unsafe class CommentConverter : CommentsVisitor<AST.Comment>
    {
        public override AST.Comment VisitFullComment(FullComment comment)
        {
            var fullComment = new AST.FullComment();
            for (uint i = 0; i < comment.BlocksCount; i++)
                fullComment.Blocks.Add((AST.BlockContentComment) Visit(comment.getBlocks(i)));
            return fullComment;
        }

        protected override AST.Comment VisitBlockCommandComment(BlockCommandComment comment)
        {
            var blockCommandComment = new AST.BlockCommandComment();
            VisitBlockCommandComment(blockCommandComment, comment);
            return blockCommandComment;
        }

        protected override AST.Comment VisitParamCommandComment(ParamCommandComment comment)
        {
            var paramCommandComment = new AST.ParamCommandComment();
            switch (comment.Direction)
            {
                case ParamCommandComment.PassDirection.In:
                    paramCommandComment.Direction = AST.ParamCommandComment.PassDirection.In;
                    break;
                case ParamCommandComment.PassDirection.Out:
                    paramCommandComment.Direction = AST.ParamCommandComment.PassDirection.Out;
                    break;
                case ParamCommandComment.PassDirection.InOut:
                    paramCommandComment.Direction = AST.ParamCommandComment.PassDirection.InOut;
                    break;
            }
            paramCommandComment.ParamIndex = comment.ParamIndex;
            return paramCommandComment;
        }

        protected override AST.Comment VisitTParamCommandComment(TParamCommandComment comment)
        {
            var paramCommandComment = new AST.TParamCommandComment();
            for (uint i = 0; i < comment.PositionCount; i++)
                paramCommandComment.Position.Add(comment.getPosition(i));
            VisitBlockCommandComment(paramCommandComment, comment);
            return paramCommandComment;
        }

        protected override AST.Comment VisitVerbatimBlockComment(VerbatimBlockComment comment)
        {
            var verbatimBlockComment = new AST.VerbatimBlockComment();
            for (uint i = 0; i < comment.LinesCount; i++)
                verbatimBlockComment.Lines.Add((AST.VerbatimBlockLineComment) Visit(comment.getLines(i)));
            VisitBlockCommandComment(verbatimBlockComment, comment);
            return verbatimBlockComment;
        }

        protected override AST.Comment VisitVerbatimLineComment(VerbatimLineComment comment)
        {
            var verbatimLineComment = new AST.VerbatimLineComment { Text = comment.Text };
            VisitBlockCommandComment(verbatimLineComment, comment);
            return verbatimLineComment;
        }

        protected override AST.Comment VisitParagraphComment(ParagraphComment comment)
        {
            var paragraphComment = new AST.ParagraphComment();
            for (uint i = 0; i < comment.ContentCount; i++)
                paragraphComment.Content.Add((AST.InlineContentComment) Visit(comment.getContent(i)));
            paragraphComment.IsWhitespace = comment.IsWhitespace;
            return paragraphComment;
        }

        protected override AST.Comment VisitHTMLStartTagComment(HTMLStartTagComment comment)
        {
            var htmlStartTagComment = new AST.HTMLStartTagComment();
            for (uint i = 0; i < comment.AttributesCount; i++)
            {
                var attribute = new AST.HTMLStartTagComment.Attribute();
                var _attribute = comment.getAttributes(i);
                attribute.Name = _attribute.Name;
                attribute.Value = _attribute.Value;
                htmlStartTagComment.Attributes.Add(attribute);
            }
            htmlStartTagComment.TagName = comment.TagName;
            return htmlStartTagComment;
        }

        protected override AST.Comment VisitHTMLEndTagComment(HTMLEndTagComment comment)
        {
            return new AST.HTMLEndTagComment { TagName = comment.TagName };
        }

        protected override AST.Comment VisitTextComment(TextComment comment)
        {
            return new AST.TextComment { Text = comment.Text };
        }

        protected override AST.Comment VisitInlineCommandComment(InlineCommandComment comment)
        {
            var inlineCommandComment = new AST.InlineCommandComment();
            for (uint i = 0; i < comment.ArgumentsCount; i++)
            {
                var argument = new AST.InlineCommandComment.Argument { Text = comment.getArguments(i).Text };
                inlineCommandComment.Arguments.Add(argument);
            }
            return inlineCommandComment;
        }

        protected override AST.Comment VisitVerbatimBlockLineComment(VerbatimBlockLineComment comment)
        {
            return new AST.VerbatimBlockLineComment { Text = comment.Text };
        }

        private static void VisitBlockCommandComment(AST.BlockCommandComment blockCommandComment, BlockCommandComment comment)
        {
            blockCommandComment.CommandId = comment.CommandId;
            for (uint i = 0; i < comment.ArgumentsCount; i++)
            {
                var argument = new AST.BlockCommandComment.Argument { Text = comment.getArguments(i).Text };
                blockCommandComment.Arguments.Add(argument);
            }
        }
    }

    #endregion
}
