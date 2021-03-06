# HelperToolbox


## Description
This library is a collection of useful methods (mostly extension methods).
In the documentation below you find a description and examples for all methods.

Package: <href>https://www.nuget.org/packages/HelperToolbox/</href>

Many ideas from this thread on stackoverflow:
<href>https://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow</href>



## New in version 1.0.2
```csharp
// Methods
bool IsValidMail(this string mail)
Grid GetGrid(int rows, int columns, string name = "")
IsFileLocked(this string path)
IsFileNotLocked(this string path)
bool AllLettersDigitsOrUnderScores(this string value)
bool ToBool(this int value)

// Overloads
int ToInt(this bool value)
int Seconds(this double milliseconds)
int Minutes(this double milliseconds)
```


## Methods

## DateTime

### int Seconds(this int milliseconds) and int Minutes(this int milliseconds)
#### Description
These two methods are made to use them with methods like Task.Delay() and convert milliseconds in seconds or minutes. 
This makes it more readable.

#### Overloads
```csharp
int Seconds(this double milliseconds) 
int Minutes(this double milliseconds)
```


#### Example
```csharp
Task.Delay(5.Minutes()).Wait();
Task.Delay(38.Seconds()).Wait();
```



## DataTables

### static DataTable CreateDataTable(this IEnumerable<string> columns, string name = "")
#### Description
Creates an empty DataTable with columns.

#### Example
```csharp
string name = "TestTable";
string[] columns = { "ID", "Name", "Value" };
DataTable dt = HelperToolBox.CreateDataTable(name, columns);
```


### DataTable ToDataTable<T>(this IEnumerable<T> items, string name = "")

#### Description
This method searches for all properties of a class of type T and creates a DataTable with a column for each property. 
Than it adds a DataRow for each item in items to the DataTable.

#### Example
```csharp
List<MyClass> list = new();
list.Add(new() { ID = 1, Name = "one" });
list.Add(new() { ID = 2, Name = "two" });
list.Add(new() { ID = 3, Name = "three" });

DataTable dt = list.ToDataTable("TestTable");
```


## Files

### bool FileNotExists(this string path)
#### Description
Inverted version of ```csharp File.Exists()```.

#### Example
```csharp
string path = "SomePath";
if (path.FileNotExists())
{
    return;
}
```


### void DeleteFileIfExists(this string path)
#### Description
Checks if a file exists and delete it if it exists.

#### Example
```csharp
string path = "SomePath";
path.DeleteFileIfExists();
```


### bool DirectoryNotExists(this string path)
#### Description
Inverted version of ```csharp Directory.Exists()```.

#### Example
```csharp
string path = "SomePath";
if (path.DirectoryNotExists())
{
    return;
}
```


### void CreateDirectoryIfNotExists(this string path)
#### Description
Checks if a directory exists and creates it, if not.

#### Example
```csharp
string path = "SomePath";
path.CreateDirectoryIfNotExists();
```


### string GetFileName(this string path)
#### Description
Returns only the filename of a path.

#### Example
```csharp
string path = "SomePath";
string fileName = path.GetFileName();
```

    
    

### string GetDirectoryName(this string path)
#### Description
Returns only the directoryname of a path.

#### Example
```csharp
string path = "SomePath";
string fileName = path.GetDirectoryName();
```

    
    
    

### bool IsFileLocked(this string path) and bool IsFileNotLocked(this string path)
#### Description
Checks if a file is in use by an other process (or not).
   
#### Overloads
```csharp
public static bool IsFileLocked(this FileInfo file)
public static bool IsFileNotLocked(this FileInfo file)
```    

#### Example
```csharp
string path = "SomePath";
Console.WriteLine(path.IsFileLocked());
```
    
    
    
    


## Lists

### IEnumerable<(int, T)> Enumerate<T>(this IEnumerable<T> input, int start = 0, int interval = 1)
#### Description
This method is made to use it in a foreach loop. It returns the items of input combined with an index as tuple.
You can define the start index and an interval.

