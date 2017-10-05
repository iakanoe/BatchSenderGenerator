Imports System.IO
Imports System.Windows.Forms

Module Module1
    Public entrada As String
    Public salida As String
    Dim strPath As String = Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().CodeBase)
    Sub Main()
        Console.Title = "BatchSenderGenerator"
        Console.WriteLine(vbCrLf & vbCrLf & "BatchSenderGenerator encendido.")
        Threading.Thread.Sleep(2000)
        Dim formm As New form
        formm.selectfile()
        Console.WriteLine(vbCrLf & "Archivo de entrada """ & entrada & """ seleccionado.")
        Threading.Thread.Sleep(1000)
        formm.select2file()
        Console.WriteLine(vbCrLf & "Archivo de salida """ & salida & """ seleccionado.")
        Dim var As Boolean = False
        Do While var = False
            Console.Write(vbCrLf & "Desea empezar el proceso? [S/N] ")
            Dim respuesta = Console.ReadLine().ToUpper
            If respuesta = "N" Then
                End
            ElseIf respuesta = "S" Then
                var = True
            Else
                Console.WriteLine("""" & respuesta & """ no es una respuesta válida. Intente otra vez.")
                var = False
            End If
        Loop
        empezar()
        Threading.Thread.Sleep(2000)
        End
    End Sub
    Sub empezar()
        Console.WriteLine("Procesando...")
        Dim lineas As String() = File.ReadAllLines(entrada)
        Dim lineasnuevas As String() = {"@echo off", "echo Generando log en archivo ""%~0\log.txt""...", "cd " & Application.StartupPath()}
        For Each linea As String In lineas
            Dim datos As String = linea.Split(" "c)(1)
            Dim puerto As Integer = linea.Split(" "c)(0).Split(":"c)(1)
            Dim ipdestino As String = linea.Split(" "c)(0).Split(":"c)(0)
            Dim lineanueva As String
            lineanueva = "nping.exe --udp --unprivileged -c 1 -p " & puerto & " --data " & datos & " " & ipdestino & " >> log.txt"
            ReDim Preserve lineasnuevas(lineasnuevas.Length + 1)
            lineasnuevas(UBound(lineasnuevas) - 1) = lineanueva
            Randomize()
            Dim numero As Decimal = (Math.Floor((20 - 10 + 1) * Rnd()) + 10).ToString & "," & (Math.Floor((10 - 1 + 1) * Rnd()) + 1).ToString
            numero = numero * 60
            lineasnuevas(UBound(lineasnuevas)) = "choice /c YN /t " & CInt(numero).ToString & " /d Y >nul 2>nul"
        Next
        File.WriteAllLines(salida, lineasnuevas)
        Console.WriteLine("Archivo " & salida & " hecho satisfactoriamente.")
    End Sub
End Module
