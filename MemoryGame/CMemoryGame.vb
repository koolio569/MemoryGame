Public Class CMemoryGame

    Private _difficulty As Integer

    Private _possibleWords As List(Of String)

    Private _grid As List(Of String)

    Private _added As String

    Private _removed As String

    Sub New(ByVal difficulty As Integer, ByVal filePath As String)

        _difficulty = difficulty

        Dim wordlist_file As New System.IO.StreamReader(filePath, True)

        While Not wordlist_file.EndOfStream

            _possibleWords.Add(wordlist_file.ReadLine)

        End While

        wordlist_file.Close()

        _possibleWords = _possibleWords.OrderBy(Function() Rnd()).ToList

        For i = 0 To (_difficulty ^ 2) - 1

            _grid.Add(_possibleWords(i))

        Next

    End Sub

    Sub PlayGame()

        Draw()

        SwapWords()

        Draw()

        Console.WriteLine("What word was added?")
        CheckAnswer(_added)

        Console.WriteLine("What word was removed?")
        CheckAnswer(_removed)

        Console.WriteLine("winner!!!")
        Console.ReadKey()

    End Sub

    Sub Draw()

        Console.Clear()

        For i = 1 To _grid.Count

            If i Mod _difficulty = 0 Then

                Console.WriteLine()

                Console.Write(_grid(i - 1))

            Else

                Console.Write(_grid(i - 1))

            End If

        Next

        Threading.Thread.Sleep(30000)

    End Sub

    Sub SwapWords()

        Dim RandomInt As Integer

        RandomInt = Math.Floor(Rnd() * (_grid.Count - 1))

        _removed = _grid(RandomInt)

        _grid.RemoveAt(RandomInt)

        RandomInt = Math.Floor(Rnd() * (_possibleWords.Count - 1))

        _added = _possibleWords(RandomInt)

        _grid.Add(_possibleWords(RandomInt))

    End Sub

    Sub CheckAnswer(ByVal answer As String)

        Dim input As String = ""

        Do Until input = answer

            Console.Clear()

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
