# Kogane Debug Log Method Chaining Extension Methods

Debug.Log をメソッドチェーンで書けるようにする拡張メソッド

## 使用例

```csharp
public string GetDisplayName()
{
    var id   = 25;
    var name = "ピカチュウ";

    return $"{id}: {name}";
}
```

たとえば上記のような関数で戻り値の値をログ出力したい場合、

```csharp
public string GetDisplayName()
{
    var id   = 25;
    var name = "ピカチュウ";

    var result = $"{id}: {name}";
    
    Debug.Log( result );

    return result;
}
```

通常であればこのようにローカル変数を定義する必要がありますが

```csharp
public string GetDisplayName()
{
    var id   = 25;
    var name = "ピカチュウ";

    return $"{id}: {name}".DebugLog();
}
```

拡張メソッドを使えばローカル変数の定義が不要になります

```csharp
public string GetDisplayName()
{
    var id   = 25;
    var name = "ピカチュウ";

    return $"{id}: {name}".DebugLog( x => $"表示名:{x}" );
}
```

ログ出力のフォーマットを引数で指定することも可能です