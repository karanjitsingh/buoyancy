﻿
Public Class Form1

    Dim Top_Margin As Integer = 2
    Dim Left_Margin As Integer = 2
    Dim Mid_Margin As Integer = 1
    Dim box_size As Integer = 100
    Dim Preceed_Margin As Integer = 1
    Public Table(8, 8) As String

#Region "Code"

#Region "Interface"

    Private Sub CreateBoard()
        'Board Size
        Dim _x As Integer, _y As Integer
        _x = 9 * (box_size + Mid_Margin) - Mid_Margin
        _x += 2 * Left_Margin
        _x += 2 * Preceed_Margin

        _y = 9 * (box_size + Mid_Margin) - Mid_Margin
        _y += 2 * Top_Margin
        _y += 2 * Preceed_Margin

        Board.Size = New Drawing.Point(_x, _y)


        Dim x As Integer, y As Integer

        'Column-wise numbering
        For y = 0 To 8

            If y = 3 Or y = 6 Then                      'Space between
                Top_Margin += Preceed_Margin            '   the
            ElseIf y = 0 Then                           '       big boxes
                Top_Margin = 2
            End If

            For x = 0 To 8

                If x = 3 Or x = 6 Then                      'Space between
                    Left_Margin += Preceed_Margin           '   the
                ElseIf x = 0 Then                           '       big boxes
                    Left_Margin = 2
                End If

                Dim txt As New Label

                With txt
                    .Font = Dummy.Font
                    .BorderStyle = BorderStyle.None
                    .BackColor = Color.White
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Tag = (y * 9 + x)
                    .Size = New Drawing.Point(box_size, box_size)
                    .Cursor = Cursors.Hand
                    .Location = New Drawing.Point(Left_Margin + (box_size * x) + (Mid_Margin * x), Top_Margin + (box_size * y) + (Mid_Margin * y))
                End With

                AddHandler txt.Click, AddressOf Box_Click
                Board.Controls.Add(txt)
            Next
        Next
    End Sub

    Private Sub PrintBoard()
        For Each digit As Label In Board.Controls
            Dim x As Integer, y As Integer
            x = Int(digit.Tag) Mod 9
            y = Int(digit.Tag / 9)  'conversion to int to truncate the decimal
            digit.Text = Table(x, y)
        Next
    End Sub

    Private Sub GetBoard()
        For Each digit As Label In Board.Controls
            Dim x As Integer, y As Integer
            x = Int(digit.Tag) Mod 9
            y = Int(digit.Tag / 9)  'conversion to int to truncate the decimal
            If digit.Text = "" Then
                Table(x, y) = "123456789"
            Else
                Table(x, y) = digit.Text
            End If
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateBoard()
    End Sub

    Private Sub Box_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each box As Label In Board.Controls
            box.BackColor = Color.White
            box.Cursor = Cursors.Hand
        Next
        sender.backcolor = Color.FromArgb(200, 255, 255, 255)
        sender.cursor = Cursors.IBeam
        txtKey.Focus()
        txtKey.Text = ""
    End Sub

    Private Sub txtKey_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKey.KeyPress
        For Each box As Label In Board.Controls
            If box.BackColor <> Color.White Then
                If Val(e.KeyChar) > 0 And Val(e.KeyChar) < 10 Then
                    'box.Text = box.Text.Replace(e.KeyChar, "")
                    box.Text = box.Text & e.KeyChar
                ElseIf e.KeyChar = " " Then
                    box.Text = ""
                Else
                    Beep()
                End If
            End If
        Next

    End Sub

#End Region

#Region "Functions"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GetBoard()
        'On Error Resume Next
        'For x = 0 To 8
        '    For y = 0 To 8
        '        If (Table(x, y).ToString.Length > 1 And Table(x, y).ToString.Length < 10) = True Then
        '            Table(x, y) = ""
        '        End If
        '    Next
        'Next
        'PrintBoard()
        'MsgBox("")
        GetBoard()

        MsgBox(Solve)



        PrintBoard()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each box As Label In Board.Controls
            box.Text = ""
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GetBoard()
        tElimination()
        PrintBoard()
    End Sub

#End Region

#Region "Declarations"

    ''\Done = 1         'Solved
    '' \Bad = 0          'More than 1 solution
    ''  \BadEntry = -2    'Invalid Entry
    ''   \Invalid = -1    'Invalid Sudoku

    Dim Complete(8, 8) As String
    Dim BoxDone(2, 2) As String
    Dim Total As Integer
    Dim solved As Boolean