#### Overloads
```csharp IEnumerable<(double, T)> Enumerate<T>(this IEnumerable<T> input, double start = 0, double interval = 1)```

#### Example
```csharp
string[] list = { "one", "two", "three"};
foreach ((int i, string s) in list.Enumerate(0))
{
    Console.WriteLine($"{i} - {s}");
}

//Output:
//0 - one
//1 - two
//2 - three
```



### IEnumerable<(T, F)> Cross<T, F>(this IEnumerable<T> input1, IEnumerable<F> input2)
#### Description
This method is made to use it in a foreach loop. It returns every possible combination of items from the inputs as tuple.

#### Example
```csharp
string[] list = { "one", "two", "three"};
int[] list2 = { 1, 2, 3 };
foreach ((int i, string s) in list2.Cross(list))
{
    Console.WriteLine($"{i} - {s}");
}

// Output:
// 1 - one
// 1 - two
// 1 - three
// 2 - one
// 2 - two
// 2 - three
// 3 - one
// 3 - two
// 3 - three
```



### ObservableCollection<T> AddRange<T>(this ObservableCollection<T> list, IEnumerable<T> input)
#### Description
The AddRange function for ObserableCollections. Adds all items of an IEnumerable to an ObservableCollection.

#### Example
```csharp
ObservableCollection<string> list = new() { "one", "two", "three"};
ObservableCollection<string> list2 = new() { "four", "five", "six" };

list = list.AddRange(list2);

foreach (string s in list)
{
    Console.WriteLine(s);
}

// Output:
// one
// two
// three
// four
// five
// six
```



### IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> input)
#### Description
Returns an empty list if the input is null, else it returns the input.

#### Example
```csharp
void Method(List<string> list)
{
    list = list.EmptyIfNull().ToList();
}

// ...

Method(null);
```



### List<T> Foreach<T>(this IEnumerable<T> source, Func<T, T> action)
#### Description
Performs an action on each item of the source.

#### Overloads
```csharp ObservableCollection<T> Foreach<T>(this ObservableCollection<T> source, Func<T, T> action)```

#### Example
```csharp
List<string> list = new(){ "one", "two", "three"};

list = list.Foreach((x) => x += "123456").ToList();

foreach (string s in list)
{
    Console.WriteLine(s);
}

// Output:
// one123456
// two123456
// three123456
```




### T[] RemoveAt<T>(this T[] input, int index)
#### Description
Removes an item from an array by index.

#### Example
```csharp
char[] chars = { 'a', 'b', 'c' };

chars = chars.RemoveAt(1);

foreach (char c in chars)
{
    Console.WriteLine(c);
}

// Output:
// a
// c
```
    
    
    
    
    
## Mails
    
### bool IsValidMail(this string mail)
#### Description
Checks if a string is a valid E-mail address.

#### Example
```csharp
Console.WriteLine("".IsValidMail());
Console.WriteLine("t".IsValidMail());
Console.WriteLine("test".IsValidMail());
Console.WriteLine("test@test".IsValidMail());
Console.WriteLine("test@test.com".IsValidMail());
Console.WriteLine("test@test.co.uk".IsValidMail());
Console.WriteLine("te-st@test.co.uk".IsValidMail());
Console.WriteLine("te--st@test.co.uk".IsValidMail());
Console.WriteLine(".test@test.co.uk".IsValidMail());
Console.WriteLine("te@st@test.co.uk".IsValidMail());

// Output: 
// False
// False
// False
// False
// True
// True
// True
// False
// False
// False
```




## Numbers

### bool IsInt(this string value, bool defaultValue = false)
#### Description
Checks if a string is a valid Int32.

#### Example
```csharp
Console.WriteLine("5".IsInt());
Console.WriteLine("-5".IsInt());
Console.WriteLine("j".IsInt());

// Output:
// True
// True
// False
```




### bool IsPositivInt(this string value, bool defaultValue = false)
#### Description
Checks if a string is a valid Int32 >= 0.

