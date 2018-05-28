Public Class CMemoryGame

    Private ReadOnly _difficulty As Integer

    Private _possibleWords As List(Of String)

    Private _grid As List(Of String)

    Private _added As String

    Private _removed As String

    Sub New(ByVal difficulty As Integer, ByVal filePath As String)

        _difficulty = difficulty

        _possibleWords = New List(Of String)

        Dim wordlist_file As New System.IO.StreamReader(filePath, True)

        While Not wordlist_file.EndOfStream

            _possibleWords.Add(wordlist_file.ReadLine)

        End While

        wordlist_file.Close()

        _possibleWords = _possibleWords.OrderBy(Function() New Random().NextDouble()).ToList

        _grid = New List(Of String)

        For i = 0 To (_difficulty ^ 2) - 1

            _grid.Add(_possibleWords(i))

        Next

    End Sub

    Sub PlayGame()

        Draw()

        SwapWords()

        Draw()

        CheckAnswer(_added, "What word was added?")

        CheckAnswer(_removed, "What word was removed?")

        Console.Clear()

        Console.WriteLine("winner!!!")

        Console.ReadKey()

    End Sub

    Sub Draw()

        Console.Clear()

        For i = 1 To _grid.Count

            If i Mod _difficulty = 0 Then

                Console.Write(_grid(i - 1) & " ")

                Console.WriteLine()

            Else

                Console.Write(_grid(i - 1) & " ")

            End If

        Next

        'Threading.Thread.Sleep(30000)

        Console.ReadKey()

    End Sub

    Sub SwapWords()

        Dim RandomInt As Integer

        RandomInt = Math.Floor(New Random().NextDouble * (_grid.Count - 1))

        _removed = _grid(RandomInt)

        _grid.RemoveAt(RandomInt)

        RandomInt = Math.Floor(New Random().NextDouble() * (_possibleWords.Count - 1))

        _added = _possibleWords(RandomInt)

        _grid.Add(_possibleWords(RandomInt))

    End Sub

    Sub CheckAnswer(ByVal answer As String, ByVal title As String)

        Dim input As String = ""

        Do Until input = answer

            Console.Clear()

            Console.WriteLine(title)

            Console.WriteLine("Input answer")

            input = Console.ReadLine

            If input = answer Then

                Console.WriteLine("correct")

                Console.ReadKey()

            Else

                Console.WriteLine("incorrect")

                Console.ReadKey()

            End If

        Loop

    End Sub

End Class