#End Region

    Public Function Start(ByRef Sudoku(,) As String, ByVal Method As Integer) As Integer      '1=normal      2=brute     3=random brute
        Dim result As Integer
        For x = 0 To 8
            For y = 0 To 8
                Table(x, y) = Sudoku(x, y)
            Next
        Next

        Select Case Method
            Case 1
                result = Solve()
            Case 2
                result = BruteForce(False)
            Case 3
                result = BruteForce(True)
        End Select

        For x = 0 To 8
            For y = 0 To 8
                Sudoku(x, y) = Table(x, y)
            Next
        Next
        Return result
    End Function

#Region "Logic : Human"

    Private Function Solve() As Integer
        Total = 0
        For x = 0 To 8
            For y = 0 To 8
                Complete(x, y) = ""
            Next
        Next
        For x = 0 To 2
            For y = 0 To 2
                BoxDone(x, y) = "123456789"
            Next
        Next

        solved = False

        If ErrCheck() = True Then
            Return -2           'invalid entry
        End If

        Elimination()

        If solved = False Then
            While pEliminate() = True
                Elimination()
            End While
            'tElimination()
        End If

        For x = 0 To 8
            For y = 0 To 8
                If Table(x, y) = "" Then
                    Return -1
                End If
            Next
        Next

        If solved = False Then
            Return 0
        End If

        Return 1
    End Function

    Private Function ErrCheck()
        Dim err As Boolean
        For x = 0 To 8
            For y = 0 To 8

                If Table(x, y).ToString.Length = 1 Then     'Start elimination process only if it is a defined digit

                    Dim a As Integer = x    'x coordinate of box
                    Dim b As Integer = y    'y coordinate of box

                    a = Box_Point(a, b).X      '\get the point of the relative box
                    b = Box_Point(a, b).Y      ' \

                    'Elimination Inside Box
                    For i = 0 To 2
                        For j = 0 To 2
                            If New Drawing.Point(a + i, b + j) <> New Drawing.Point(x, y) Then      'check if its not the same box

                                If Table(a + i, b + j) = Table(x, y) Then       'if there are 2 same digits in 1 box
                                    Complete(a + i, b + j) = Table(a + i, b + j)        '\add those points to the error list
                                    Complete(x, y) = Table(x, y)                        ' \     {complete is just a name}
                                    err = True
                                End If
                            End If
                        Next
                    Next

                    'Elimination Inside Row
                    For i = 0 To 8
                        If i <> x Then   'check if its not the same box - in the x row

                            If Table(i, y) = Table(x, y) Then       'if there are 2 same digits in the row
                                Complete(i, y) = Table(i, y)        '\add those points to the error list
                                Complete(x, y) = Table(x, y)        ' \     {complete is just a name}
                                err = True
                            End If
                        End If

                        If i <> y Then   'check if its not the same box - in the y row

                            If Table(x, i) = Table(x, y) Then       'if there are 2 same digits in the row
                                Complete(x, i) = Table(x, i)        '\add those points to the error list
                                Complete(x, y) = Table(x, y)        ' \     {complete is just a name}
                                err = True
                            End If
                        End If
                    Next
                End If

            Next
        Next

        If err = True Then
            For x = 0 To 8
                For y = 0 To 8
                    Table(x, y) = Complete(x, y)
                Next
            Next
            Return True
        Else
            Return False
        End If
    End Function

    Private Function Progress(ByVal x As Integer, ByVal y As Integer, Optional ByVal value As String = "-1") As String
        If value = "-1" Then            'if the value is default then a value is being expected
            Return Complete(x, y)
        Else
            Complete(x, y) = value      'if value is not default so set the vaule
            If value <> "" Then
                Total += 1
            End If
            If Total = 81 Then          'all the numbers are entered ie if the sudoku is solved
                solved = True
            End If
        End If
        Return Nothing
    End Function

    Private Function Box_Point(ByVal x As Integer, ByVal y As Integer) As Drawing.Point        'Returns point for comparision
        x = Int(x / 3) * 3      '\the box coordinates are divisible by 3 so int is to remove the remainder
        y = Int(y / 3) * 3      ' \can also be written as i = (i-(i mod 3))/3

        Return New Drawing.Point(x, y)
    End Function

    Private Sub Elimination()

        If solved = True Then
            Exit Sub
        End If

        Dim Elimination_End As Boolean = True

        'Eliminatoin in Box and Row
        While Elimination_End = True
            Elimination_End = False
            For x = 0 To 8
                For y = 0 To 8

                    If Table(x, y).ToString.Length = 1 Then     'Start elimination process only if it is a defined digit

                        If Progress(x, y) = Nothing Then
                            Elimination_End = True

                            Progress(x, y, Table(x, y))     'add the digit to the completed list

                            If solved = True Then
                                Exit Sub
                            End If

                            Dim a As Integer = x    'x coordinate of box
                            Dim b As Integer = y    'y coordinate of box

                            a = Box_Point(a, b).X      '\get the point of the relative box
                            b = Box_Point(a, b).Y      ' \

                            'Elimination Inside Box
                            For i = 0 To 2
                                For j = 0 To 2
                                    If New Drawing.Point(a + i, b + j) <> New Drawing.Point(x, y) Then      'check if its not the same box
                                        Table(a + i, b + j) = Table(a + i, b + j).Replace(Table(x, y), "")      'replace the possibility with nothing, ""
                                    End If
                                Next
                            Next

                            'Elimination Inside Row
                            For i = 0 To 8
                                If i <> x Then   'check if its not the same box - in the x row
                                    Table(i, y) = Table(i, y).Replace(Table(x, y), "")    'replace the possibility with nothing, ""
                                End If

                                If i <> y Then   'check if its not the same box - in the y row
                                    Table(x, i) = Table(x, i).Replace(Table(x, y), "")    'replace the possibility with nothing, ""
                                End If
                            Next
                        End If

                    End If

                Next
            Next

        End While

        If solved = True Then
            Exit Sub
        End If

        PrintBoard()
        MsgBox("Elimination")

        Determining()
    End Sub

    Private Sub Determining()   'Determining Numbers

        If solved = True Then
            Exit Sub
        End If

        Dim determined As Boolean

        'Per Box
        For x = 0 To 2          '\For each Box
            For y = 0 To 2      ' \

                Dim box_x As Integer = x * 3    'x coordinate of box
                Dim box_y As Integer = y * 3    'y coordinate of box

                For i = 1 To 9      'for all numbers
                    Dim count As Integer = 0
                    Dim point As New Drawing.Point With {.X = -1, .Y = -1}

                    For a = 0 To 2          '\For each number in the box
                        For b = 0 To 2      ' \

                            If Table(box_x + a, box_y + b).ToString.Length <> 1 Then        'if there are possibilities in the box
                                Dim asd As String = Table(box_x + a, box_y + b).Replace(i, "")
                                If Table(box_x + a, box_y + b).Replace(i, "") <> Table(box_x + a, box_y + b) Then       'the string will change after replacement of the digit from the string
                                    count += 1          'add 1 to total number of possibilities

                                    point.X = box_x + a     '\obviously the number will be determined if the count=1
                                    point.Y = box_y + b     ' \and if count stays 1 this point will be determined
                                End If
                            End If

                        Next
                    Next

                    If count = 1 Then       'if there is only one possibility then determine
                        PrintBoard()
                        'MsgBox("Box")
                        Table(point.X, point.Y) = i     'replace that point with the number
                        determined = True
                    End If
                Next

            Next
        Next

        'Per Row
        For c = 0 To 8

            For i = 1 To 9      'for all numbers
                Dim hor As Integer      'no of possibilities in Horizontal rows
                Dim ver As Integer      'no of possibilities in Vertical rows
                Dim point_h As Drawing.Point    'Point in horizontal rows
                Dim point_v As Drawing.Point    'Point in vertical rows

                For a = 0 To 8
                    'If Table(c, a).ToString.Length <> 1 Then
                    If Table(c, a).Replace(i.ToString, "") <> Table(c, a) Then      '\Horizontal Rows\
                        hor += 1                                                    ' \               \
                        point_h.X = c                                               '  \               \
                        point_h.Y = a                                               '   \               \
                    End If
                    'End If

                    'If Table(a, c).ToString.Length <> 1 Then
                    If Table(a, c).Replace(i.ToString, "") <> Table(a, c) Then      '\Vertical Rows\
                        ver += 1                                                    ' \             \
                        point_v.X = a                                               '  \             \
                        point_v.Y = c                                               '   \             \
                    End If
                    'End If
                Next

                If hor = 1 Then         'if there is only 1 possibility of a number in the row then determine
                    If Table(point_h.X, point_h.Y).ToString.Length > 1 Then
                        PrintBoard()
                        'MsgBox("hor")
                        Table(point_h.X, point_h.Y) = i
                        determined = True

                    End If
                    hor = 0
                End If

                If ver = 1 Then         'if there is only 1 possibility of a number in the row then determine
                    If Table(point_v.X, point_v.Y).ToString.Length > 1 Then

                        PrintBoard()
                        'MsgBox("ver")
                        Table(point_v.X, point_v.Y) = i
                        determined = True
                    End If
                    ver = 0
                End If
            Next

        Next

        If solved = True Then
            Exit Sub
        End If

        If determined = True Then       'if a number is determined then there can be elimination
            PrintBoard()
            MsgBox("Determination")
            Elimination()
            Exit Sub
        End If

    End Sub

    Private Function pEliminate() As Boolean        'Elimination by Possibility
        Dim Eliminated As Boolean = False
        For x = 0 To 2          '\Loop for each box
            For y = 0 To 2      ' \

                Dim box_x As Integer = x * 3    'x coordinate of box
                Dim box_y As Integer = y * 3    'y coordinate of box

                For i = 1 To 9      'for all numbers

                    Dim point As New Drawing.Point With {.X = -1, .Y = -1}
                    Dim axis As String = ""      'Digit is repeated in which axis

                    If BoxDone(x, y).Replace(i, "") <> BoxDone(x, y) Then
                        For a = 0 To 2          '\Loop for numbers inside the box
                            For b = 0 To 2      ' \
                                'Dim asd As String = Table(box_x + a, box_y + b)
                                'Dim bsd As String = Table(point.X, point.Y)

                                If Table(box_x + a, box_y + b).Replace(i, "") <> Table(box_x + a, box_y + b) Then       'the string will change after replacement of the digit from the string
                                    If Table(box_x + a, box_y + b).ToString.Length <> 1 Then        'if there are possibilities in the box
                                        If point.X = -1 Then        'if this is the first possibility detected

                                            point.X = box_x + a     '\record the point
                                            point.Y = box_y + b     ' \coz either of the coordinate will be same
                                        Else


                                            If point.X = box_x + a Then     'if repeated in x row
                                                axis = axis & "y"
                                                b = 2
                                            ElseIf point.Y = box_y + b Then     'if repeated in y row
                                                axis = axis & "x"
                                            Else        'if repeated somewhere else
                                                point.X = -1
                                                GoTo ExitLoop
                                            End If

                                            If axis.Length > 1 Then         'if repeated in x & y rows both
                                                point.X = -1
                                                GoTo ExitLoop
                                            End If

                                        End If

                                    End If
                                End If
                            Next
                        Next
                    End If

