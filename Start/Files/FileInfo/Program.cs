// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Reading and Writing data from and to files

// Make sure the example file exists
const string filename = "TestFile.txt";

// TODO 1: WriteAllText overwrites a file with the given content
if (!File.Exists(filename)) {
    File.WriteAllText(filename, "This is a text file. ");
}

// TODO 3: AppendAllText adds text to an existing file
File.AppendAllText(filename, "This text gets appended to the file. ");

// TODO 4: A FileStream can be opened and written to until closed
using (StreamWriter sw = File.AppendText(filename)) {
sw.WriteLine("Line 1");
sw.WriteLine("Line 2");
sw.WriteLine("Line 3");
}

if (!File.Exists(filename)) {
    using (StreamWriter sw = File.CreateText(filename)) {
        sw.WriteLine("This is a text file.");
    }
}

// TODO: Get some information about the file
Console.WriteLine("File creation time was: "+ File.GetCreationTime(filename));
Console.WriteLine("File last write time was: "+File.GetLastWriteTime(filename));
Console.WriteLine("File last access tme was: "+File.GetLastAccessTime(filename));

// TODO: We can also get general information using a FileInfo 
try{
    FileInfo fi = new FileInfo(filename);
    System.Console.WriteLine($"{fi.Length}");
}
catch (Exception e){
    Console.WriteLine($"Error: {e}");
}

// TODO: File information can also be manipulated
File.SetAttributes(filename,FileAttributes.ReadOnly);
Console.WriteLine(File.GetAttributes(filename));

DateTime dt = new DateTime(2024,6,10);
File.SetCreationTime(filename, dt);
Console.WriteLine(File.GetCreationTime(filename));