Imports System

Module Program

    Sub Main()

        Dim choice As String = ""

        Console.WriteLine("1. easy")

        Console.WriteLine("2. hard")

        choice = Console.ReadLine

        If choice = "1" Then

            Dim currentGame As New CMemoryGame(3, "words.txt")

            currentGame.PlayGame()

        ElseIf choice = "2" Then

            Dim currentGame As New CMemoryGame(4, "words.txt")

            currentGame.PlayGame()

        End If


    End Sub

End Module