#### Example
```csharp
Console.WriteLine("5".IsPositivInt());
Console.WriteLine("-5".IsPositivInt());
Console.WriteLine("j".IsPositivInt());

// Output:
// True
// False
// False
```




### bool IsNegativInt(this string value, bool defaultValue = false)
#### Description
Checks if a string is a valid Int32 < 0.

#### Example
```csharp
Console.WriteLine("5".IsNegativInt());
Console.WriteLine("-5".IsNegativInt());
Console.WriteLine("j".IsNegativInt());

// Output:
// False
// True
// False
```




### bool IsDouble(this string value, bool defaultValue = false)
#### Description
Checks if a string is a valid double.

#### Example
```csharp
Console.WriteLine("5.8".IsDouble());
Console.WriteLine("-5".IsDouble());
Console.WriteLine("j".IsDouble());

// Output:
// True
// True
// False
```




### bool IsPositivDouble(this string value, bool defaultValue = false)
#### Description
Checks if a string is a valid double >= 0.

#### Example
```csharp
Console.WriteLine("5.8".IsPositivDouble());
Console.WriteLine("-5".IsPositivDouble());
Console.WriteLine("j".IsPositivDouble());

// Output:
// True
// False
// False
```




### bool IsNegativDouble(this string value, bool defaultValue = false)
#### Description
Checks if a string is a valid double < 0.

#### Example
```csharp
Console.WriteLine("5.8".IsNegativDouble());
Console.WriteLine("-5".IsNegativDouble());
Console.WriteLine("j".IsNegativDouble());

// Output:
// False
// True
// False
```




### int ToInt(this string value, int defaultValue = 0)
#### Description
Converts a string to an int if possible or returns the default value.

#### Example
```csharp
int x = "5".ToInt();
```




### ToInt(this bool value)
#### Description
Converts a bool to an int. 'true' is 1, 'false' is 0.

#### Example
```csharp
int x = true.ToInt();
```




### ToBool(this int value)
#### Description
Converts a number to a bool. Everything bigger than 0 is 'True', everything else is 'False'.

#### Overloads
```csharp
ToBool(this double value)
```
                                         
#### Example
```csharp
int x = true.ToInt();
```




### ToDouble(this string value, double defaultValue = 0)
#### Description
Converts a string to an double if possible or returns the default value.

#### Example
```csharp
double x = "5.8".ToDouble();
```




## Strings


### bool IsAllLetters(this string value, bool defaultValue = false)
#### Description
Checks if all chars of a string are letters.

#### Example
```csharp
string s1 = "abc";
string s2 = "abc ";
string s3 = "123";

Console.WriteLine(s1.IsAllLetters());
Console.WriteLine(s2.IsAllLetters());
Console.WriteLine(s3.IsAllLetters());

// Output:
// True
// False
// False
```




### bool IsAllLettersOrWhiteSpace(this string value, bool defaultValue = false)
#### Description
Checks if all chars of a string are letters or white space.

#### Example
```csharp
string s1 = "abc";
string s2 = "abc ";
string s3 = "123";

Console.WriteLine(s1.IsAllLettersOrWhiteSpace());
Console.WriteLine(s2.IsAllLettersOrWhiteSpace());
Console.WriteLine(s3.IsAllLettersOrWhiteSpace());

// Output:
// True
// True
// False
```
                                         
                  
                                         
                                         

### bool AllLettersDigitsOrUnderScores(this string value)
#### Description
Checks if all chars of a string are letters, digits or underscores.

#### Example
```csharp
string s = "Helloworld";
string s2 = "Hello world!";
Console.WriteLine(s.AllLettersDigitsOrUnderScores());
Console.WriteLine(s2.AllLettersDigitsOrUnderScores());
                                         
// Output:
// True
// False
```                                         
                                         




### string ToTitleCase(this string text)
#### Description
Converts a string depending on ```csharp Thread.CurrentThread.CurrentCulture```.

#### Example
```csharp
string s = "some test words.";
Console.WriteLine(s.ToTitleCase());

// Output:
// Some Test Words.
```