ExitLoop:
                    'Elimination from possibility
                    If point.X <> -1 Then
                        BoxDone(x, y) = BoxDone(x, y).Replace(i, "")
                        For j = 0 To 8      'Numbers in a row
                            If axis = "y" Then      'x is constant and y is the j variable
                                If Box_Point(point.X, point.Y) <> Box_Point(point.X, j) Then      'if the point in the row is not of the same box
                                    If Table(point.X, j).ToString.Length <> 1 Then      'if the that point is not already determined
                                        'Dim asd As String = Table(point.X, j)
                                        'Dim psd As String = Table(point.X, j).Replace(i, "")
                                        If Table(point.X, j) <> Table(point.X, j).Replace(i, "") Then        'if elimination hasnt already been done 
                                            Table(point.X, j) = Table(point.X, j).Replace(i, "")      'replace the possibility with nothing, ""
                                            Eliminated = True       'Because there will be elimination if the condition is true
                                        End If
                                    End If
                                End If
                            End If

                            If axis = "x" Then      'y is constant and x is the j variable
                                If Box_Point(point.X, point.Y) <> Box_Point(j, point.Y) Then      'if the point in the row is not of the same box
                                    If Table(j, point.Y).ToString.Length <> 1 Then      'if the that point is not already determined

                                        If Table(j, point.Y) <> Table(j, point.Y).Replace(i, "") Then        'if elimination hasnt already been done 
                                            Table(j, point.Y) = Table(j, point.Y).Replace(i, "")      'replace the possibility with nothing, ""
                                            Eliminated = True       'Because there will be elimination if the condition is true
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If

                Next
            Next
        Next

        PrintBoard()
        MsgBox("pElimination")
        'tElimination()

        If Eliminated = True Then
            Return True
        End If
    End Function

