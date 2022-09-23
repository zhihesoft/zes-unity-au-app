
declare module 'csharp' {
    //keep type incompatibility / 此属性保持类型不兼容
    const __keep_incompatibility: unique symbol;
    namespace CSharp {
        interface $Ref<T> {
            value: T
        }
        namespace System {
            interface Array$1<T> extends System.Array {
                get_Item(index: number):T;
                set_Item(index: number, value: T):void;
            }
        }
        interface $Task<T> {}
        namespace Au {
            class App extends UnityEngine.MonoBehaviour
            {
                protected [__keep_incompatibility]: never;
                public static get loader(): Au.Loaders.Loader;
                public static get config(): Au.AppConfig;
                public static RestartJavascriptApp () : void
                public constructor ()
            }
            class AppConfig extends System.Object
            {
                protected [__keep_incompatibility]: never;
            }
            class Tags extends UnityEngine.MonoBehaviour
            {
                protected [__keep_incompatibility]: never;
                public items : System.Array$1<Au.Tag>
                public Get ($name: string) : UnityEngine.GameObject
                public constructor ()
            }
            class Tag extends System.Object
            {
                protected [__keep_incompatibility]: never;
            }
            class Utils extends System.Object
            {
                protected [__keep_incompatibility]: never;
                public static utf8WithoutBOM : System.Text.Encoding
                public static IsWebFile ($path: string) : boolean
                public static WaitAsyncOperation ($op: UnityEngine.AsyncOperation, $progress?: System.Action$1<number>) : System.Threading.Tasks.Task
                public static WaitUntil ($condition: System.Func$1<boolean>) : System.Threading.Tasks.Task
                public static Timestamp () : bigint
                public static DirEnsure ($dir: string) : System.IO.DirectoryInfo
                public static DirEnsure ($dir: System.IO.DirectoryInfo) : System.IO.DirectoryInfo
                public static DirCopy ($from: string, $to: string) : void
                public static DirCopy ($from: System.IO.DirectoryInfo, $to: System.IO.DirectoryInfo) : void
            }
        }
        namespace UnityEngine {
            /** MonoBehaviour is the base class from which every Unity script derives. */
            class MonoBehaviour extends UnityEngine.Behaviour
            {
                protected [__keep_incompatibility]: never;
            }
            /** Behaviours are Components that can be enabled or disabled. */
            class Behaviour extends UnityEngine.Component
            {
                protected [__keep_incompatibility]: never;
            }
            /** Base class for everything attached to GameObjects. */
            class Component extends UnityEngine.Object
            {
                protected [__keep_incompatibility]: never;
            }
            /** Base class for all objects Unity can reference. */
            class Object extends System.Object
            {
                protected [__keep_incompatibility]: never;
            }
            /** Base class for all entities in Unity Scenes. */
            class GameObject extends UnityEngine.Object
            {
                protected [__keep_incompatibility]: never;
            }
            /** Asynchronous operation coroutine. */
            class AsyncOperation extends UnityEngine.YieldInstruction
            {
                protected [__keep_incompatibility]: never;
            }
            /** Base class for all yield instructions. */
            class YieldInstruction extends System.Object
            {
                protected [__keep_incompatibility]: never;
            }
        }
        namespace System {
            class Object
            {
                protected [__keep_incompatibility]: never;
            }
            class Void extends System.ValueType
            {
                protected [__keep_incompatibility]: never;
            }
            class ValueType extends System.Object
            {
                protected [__keep_incompatibility]: never;
            }
            class Array extends System.Object implements System.Collections.IStructuralComparable, System.Collections.IStructuralEquatable, System.ICloneable, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
            {
                protected [__keep_incompatibility]: never;
            }
            interface ICloneable
            {
            }
            class String extends System.Object implements System.ICloneable, System.IComparable, System.IComparable$1<string>, System.IConvertible, System.Collections.Generic.IEnumerable$1<number>, System.Collections.IEnumerable, System.IEquatable$1<string>
            {
                protected [__keep_incompatibility]: never;
            }
            interface IComparable
            {
            }
            interface IComparable$1<T>
            {
            }
            interface IConvertible
            {
            }
            class Char extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
            {
                protected [__keep_incompatibility]: never;
            }
            interface IEquatable$1<T>
            {
            }
            class Boolean extends System.ValueType implements System.IComparable, System.IComparable$1<boolean>, System.IConvertible, System.IEquatable$1<boolean>
            {
                protected [__keep_incompatibility]: never;
            }
            interface IAsyncResult
            {
            }
            interface IDisposable
            {
            }
            class Single extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
            {
                protected [__keep_incompatibility]: never;
            }
            interface IFormattable
            {
            }
            interface ISpanFormattable
            {
            }
            interface Action$1<T>
            { 
            (obj: T) : void; 
            Invoke?: (obj: T) => void;
            }
            interface MulticastDelegate
            { 
            (...args:any[]) : any; 
            Invoke?: (...args:any[]) => any;
            }
            var MulticastDelegate: { new (func: (...args:any[]) => any): MulticastDelegate; }
            class Delegate extends System.Object implements System.Runtime.Serialization.ISerializable, System.ICloneable
            {
                protected [__keep_incompatibility]: never;
            }
            interface Func$1<TResult>
            { 
            () : TResult; 
            Invoke?: () => TResult;
            }
            class Int64 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>
            {
                protected [__keep_incompatibility]: never;
            }
            class MarshalByRefObject extends System.Object
            {
                protected [__keep_incompatibility]: never;
            }
        }
        namespace Au.Loaders {
            class Loader extends System.Object
            {
                protected [__keep_incompatibility]: never;
            }
        }
        namespace System.Collections {
            interface IStructuralComparable
            {
            }
            interface IStructuralEquatable
            {
            }
            interface ICollection extends System.Collections.IEnumerable
            {
            }
            interface IEnumerable
            {
            }
            interface IList extends System.Collections.ICollection, System.Collections.IEnumerable
            {
            }
        }
        namespace System.Collections.Generic {
            interface IReadOnlyList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<T>
            {
            }
            interface IEnumerable$1<T> extends System.Collections.IEnumerable
            {
            }
            interface IReadOnlyCollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
            {
            }
            interface IList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.ICollection$1<T>
            {
            }
            interface ICollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
            {
            }
        }
        namespace System.Text {
            class Encoding extends System.Object implements System.ICloneable
            {
                protected [__keep_incompatibility]: never;
            }
        }
        namespace System.Threading.Tasks {
            class Task extends System.Object implements System.IAsyncResult, System.Threading.IThreadPoolWorkItem, System.IDisposable
            {
                protected [__keep_incompatibility]: never;
            }
        }
        namespace System.Threading {
            interface IThreadPoolWorkItem
            {
            }
        }
        namespace System.Runtime.Serialization {
            interface ISerializable
            {
            }
        }
        namespace System.IO {
            class DirectoryInfo extends System.IO.FileSystemInfo implements System.Runtime.Serialization.ISerializable
            {
                protected [__keep_incompatibility]: never;
            }
            class FileSystemInfo extends System.MarshalByRefObject implements System.Runtime.Serialization.ISerializable
            {
                protected [__keep_incompatibility]: never;
            }
        }
    }
    export = CSharp;
}