### string ToCsv<T>(this IEnumerable<T> input, string seperator = ",")
#### Description
Adds all elements of list or DataRow to a string (one line). If you run it on a DataTable it returns a string with a line for each DataRow.

#### Overloads
```csharp 
public static string ToCsv(this DataTable input, string seperator = ",")
public static string ToCsv(this DataRow input, string seperator = ",")
```

#### Example
```csharp
string[] array = { "a", "b", "c" };
Console.WriteLine(array.ToCsv(", "));

// Output:
// a, b, c


DataTable dt = array.CreateDataTable();

DataRow row = dt.NewRow();
row["a"] = "1";
row["b"] = "2";
row["c"] = "3";
dt.Rows.Add(row);

row = dt.NewRow();
row["a"] = "4";
row["b"] = "5";
row["c"] = "6";
dt.Rows.Add(row);

Console.WriteLine(dt.ToCsv(", "));

// 1, 2, 3
// 4, 5, 6
```






### string SplitAndGetLast(string input, char splitter)
#### Description
Returns a part of the input string behind the last usage of the char splitter.

#### Example
```csharp
string s = "3-7-4-9";
Console.WriteLine(s.SplitAndGetLast('-'));

// Output:
// 9
```




## UI

### void MakeVisible(this UIElement element)
#### Description
Make a WPF UIElement visible.

#### Example
```csharp
textBox.MakeVisible();
```




### void MakeCollapsed(this UIElement element)
#### Description
Collapse a WPF UIElement.

#### Example
```csharp
textBox.MakeCollapsed();
```
    



### Grid GetGrid(int rows, int columns, string name = "")
#### Description
Creates an emty WPF-Grid with rows and columns. All Width and Height properties of are set to 'auto'.

#### Example
```csharp
Grid grid = HelperToolbox.UI.GetGrid(5, 5, "MainGrid");
```




## Other

### string ToJson<T>(this T instance)
#### Description
Converts an object to json. Returns an empty string if the input is null.

#### Example
```csharp
TestClass test = new() { ID = 1, Name = "n" };
Console.WriteLine(test.ToJson());

// Output:
// {"ID":1,"Name":"n"}
```




### bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
#### Description
Checks if a value is between two other values. Can be used for numbers and DateTimes.

#### Example
```csharp
Console.WriteLine(5.Between(2, 8));
Console.WriteLine(5.Between(6, 8));

// Output:
// True
// False
```




### T With<T>(this T obj, Action<T> act)
#### Description
Performs an action on an object. useful to create a copy of an object with some values changed.

#### Example
```csharp
TestClass item1 = new() { ID = 1, Name = "n", Description = "des" };
TestClass item2;

item2 = new TestClass(item1).With(x => {
        x.ID = 123;
        x.Description = "somthing";
    });

Console.WriteLine($"{item1.ID} {item1.Name} {item1.Description}");
Console.WriteLine($"{item2.ID} {item2.Name} {item2.Description}");

// Output:
// 1 n des
// 123 n somthing
```




### bool PropertiesEqauls<T>(this T item1, T item2)
#### Description
Checks if the values of all properties of an object are equal.

#### Example
```csharp
TestClass item1 = new() { ID = 1, Name = "n", Description = "des" };
TestClass item2 = new() { ID = 1, Name = "n", Description = "des" };

Console.WriteLine(item1 == item2);
Console.WriteLine(item1.Equals(item2));
Console.WriteLine(item1.PropertiesEqauls(item2));

// Output:
// False
// False
// True
```




### T DeepCopy<T>(this T item)
#### Description
Creates a copy of an object by serializing it to json an deserializing it back. This makes shure there are no references between the new and the old object. 
Don't work for every object

#### Example
```csharp
TestClass item1 = new() { ID = 1, Name = "n", Description = "des" };
TestClass item2 = item1.DeepCopy();

Console.WriteLine(item1 == item2);
Console.WriteLine(item1.PropertiesEqauls(item2));

// Output:
// False
// True
```




## Used packages
Newtonsoft.Json <href>https://www.nuget.org/packages/Newtonsoft.Json/</href>