#End Region

#Region "Logic : Brute Force"

    Private Function BruteForce(ByVal Random As Boolean) As Integer
        Dim original(8, 8) As String
        Dim c As String
        Dim possibles As New List(Of Drawing.Point)

        For x = 0 To 8
            For y = 0 To 8
                If Table(x, y).ToString.Length > 1 Then
                    possibles.Add(New Drawing.Point(x, y))
                End If
                'original(x, y) = Table(x, y)
            Next
        Next

        For i = 0 To possibles.Count - 1
            c = Table(possibles(i).X, possibles(i).Y)
            If c.Length > 1 Then
                Dim l As Integer = c.Length
                For k = 1 To l

                    For x = 0 To 8
                        For y = 0 To 8
                            original(x, y) = Table(x, y)
                        Next
                    Next

                    Randomize()

                    If Random = True Then
                        Dim rand As Integer = Int((Rnd() * c.Length) + 1)
                        Dim r As Char = Mid(c, rand, 1)
                        c = c.Replace(r, "")

                        Table(possibles(i).X, possibles(i).Y) = r 'Mid(c, k, 1)
                    Else
                        Table(possibles(i).X, possibles(i).Y) = Mid(c, k, 1)
                    End If
                    Select Case Solve()
                        Case 1
                            GoTo done
                        Case 0
                            Exit For
                        Case -1
                            For x = 0 To 8
                                For y = 0 To 8
                                    Table(x, y) = original(x, y)
                                    If original(x, y).ToString.Length > 1 Then
                                        Complete(x, y) = Nothing
                                    End If
                                Next
                            Next

                    End Select
                Next
            End If
        Next

        Return -1

        Exit Function

