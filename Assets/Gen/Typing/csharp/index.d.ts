
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
        namespace UnityEngine.UI {
            class Image extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.ICanvasRaycastFilter, UnityEngine.UI.ICanvasElement, UnityEngine.UI.ILayoutElement, UnityEngine.ISerializationCallbackReceiver, UnityEngine.UI.IClippable
            {
                protected [__keep_incompatibility]: never;
                public get sprite(): UnityEngine.Sprite;
                public set sprite(value: UnityEngine.Sprite);
                public get overrideSprite(): UnityEngine.Sprite;
                public set overrideSprite(value: UnityEngine.Sprite);
                public get type(): UnityEngine.UI.Image.Type;
                public set type(value: UnityEngine.UI.Image.Type);
                public get preserveAspect(): boolean;
                public set preserveAspect(value: boolean);
                public get fillCenter(): boolean;
                public set fillCenter(value: boolean);
                public get fillMethod(): UnityEngine.UI.Image.FillMethod;
                public set fillMethod(value: UnityEngine.UI.Image.FillMethod);
                public get fillAmount(): number;
                public set fillAmount(value: number);
                public get fillClockwise(): boolean;
                public set fillClockwise(value: boolean);
                public get fillOrigin(): number;
                public set fillOrigin(value: number);
                public get alphaHitTestMinimumThreshold(): number;
                public set alphaHitTestMinimumThreshold(value: number);
                public get useSpriteMesh(): boolean;
                public set useSpriteMesh(value: boolean);
                public static get defaultETC1GraphicMaterial(): UnityEngine.Material;
                public get mainTexture(): UnityEngine.Texture;
                public get hasBorder(): boolean;
                public get pixelsPerUnitMultiplier(): number;
                public set pixelsPerUnitMultiplier(value: number);
                public get pixelsPerUnit(): number;
                public get material(): UnityEngine.Material;
                public set material(value: UnityEngine.Material);
                public get minWidth(): number;
                public get preferredWidth(): number;
                public get flexibleWidth(): number;
                public get minHeight(): number;
                public get preferredHeight(): number;
                public get flexibleHeight(): number;
                public get layoutPriority(): number;
                public DisableSpriteOptimizations () : void
                public OnBeforeSerialize () : void
                public OnAfterDeserialize () : void
                public CalculateLayoutInputHorizontal () : void
                public CalculateLayoutInputVertical () : void
                public IsRaycastLocationValid ($screenPoint: UnityEngine.Vector2, $eventCamera: UnityEngine.Camera) : boolean
            }
            class MaskableGraphic extends UnityEngine.UI.Graphic implements UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.UI.IClippable
            {
                protected [__keep_incompatibility]: never;
            }
            class Graphic extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.UI.ICanvasElement
            {
                protected [__keep_incompatibility]: never;
            }
            interface ICanvasElement
            {
            }
            interface IMaterialModifier
            {
            }
            interface IMaskable
            {
            }
            interface IClippable
            {
            }
            interface ILayoutElement
            {
            }
        }
        namespace UnityEngine.EventSystems {
            class UIBehaviour extends UnityEngine.MonoBehaviour
            {
                protected [__keep_incompatibility]: never;
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
            interface ICanvasRaycastFilter
            {
            }
            interface ISerializationCallbackReceiver
            {
            }
            /** Represents a Sprite object for use in 2D gameplay. */
            class Sprite extends UnityEngine.Object
            {
                protected [__keep_incompatibility]: never;
            }
            /** The material class. */
            class Material extends UnityEngine.Object
            {
                protected [__keep_incompatibility]: never;
            }
            /** Base class for Texture handling. */
            class Texture extends UnityEngine.Object
            {
                protected [__keep_incompatibility]: never;
            }
            /** Representation of 2D vectors and points. */
            class Vector2 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Vector2>
            {
                protected [__keep_incompatibility]: never;
            }
            /** A Camera is a device through which the player views the world. */
            class Camera extends UnityEngine.Behaviour
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
            class Enum extends System.ValueType implements System.IFormattable, System.IComparable, System.IConvertible
            {
                protected [__keep_incompatibility]: never;
            }
            interface IFormattable
            {
            }
            interface IComparable
            {
            }
            interface IConvertible
            {
            }
            class Boolean extends System.ValueType implements System.IComparable, System.IComparable$1<boolean>, System.IConvertible, System.IEquatable$1<boolean>
            {
                protected [__keep_incompatibility]: never;
            }
            interface IComparable$1<T>
            {
            }
            interface IEquatable$1<T>
            {
            }
            class Single extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
            {
                protected [__keep_incompatibility]: never;
            }
            interface ISpanFormattable
            {
            }
            class Int32 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
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
            class Char extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
            {
                protected [__keep_incompatibility]: never;
            }
            interface IAsyncResult
            {
            }
            interface IDisposable
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
        namespace UnityEngine.UI.Image {
            enum Type
            { Simple = 0, Sliced = 1, Tiled = 2, Filled = 3 }
            enum FillMethod
            { Horizontal = 0, Vertical = 1, Radial90 = 2, Radial180 = 3, Radial360 = 4 }
        }
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