done:
        Return 1

    End Function

#End Region

#End Region

    Private Sub tElimination()

        Dim possibles As New List(Of String)
        Dim min As Byte = 9     'minimum no of possibilities in a box
        Dim p As String = ""

        For i = 0 To 8
            If Table(i Mod 3, Int(i / 3)).ToString.Length > 1 Then
                possibles.Add(Table(i Mod 3, Int(i / 3)))
                p = p & Table(i Mod 3, Int(i / 3))

                If Table(i Mod 3, Int(i / 3)).ToString.Length < min Then
                    min = Table(i Mod 3, Int(i / 3)).ToString.Length
                End If
            End If
        Next

        For i = min To possibles.Count - 1
            Dim depth As Byte = i
            Dim selective As Boolean = True

            If possibles.Count - i < i Then
                selective = False
            End If

            For v1 = 1 To possibles.Count
                If depth > 1 Then
                    For v2 = 1 To possibles.Count
                        If v1 <> v2 Then
                            If depth > 2 Then
                                For v3 = 1 To possibles.Count
                                    If (v3 <> v1 And v2 <> v3) = True Then
                                        If depth > 3 Then
                                            For v4 = 1 To possibles.Count
                                                If (v4 <> v1 And v4 <> v2 And v4 <> v3) = True Then
                                                    pattern(possibles, v1 & v2 & v3 & v4, selective)
                                                End If
                                            Next
                                        Else
                                            pattern(possibles, v1 & v2 & v3, selective)
                                        End If
                                    End If
                                Next
                            Else
                                If pattern(possibles, v1 & v2, selective) = True Then
                                    Exit Sub
                                End If
                            End If
                        End If
                    Next
                Else
                    pattern(possibles, v1, selective)
                End If
            Next

        Next
    End Sub

    Private Function pattern(ByVal possibles As List(Of String), ByVal boxes As String, ByVal selective As Boolean) As Boolean
        If boxes = "139" Then
            MsgBox("")
        End If
        Dim n As Byte
        Dim p As String = ""
        Dim pc As Byte
        Dim eliminated As Boolean
        For i = 1 To possibles.Count
            If selective = True Then
                If boxes <> boxes.Replace(i, "") Then
                    p = p & possibles(i - 1)
                End If
            Else
                If boxes = boxes.Replace(i, "") Then
                    p = p & possibles(i - 1)
                End If
            End If
        Next

        For i = 1 To 9
            If p <> p.Replace(i, "") Then
                p = p.Replace(i, "") & i
                pc += 1
            End If
        Next

        If selective = False Then
            If boxes.Length = pc Then
                For i = 1 To boxes.Length

                    n = Mid(boxes, i, 1) - 1

                    For k = 1 To p.Length
                        possibles(n) = possibles(n).Replace(Mid(p, k, 1), "")
                    Next
                Next
                eliminated = True
            End If
        Else
            If possibles.Count - boxes.Length = pc Then
                For i = 1 To possibles.Count
                    If boxes <> boxes.Replace(i, "") Then
                        For k = 1 To 9
                            If p <> p.Replace(k, "") Then
                                possibles(i - 1) = possibles(i - 1).Replace(Mid(p, k, 1), "")
                            End If
                        Next
                    End If
                Next
                eliminated = True
            End If
        End If

        If eliminated = True Then
            For i = 1 To possibles.Count
                Dim x As Integer

                While Table(x Mod 3, Int(x / 3)).ToString.Length = 1
                    x += 1
                End While

                Table(x Mod 3, Int(x / 3)) = possibles(i - 1)

                x += 1
            Next
            Return True
        End If

        Return False
    End Function


End Class
